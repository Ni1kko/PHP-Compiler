# PHP-Compiler
Simple class witch handles compiling a .php script within C-Sharp

[![Open Source? Yes!](https://badgen.net/badge/Open%20Source%20%3F/Yes%21/blue?icon=github)](#)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](#)

### Example Usage

```
using System;
using System.Threading.Tasks;
using Fallox;//add our namespace

namespace FalloxTest
{
    internal class Program
    {
        internal static async Task Main()
        {
            //How to get contents
            var filePath = "c:\\wwwroot\\index.php";
            var page = await PHP.Compiler(filePath);

            //Show contents in console
            Console.WriteLine($"Page contents: {page}");
            Console.ReadKey();
        }
    }
}
```
