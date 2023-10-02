using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    internal class UGBrickBlock:Block
    {
        public UGBrickBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
        }

        public override void Update()
        {
            base.Update();
            if (State.CurrState == Interfaces.BlockState.State.TAPPED)
            {
                this.ChangeState((int)Interfaces.BlockState.State.UNTAPPED);
            }
        }
    }
}
