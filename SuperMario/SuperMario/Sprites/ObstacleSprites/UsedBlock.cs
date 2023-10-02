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
    public class UsedBlock : Block
    {
        public UsedBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
        }
    }
}