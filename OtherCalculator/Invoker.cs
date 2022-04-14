using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherCalculator
{
    public class Invoker
    {
        public float ExecuteCommand(Command command, float num, char operando)
        {
            return command.Execute(num, operando); 
        }
    }
}
