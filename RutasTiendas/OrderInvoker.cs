using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    static class OrderInvoker
    {
        public static void Execute(OrderCommand cmd)
        {
            cmd.Execute(); 
        }

        public static void Undo(OrderCommand cmd)
        {
            cmd.Undo(); 
        }
    }
}
