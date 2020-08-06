using System;
using System.Collections.Generic;

namespace XML.Command
{
    class AddCommand:Command
    {
        public AddCommand(Builder.TreeBuilder builder,string args)
        {
            _treeBuilder = builder;
            _nodeBuilder = new XML.Builder.NodeBuilder().SetName(args);
            _treeBuilder.GetResult().name = args;
        }
        public override void Execute()
        {
            if (_treeBuilder.GetResult().xmlComplete)
                Console.WriteLine("Xml завершен");
            else
            {
                _treeBuilder.AddNode(_nodeBuilder.GetResult());
            }
            if (_treeBuilder.GetResult().notUndoCommand)
                _treeBuilder.GetResult()._commands.Push(this);
        }
    }
}
