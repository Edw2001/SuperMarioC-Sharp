using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Music_SoundEffects;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class SwitchedBlock : Block
    {
        public SwitchedBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
        }

        public override void Update()
        {
            base.Update();
            if (Game1.switched)
            {
                ChangeState((int)Interfaces.BlockState.State.BROKEN);
            }

           
        }
       
    }
}
