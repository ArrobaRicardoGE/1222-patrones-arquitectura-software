using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherCalculator
{
    public class Client
    {
        public void Run()
        {
            Console.WriteLine("Insertar numero");
            float a = float.Parse(Console.ReadLine());

            Invoker calculator = new Invoker();
            Receiver r = new Receiver(a);
            Command c = new ConcreteCommand(r); 

            while(true)
            {
                Console.WriteLine("Insertar operacion");
                char o = char.Parse(Console.ReadLine());
                Console.WriteLine("Insertar numero");
                float b = float.Parse(Console.ReadLine());
                Console.WriteLine(calculator.ExecuteCommand(c, b, o));
            }
        }
       

    }
}
