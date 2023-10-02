using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem
{
    public class Bow : Item
    {
        public Bow(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.BOW_PWR;
        }
    }
}
