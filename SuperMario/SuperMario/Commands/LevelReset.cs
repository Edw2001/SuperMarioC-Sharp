using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Commands
{
    internal class LevelReset : ICommand
    {
        public Game1 game1;
        public LevelReset(object nRef) : base(nRef)
        {
            game1 = (Game1)nRef;
        }
        public override void Execute()
        {
            game1.Restart();
        }
    }
}
