using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML.Observer
{
    public interface IObservable
    {
        void RegisterObserver(IObserver obs);
        void RemoveObserver(IObserver obs);
        void SetNameObserver(string name);
        void SetItemObserver(string name, string item);
    }
}
