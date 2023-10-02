using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.EnemyState;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.States.EnemyState;

namespace SprintZeroSpriteDrawing.Sprites.EnemySprites
{
    public class GreenKoopa : Enemy
    {
        public GreenKoopa(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            Frame = 2;
            StartFrame = 0;
            LastFrame = 2;
            State = new EnemyMoving(this);
        }
        public override void Damage(int kill)
        {
            State = new ShellIdle(this);
        }
        public override void Draw(SpriteBatch batch)
        {
            SpriteEffects effects = Velocity.X > 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            base.Draw(batch, effects);
        }
    }
}
