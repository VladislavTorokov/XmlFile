using System;

namespace XML.Observer
{
    public interface IObserver
    {
        void SetName(string name);
        void SetItem(string name,string item);
        void SaveNode(string name);
    }
}
