using System;
using System.Collections.Generic;
using System.Linq;


namespace XML.Builder
{
    public class TreeBuilder:Observer.IObservable
    {
        private Tree.Tree tree;

        public TreeBuilder()
        {
            this.tree = new Tree.Tree();           
            tree._observers = new List<Observer.IObserver>();
            tree._nodes = new Stack<Tree.Node>();
            tree._commands = new Stack<Command.Command>();
           
        }

        public TreeBuilder AddNode(Tree.Node node)
        {
            tree._nodes.Push(node);
            SetNameObserver(node.name);
            tree.nodeWasCreated = true;
            return this;
        }

        public TreeBuilder SetItem(string name, string arg)
        {
            var myNode = tree._nodes.Where(x => x.name == name).FirstOrDefault();
            if (myNode != null)
            {
                myNode._items.Add(arg);
                SetItemObserver(name,arg);
            }
            return this;
        }

        public void Save()
        {
            foreach (Observer.IObserver obs in tree._observers)
            {
                if (tree._nodes.Count >= 1)
                {
                    obs.SaveNode(tree._nodes.Pop().name);
                    if (tree._nodes.Count == 0)
                        tree.xmlComplete = true;
                }
                else
                {
                    if (tree.nodeWasCreated)
                    {
                        Console.WriteLine("Xml завершен");
                        tree.xmlComplete = true;
                    }
                    else
                        Console.WriteLine("Xml не создан");
                }
            }
        }

        public void RegisterObserver(Observer.IObserver obs)
        {
            tree._observers.Add(obs);
        }

        public void RemoveObserver(Observer.IObserver obs)
        {
            var myObserver = tree._observers.Where(x => x == obs).FirstOrDefault();
            if (myObserver != null)
            {
                tree._observers.Remove(myObserver);
            }
        }

        public void SetNameObserver(string name)
        {
            foreach (Observer.IObserver obs in tree._observers)
            {
                obs.SetName(name);
            }
        }

        public void SetItemObserver(string name,string item)
        {
            foreach (Observer.IObserver obs in tree._observers)
            {
                obs.SetItem(name,item);
            }
        }

        public Tree.Tree GetResult()
        {
            return this.tree;
        }

    }
}
