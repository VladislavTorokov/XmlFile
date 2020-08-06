using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML.Command
{
    public class PrintLogCommand:Command
    {
        public PrintLogCommand(Builder.TreeBuilder builder)
        {
            _treeBuilder = builder;
        }
        public override void Execute()
        {
            if (_treeBuilder.GetResult().xmlComplete)
            {
                if (File.Exists(path))
                {
                    string[] readText = File.ReadAllLines(path);
                    foreach (string s in readText)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            else
            {
                if (_treeBuilder.GetResult().nodeWasCreated)
                    while (_treeBuilder.GetResult()._nodes.Count != 0)
                        _treeBuilder.Save();
                if (File.Exists(path))
                {
                    string[] readText = File.ReadAllLines(path);
                    foreach (string s in readText)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                    Console.WriteLine("Xml файл не создан");
            }
        }
    }
}
