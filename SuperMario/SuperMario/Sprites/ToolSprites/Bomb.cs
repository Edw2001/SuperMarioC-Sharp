using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.ProjectileState;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class Bomb : Tool
    {
        public Bomb(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
        }
    }
}
