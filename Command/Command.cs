using System;
using System.Collections.Generic;

namespace XML.Command
{
    public abstract class Command
    {
        public abstract void Execute();
        public Builder.TreeBuilder _treeBuilder= new Builder.TreeBuilder();        
        protected Builder.NodeBuilder _nodeBuilder;
        protected string path = "myLog.txt";
        public Command()
        {
        }
        public static Command Create(Builder.TreeBuilder treebuilder,string args, string parameters,string name)
        {
            switch(args)
            {
                case "add":return new AddCommand(treebuilder,parameters);
                case "set":return new SetCommand(treebuilder,parameters,name);
                case "save":return new SaveCommand(treebuilder);
                case "printLog":return new PrintLogCommand(treebuilder);
                case "print":return new PrintCommand(treebuilder);
                case "exit":return new ExitCommand();
                case "undo":return new UndoCommand(treebuilder);
                default:return null;

            }
        }
    }
}
