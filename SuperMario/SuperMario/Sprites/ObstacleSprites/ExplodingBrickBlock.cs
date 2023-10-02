using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    internal class ExplodingBrickBlock : Block
    {
        public ExplodingBrickBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            
        }


        public ExplodingBrickBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 velocity, Vector2 acceleration) : base(nSprite, nSheetSize, nPos)
        {
            Velocity = velocity;
            Acceleration = acceleration;
            CollideableType = CType.UNCOLLIDEABLE;
        }

        public override void Update()
        {
            base.Update();
            
        }


    }
}
