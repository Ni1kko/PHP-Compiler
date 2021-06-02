/*
    @Filename:      PHP.cs
    @Author:        Ni1kko
    @Descritpion:   Simple class to handle compiling a .php script
*/

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Fallox
{
    internal static class PHP
    {
        private static readonly string CompilerPath = Environment.CurrentDirectory + "\\php";
        private static readonly string CompilerPathFull = CompilerPath + "\\php.exe";
        
        internal static async Task<string> Compiler(string filePath)
        {
            //setup compiler
            var PHPProcess = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = CompilerPathFull,
                    Arguments = "-d \"display_errors=1\" -d \"error_reporting=E_PARSE\" \"" + filePath + "\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                },
                PriorityClass = ProcessPriorityClass.RealTime
            };

            //compiler ended event
            PHPProcess.Disposed += PHPCompilerExit;
            PHPProcess.Exited += PHPCompilerExit;
            void PHPCompilerExit(object sender, EventArgs events) => Console.WriteLine($"PHP Compiler Session Ended");

            //load compiler
            PHPProcess.Start();
            Console.WriteLine($"PHP Compiler Session Began");
            await Task.Delay(500);

            //get compiled page
            var PHPDocument = await PHPProcess.CurrrentDocument();

            //close compiler
            PHPProcess.StandardOutput.Close();
            PHPProcess.Close();
            PHPProcess.Dispose();

            //return compiled page 
            return PHPDocument;
        }
       
        private static async Task<string> CurrrentDocument(this Process PHPProcess) 
        {
            //Gets compiled page result 
            string loadedPage = PHPProcess.StandardOutput.ReadToEnd();
            await Task.Delay(200);

            //Tweak result on error
            if (string.IsNullOrEmpty(loadedPage) || loadedPage.StartsWith("\nParse error: syntax error"))
            {
                PHPProcess.StandardError.Close();
                loadedPage = "<h2>Error</h2><hr/><h4>Error Details: </h4><pre>" + loadedPage + "</pre>";
            };

            //return result
            return loadedPage;
        }
    }
}