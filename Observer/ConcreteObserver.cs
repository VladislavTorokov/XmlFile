using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML.Observer
{
    class ConcreteObserver : IObserver
    {
        string path = "myLog.txt";
        public ConcreteObserver(Builder.TreeBuilder treeBuilder)
        {
            treeBuilder.RegisterObserver(this);
        }

        public void SetName(string name)
        {
            File.AppendAllText(path, "<" + name + ">\n");
        }
        public void SetItem(string name,string item)
        {
            int numberString = 0;
            string[] Text = File.ReadAllLines(path);
            File.Delete(path);
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] == ("<" + name + ">"))
                {
                    numberString = i;
                }
            }
            for (int i = 0; i <= numberString; i++)
            {
                File.AppendAllText("myLog.txt", Text[i]+"\n");
            }
            File.AppendAllText("myLog.txt", item + "\n");
            for (int i = numberString+1; i < Text.Length; i++)
            {
                File.AppendAllText("myLog.txt", Text[i] + "\n");
            }
        }
        public void SaveNode(string name)
        {
            File.AppendAllText("myLog.txt","</"+name+">\n");
        }
    }
}
