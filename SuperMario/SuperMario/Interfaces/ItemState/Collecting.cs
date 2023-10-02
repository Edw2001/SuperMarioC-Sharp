using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.ItemState
{
    public class Collecting : IItemState
    {
        public Collecting(Item nItem) : base(nItem)
        {
            CurrState = State.COLLECTING;
        }
    }
}
