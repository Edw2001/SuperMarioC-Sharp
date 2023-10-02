using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class GroundBlock : Block
    {
        public GroundBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base (nSprite, nSheetSize, nPos)
        {
        }
    }
}

