using System.Diagnostics;

namespace casaWinOS.Services
{
    public static class DockerComposer
    {
        public static void AddFromCompose(string composeYml)
        {
            string dockerComposeYml = @"
            version: '3.8'
            services:
              myapp:
                image: mydockerapp:latest
                build:
                  context: .
                  dockerfile: Dockerfile
                ports:
                  - '8080:80'
            ";

            try
            {
                // Create a temporary file to hold the docker-compose.yml content
                string tempFilePath = Path.GetTempFileName() + ".yml";
                File.WriteAllText(tempFilePath, dockerComposeYml);

                // Run Docker Compose Up
                RunDockerCompose("up", "--build", "-f", tempFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void RunDockerCompose(params string[] args)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "docker-compose",
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
