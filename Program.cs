using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeBuilder = new Builder.TreeBuilder();
            var concreteObserver = new Observer.ConcreteObserver(treeBuilder);
            Console.WriteLine("Доступные коммнды:");
            Console.WriteLine("add:имя - добавить тег");
            Console.WriteLine("set:имя тега:атрибут - добавить атрибут в тег");
            Console.WriteLine("save - сохранить/закрыть текущий тег");
            Console.WriteLine("print - вывести текущее состояние xml файла");
            Console.WriteLine("printLog - вывести завершенный xml файл");
            Console.WriteLine("exit - выход");
            while (true)
            {
                string userString = Console.ReadLine();
                string[] arg = userString.Split(':');
                var command = Command.Command.Create(treeBuilder, arg[0], arg.Length > 1 ? arg[1] : null, arg.Length > 2 ? arg[2] : null);           
                if(command!=null)
                    command.Execute();
                if (command != null)
                    treeBuilder = command._treeBuilder;
                else
                    Console.WriteLine("Некорректный ввод");
            }
        }
    }
}
