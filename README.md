# PHP-Compiler
Simple class witch handles compiling a .php script within C-Sharp

[![Open Source? Yes!](https://badgen.net/badge/Open%20Source%20%3F/Yes%21/blue?icon=github)](#)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](#)

### Setup
---
##### Copy php on build
```
Open Visual Studio And Create a folder inside root of you project named `php`
Now Download https://windows.php.net/downloads/releases/php-8.0.7-nts-Win32-vs16-x64.zip
With the Downloaded `php-8.0.7-nts-Win32-vs16-x64.zip` Extract all the archive contents into the folder named `php`
Now Open Visual Studio again and select all the files that you just moved inside the folder named `php`
With Selected click properties and change `Copy to Output Directory` too `Copy Always` 
Finaly With Selected change `Build Action` too `Embedded Resource`
Done.
``` 
![Example-image](https://i.imgur.com/h7QQQW0.png)

### OR

##### Manualy add php
```
Create a folder beside you applicaions .exe named `php`
Now Download https://windows.php.net/downloads/releases/php-8.0.7-nts-Win32-vs16-x64.zip
With the Downloaded `php-8.0.7-nts-Win32-vs16-x64.zip` Extract all the archive contents into the folder named `php`
Done.
```
![Example-image](https://i.imgur.com/q3h4vdY.png)

---


# Example Usage

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
            var filePath = @"c:\wwwroot\index.php";
            var page = await PHP.Compiler(filePath);

            //Show contents in console
            Console.WriteLine($"Page contents: {page}");
            Console.ReadKey();
        }
    }
}
```
