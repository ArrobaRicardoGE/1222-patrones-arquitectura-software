using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    class UndoCommand : OrderCommand
    {
        public UndoCommand(Order _order)
        {
            order = _order; 
        }
        public override void Execute()
        {
            var cmd = order.history.Peek();
            if (cmd == null) return;
            order.history.Pop();
            cmd.Undo();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
