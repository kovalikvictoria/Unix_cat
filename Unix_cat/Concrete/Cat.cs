using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unix_cat.General;

namespace Unix_cat.Concrete
{
    public class Cat : Command
    {
        public override bool Execute()
        {
            try
            {
                switch (Option)
                {
                    case null:
                        return CatOptions.Cat(parameters[0], parameters[1], parameters[2]);

                    case "-b":
                        return CatOptions.NumberNonblank(parameters[0], parameters[1], parameters[2]);

                    case "-E":
                        return CatOptions.ShowEnds(parameters[0], parameters[1], parameters[2]);

                    case "-n":
                        return CatOptions.Number(parameters[0], parameters[1], parameters[2]);

                    case "-s":
                        return CatOptions.SqueezeBlank(parameters[0], parameters[1], parameters[2]);

                    case "-T":
                        return CatOptions.ShowTabs(parameters[0], parameters[1], parameters[2]);

                    case "--version":
                        return CatOptions.Version();

                    case "--help":
                        return CatOptions.Help();

                    default:
                        Console.WriteLine("No such option " + Option);
                        Console.WriteLine("See cmp --help");
                        return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                return false;
            }
        }
    }
}
