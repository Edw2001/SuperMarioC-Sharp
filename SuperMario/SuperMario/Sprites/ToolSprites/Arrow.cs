using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.EnemyState;
using SprintZeroSpriteDrawing.Interfaces.ToolState;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.ToolSprites
{
    public class Arrow : Tool
    {
        private SpriteEffects effects;
        public Arrow(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.SHOARROW;
            effects = Mario.GetMario().GetDirection() < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch, effects);
        }
    }
}
