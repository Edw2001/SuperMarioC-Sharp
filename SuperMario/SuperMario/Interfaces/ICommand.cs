using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces
{
    public class ICommand
    {
        protected object Ref;

        public ICommand(object nRef) {
            Ref = nRef;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException("Implement this command's Execute method");
        }
    }
}
