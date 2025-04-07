using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CentralLauncher
{
    internal class Program
    {
        // Dictionary mapping menu options to project paths
        private static Dictionary<string, string> _projectPaths = new Dictionary<string, string>();

        static async Task Main(string[] args)
        {
            Console.Title = "LINQ Advanced Central Launcher";

            // Get base directory for the solution 
            string solutionDirectory = GetSolutionDirectory();

            // Find and map all console projects
            FindConsoleProjects(solutionDirectory);

            if (_projectPaths.Count == 0)
            {
                Console.WriteLine("No console projects found in the solution directory.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                DisplayMenu();

                Console.Write("\nEnter your choice (or 'exit' to quit): ");
                string choice = Console.ReadLine();

                if (string.Equals(choice, "exit", StringComparison.OrdinalIgnoreCase))
                    break;

                await ExecuteProject(choice);

                Console.WriteLine("\nReturned to launcher. Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static string GetSolutionDirectory()
        {
            // Get the current assembly's location and navigate up to find solution directory
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            // Navigate up until we find the solution directory (contains .sln file) or hit the root
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            if (directory == null)
            {
                // If we couldn't find the solution directory, use a relative path as fallback
                return Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\.."));
            }

            return directory.FullName;
        }

        private static void FindConsoleProjects(string solutionDirectory)
        {
            // Clear existing projects
            _projectPaths.Clear();

            // Find all .csproj files
            string[] projectFiles = Directory.GetFiles(solutionDirectory, "*.csproj", SearchOption.AllDirectories);
            string solutionName = Path.GetFileNameWithoutExtension(Directory.GetFiles(solutionDirectory, "*.sln").FirstOrDefault() ?? "");

            int index = 1;
            foreach (string projectFile in projectFiles)
            {
                // Get the project name from the file path
                string projectName = Path.GetFileNameWithoutExtension(projectFile);

                // Skip the launcher project itself
                if (projectName == "CentralLauncher")
                    continue;

                // Skip the solution project if it exists
                if (projectName == solutionName)
                    continue;

                // Check if it's a console app (.csproj content contains OutputType>Exe)
                string projectContent = File.ReadAllText(projectFile);
                if (projectContent.Contains("<OutputType>Exe</OutputType>") ||
                    projectContent.Contains("<OutputType>exe</OutputType>"))
                {
                    _projectPaths.Add(index.ToString(), projectFile);
                    index++;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("=== LINQ Advanced Project Launcher ===\n");

            foreach (var project in _projectPaths)
            {
                string projectName = Path.GetFileNameWithoutExtension(project.Value);
                Console.WriteLine($"{project.Key}. {projectName}");
            }
        }

        private static async Task ExecuteProject(string choice)
        {
            if (!_projectPaths.TryGetValue(choice, out string projectPath))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return;
            }

            string projectDirectory = Path.GetDirectoryName(projectPath);
            string projectName = Path.GetFileNameWithoutExtension(projectPath);

            Console.Clear();
            Console.WriteLine($"=== Running {projectName} ===\n");

            try
            {
                // Create a batch file to run the project and pause afterward
                string batchFilePath = Path.Combine(Path.GetTempPath(), $"run_{projectName}.bat");

                // Write commands to the batch file
                // The pause command will keep the window open until the user presses a key
                File.WriteAllText(batchFilePath,
                    $"@echo off\r\n" +
                    $"echo Running {projectName}...\r\n" +
                    $"cd /d \"{projectDirectory}\"\r\n" +
                    $"dotnet run --project \"{projectPath}\"\r\n" +
                    $"echo.\r\n" +
                    $"echo Execution completed. Press any key to return to the launcher...\r\n" +
                    $"pause > nul\r\n");

                // Run the batch file in a new window
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = batchFilePath,
                        UseShellExecute = true,
                        CreateNoWindow = false
                    }
                };

                Console.WriteLine("Starting project...");
                process.Start();

                // Wait for the process to complete
                await process.WaitForExitAsync();

                // Clean up the temporary batch file
                try
                {
                    File.Delete(batchFilePath);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing project: {ex.Message}");
            }
        }
    }
}