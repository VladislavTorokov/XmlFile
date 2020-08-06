using System;
using System.Collections.Generic;
using System.IO;

namespace XML.Command
{
    public class ExitCommand:Command
    {
        public ExitCommand()
        {
        }
        public override void Execute()
        {
            File.Delete(path);
            System.Threading.Thread.CurrentThread.Abort();
        }
    }
}
