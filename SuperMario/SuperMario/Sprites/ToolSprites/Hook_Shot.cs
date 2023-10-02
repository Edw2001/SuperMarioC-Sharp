using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ToolSprites
{
    public class Hook_Shot : Tool
    {
        public Hook_Shot(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.SIDE, CType.AVATAR_SMALL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.SIDE, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.TOP, CType.AVATAR_SMALL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.TOP, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.BOTTOM, CType.AVATAR_SMALL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.BOTTOM, CType.AVATAR_LARGE));
        }
        public override void Update()
        {
            base.Update();
        }
        public virtual void Collect(int collect)
        {
            CollideableType = CType.UNCOLLIDEABLE;
            Game1.SpriteList.Remove(this);
            Hook_Shot_Pool.GetHook_ShotPool().Collect(this);
        }
        public override void Draw(SpriteBatch batch)
        {
            SpriteEffects effects = Mario.GetMario().GetDirection() < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;



            base.Draw(batch, effects);
        }
    }
}