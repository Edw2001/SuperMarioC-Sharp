using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Commands
{
    internal class IntCmd : ICommand
    {
        public IntCmd(KeyValuePair<Action<int>, int> nCommand) : base(nCommand) { }

        public override void Execute()
        {
            //This line is a living hell, sorry ;-; {it executes a casted function pointer with parameter value}
            ((KeyValuePair<Action<int>, int>)Ref).Key(((KeyValuePair<Action<int>, int>)Ref).Value);
        }
    }
}
