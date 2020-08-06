using System;
using System.Collections.Generic;
using System.Linq;

namespace XML.Command
{
    public class SetCommand:Command
    {
        public SetCommand(Builder.TreeBuilder builder,string args,string name)
        {
            _treeBuilder = builder;
            if (_treeBuilder.GetResult().xmlComplete)
                Console.WriteLine("Xml завершен");
            else
                _treeBuilder.SetItem(args,name);
        }
        public override void Execute()
        {
            //    SetItemObserver(_treeBuilder.GetResult()._nodes.Last().);
            if (_treeBuilder.GetResult().notUndoCommand)
                _treeBuilder.GetResult()._commands.Push(this);
        }
    }
}
