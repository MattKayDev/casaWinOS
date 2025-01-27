using System.Diagnostics;

namespace casaWinOS.Services
{
    public class DockerService
    {

        public static void RestartContainerWithEnv(string containerName, string envVariable, string newValue)
        {
            // Stop the container
            RunDockerCommand("stop", containerName);

            // Restart the container with new environment variable
            RunDockerCommand("run", "--name", containerName, "-e", $"{envVariable}={newValue}", "mydockerapp:latest"); // Adjust as needed
        }

        static void RunDockerCommand(params string[] args)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = string.Join(" ", args),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (var process = Process.Start(processInfo))
            {
                using (var reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
                using (var reader = process.StandardError)
                {
                    string error = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }
                process.WaitForExit();
            }
        }
    }
}
