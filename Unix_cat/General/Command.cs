using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unix_cat.General
{
    public abstract class Command
    {
        public string Option;
        public string[] parameters;
        public abstract bool Execute();
    }
}
