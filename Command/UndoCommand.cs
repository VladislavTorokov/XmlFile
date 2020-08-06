using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML.Command
{
    public class UndoCommand : Command
    {
        public UndoCommand(Builder.TreeBuilder builder)
        {
            _treeBuilder = builder;
        }
        public override void Execute()
        {


            if (_treeBuilder.GetResult()._commands.Count != 0)
            {
                _treeBuilder.GetResult().notUndoCommand = false;
                if (_treeBuilder.GetResult()._commands.Peek().GetType() == typeof(SaveCommand))
                {
                    int numberString = 0;
                    string[] Text = File.ReadAllLines(path);
                    for (int i = 0; i < Text.Length; i++)
                    {
                        if (Text[i] ==("<"+_treeBuilder.GetResult().name+">"))
                        {
                            
                            numberString = i;
                        }
                    }
                    File.Delete(path);
                    for(int i =0;i<numberString;i++)
                    {
                        File.AppendAllText("myLog.txt",Text[i] + "\n");
                    }

                    _treeBuilder.GetResult().notUndoCommand = true;

                }
                else
                    _treeBuilder.GetResult().notUndoCommand = true;
            }

        }
    }
}
