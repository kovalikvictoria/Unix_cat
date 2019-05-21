using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unix_cat.General;
using Unix_cat.Concrete;
using Helper;

namespace ConsoleMenu
{
    public class ConsoleMenu
    {
        private Command CurrentCommand;

        public void Init()
        {
            while(true)
            {
                Console.WriteLine(">>>  ");
                string[] input = StringHelper.Split(Console.ReadLine(), ' ');

                if (input[0] == "cat")
                {
                    CurrentCommand = new Cat();
                    if (input[1].Contains("-"))
                    {
                        CurrentCommand.Option = input[1];

                        if (input.Length > 2)
                        {
                            CurrentCommand.parameters = new string[input.Length];
                            for (int i = 2; i < input.Length; i++)
                            {
                                CurrentCommand.parameters[i - 2] = input[i];
                            }
                        }
                    }
                    else
                    {
                        CurrentCommand.Option = null;
                        if (input.Length > 1)
                        {
                            CurrentCommand.parameters = new string[input.Length];
                            for (int i = 1; i < input.Length; i++)
                            {
                                CurrentCommand.parameters[i - 1] = input[i];
                            }
                        }
                    }
                    if (CurrentCommand.Execute() == false)
                    {
                        Console.WriteLine("Error");
                    }
                }
                else
                {
                    Console.WriteLine("Command " + input[0] + " not found");
                }
            }
        }
    }
}
