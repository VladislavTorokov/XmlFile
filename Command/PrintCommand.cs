using System;
using System.Collections.Generic;
using System.IO;

namespace XML.Command
{
    public class PrintCommand:Command
    {
        public PrintCommand(Builder.TreeBuilder builder)
        {
            _treeBuilder = builder;
        }
        public override void Execute()
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }
            }
            else
                Console.WriteLine("Нет узлов");
        }
    }
}
