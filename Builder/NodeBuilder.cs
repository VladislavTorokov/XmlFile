using System;
using System.Collections.Generic;


namespace XML.Builder
{
    public class NodeBuilder
    {
        public Tree.Node node;
        public NodeBuilder()
        {
            this.node = new Tree.Node();
            node._items = new List<string>();
        }
        public NodeBuilder SetName(string name)
        {
            node.name = name;
            return this;
        }
        public NodeBuilder AddItem(string item)
        {
            node._items.Add(item);
            return this;
        }
        public Tree.Node GetResult()
        {
            return this.node;
        }
    }
}
