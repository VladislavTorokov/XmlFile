using System;
using System.Collections.Generic;

namespace XML.Command
{
    public class SaveCommand:Command
    {
        public SaveCommand(Builder.TreeBuilder builder)
        {
            _treeBuilder = builder;
        }
        public override void Execute()
        {
            _treeBuilder.Save();
            if (_treeBuilder.GetResult().notUndoCommand)
                _treeBuilder.GetResult()._commands.Push(this);
        }
    }
}
