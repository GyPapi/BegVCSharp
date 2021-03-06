﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch07Ex02
{
    class Program
    {
        static string[] eTypes = { "none", "simple", "index", "nested index", "filter" };

        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    WriteLine("Main() try block reached.");
                    WriteLine($"ThrowException(\"{eType}\") called.");
                    ThrowException(eType);
                    WriteLine("Main() try block continues.");
                }
                catch (System.IndexOutOfRangeException e) when (eType == "filter")
                {
                    // Change the background color in the console window so this error stands out.
                    BackgroundColor = ConsoleColor.Red;
                    WriteLine("Main() FILTERED System.IndexOutOfRangeException catch block reached."
                        + $" Message:\n\"{e.Message}\"");
                    ResetColor();
                }
                catch (System.IndexOutOfRangeException e)
                {
                    WriteLine("Main() System.IndexOutOfRangeException catch block reached."
                        + $" Message:\n\"{e.Message}\"");
                }
                catch
                {
                    WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    WriteLine("Main() finally block reached.");
                }
                WriteLine();
            }
            ReadKey();
        }

        static void ThrowException(string exceptionType)
        {
            WriteLine($"ThrowException(\"{exceptionType}\") reached.");
            switch (exceptionType)
            {
                case "none":
                    WriteLine("Not throwing an exception.");
                    break;
                case "simple":
                    WriteLine("Throwing System.Exception.");
                    throw new System.Exception();
                case "index":
                    WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[5] = "error";
                    break;
                case "nested index":
                    try
                    {
                        WriteLine("ThrowException(\"nested index\") try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");
                    }
                    catch
                    {
                        WriteLine("ThrowException(\"nested index\") general catch block reached.");
                        // The "index" error was caught here, so we need to re-throw it for Main() to catch it.
                        throw;
                    }
                    finally
                    {
                        WriteLine("ThrowException(\"nested index\") finally block reached.");
                    }
                    break;
                case "filter":
                    try
                    {
                        WriteLine("ThrowException(\"filter\") try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");
                    }
                    catch
                    {
                        WriteLine("ThrowException(\"filter\") general catch block reached.");
                        // The "index" error was caught here, so we need to re-throw it for Main() to catch it.
                        throw;
                    }
                    break;
            }
        }
    }
}
