using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using ToyRobotSimulator.Models;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class ControllerTests
    {
        public ControllerTests()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "dotnet",
                Arguments = Assembly.GetAssembly(typeof(Robot)).Location,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            Process = new Process()
            {
                StartInfo = processStartInfo
            };
        }

        private Process Process;

        /// <summary>
        /// Cycles through each provided test file in TestInputFiles and runs the input into the main program.
        /// It will then compare the output it received to the expected outcome in the Results folder.
        /// </summary>
        [Fact]
        public void RunTestFiles()
        {
            var testDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\TestInputFiles";

            var testFilePaths = Directory.GetFiles(testDirectory);

            foreach (var filePath in testFilePaths)
            {
                Process.Start();

                var testFileLines = File.ReadAllLines(filePath);

                foreach (var line in testFileLines)
                {
                    Process.StandardInput.WriteLine(line);
                }

                var output = "";

                while (!Process.StandardOutput.EndOfStream)
                {
                    output += Process.StandardOutput.ReadLine() + Environment.NewLine;
                }

                var testFileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);

                var expectedOutputFile = testDirectory + "\\Results\\" + testFileName;

                var expectedOutput = File.ReadAllText(expectedOutputFile);

                Assert.Equal(output, expectedOutput);

                Process.Close();
            }
        }
    }
}
