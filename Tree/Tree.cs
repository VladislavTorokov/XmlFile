using System;
using System.Collections.Generic;

namespace XML.Tree
{
    public class Tree
    {
        public bool xmlComplete = false;
        public bool nodeWasCreated = false;
        public bool notUndoCommand = true;
        public List<Observer.IObserver> _observers;
        public Stack<Command.Command> _commands;
        public Stack<Node> _nodes;
        public string name;
        public string item;
    }
}
