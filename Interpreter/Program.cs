﻿using System;
using System.IO;
using Interpreter.Parsing;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter(new StandardOut());

            using (var script = new StreamReader(args[0]))
            {
                var parser = new CLikeParser();
                var parseResult = parser.Parse(script.ReadToEnd());
                interpreter.Evaluate(parseResult);
            }
        }
    }

    class StandardOut : IOut
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
