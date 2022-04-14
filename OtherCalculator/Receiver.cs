using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherCalculator
{
    public class Receiver
    {

        private float resultado; 
        public Receiver(float _val)
        {
            resultado = _val; 
        }

        public float Action(float num, char operando)
        {
            if (operando == '+') return Sumar(num);
            else if (operando == '-') return Restar(num);
            else if (operando == '*') return Multiplicar(num);
            throw new NotImplementedException();
        }
        public float Sumar(float num)
        {
            resultado += num;
            return resultado;
        }

        public float Restar(float num)
        {
            resultado -= num;
            return resultado;
        } 

        public float Multiplicar(float num)
        {
            resultado *= num;
            return resultado;
        }
    }
}
