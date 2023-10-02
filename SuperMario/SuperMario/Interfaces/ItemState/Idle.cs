using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.ItemState
{
    public class Idle : IItemState
    {
        public Idle(Item nItem) : base(nItem)
        {
            CurrState = State.IDLE;
        }
    }
}
