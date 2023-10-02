using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;

namespace SprintZeroSpriteDrawing.Interfaces.Entitiy
{
    public enum Direction
    {
        TOP,
        SIDE,
        BOTTOM,
        ANY,
        LEFT,
        RIGHT,
        NULL
    }

    public enum CType
    {
        UNCOLLIDEABLE,
        AVATAR_SMALL,
        AVATAR_LARGE,
        AVATAR_STAR,
        INVISIBLE,
        BOUNDRY,
        FLAG,
        CASTLE,
        FRIENDLY,
        NEUTRAL,
        ENEMY,
        PIRANA,
        LEVELUP,
        ONEUP,
        FLOWER,
        STAR,
        PROJECTILE,
        PIPE_ENTER,
        BOMB_PWR,
        BOW_PWR,
        SWORD_PWR,
        SHIELD_PWR,
        HOOKSHOT_PWR,
        BOMB,
        MOVBOMB,
        EXPBOMB,
        SHOARROW,
        COLARROW,
        SHOHOOKSHOT,
        COLHOOKSHOT
        }

    public class ICollideable : IRBody
    {
        //make this into a switch case later with method
        public List<Tuple<ICommand, Direction, CType>> CollisionResponse { get; set; }
        public CType CollideableType { get; set; }
        public Rectangle BBox { get; set; }
        private Texture2D _texture;

        public bool CollideMaybe { get; set; }

        public ICollideable(Texture2D nSprite, Vector2 nPos, Rectangle nBBox) : base(nSprite, nPos)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
        }
        public ICollideable(Texture2D nSprite, Vector2 nPos) : base(nSprite, nPos)
        {
            BBox = new Rectangle((int)(nPos.X - nSprite.Width), (int)(nPos.Y - nSprite.Height), (int)(nSprite.Width), (int)(nSprite.Height));
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
        }
        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            BBox = new Rectangle((int)(nPos.X - nSprite.Width / nSheetSize.X), (int)(nPos.Y - nSprite.Height / nSheetSize.Y), (int)(nSprite.Width / nSheetSize.X), (int)(nSprite.Height / nSheetSize.Y));
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
        }

        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox) : base(nSprite, nSheetSize, nPos)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
        }

        public ICollideable(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration, Rectangle nBBox) : base(nSprite, nSheetSize, nPos, acceleration)
        {
            BBox = nBBox;
            CollisionResponse = new List<Tuple<ICommand, Direction, CType>>();
            _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
        }
        public override void Draw(SpriteBatch batch)
        {
            Draw(batch, SpriteEffects.None);
        }

        public void UpdateBBox()
        {
            BBox = new Rectangle((int)(Pos.X - Sprite.Width / SheetSize.X), (int)(Pos.Y - Sprite.Height / SheetSize.Y), (int)(Sprite.Width / SheetSize.X), (int)(Sprite.Height / SheetSize.Y));
        }
        public Rectangle KExtendedBBox()
        {
            float x = BBox.X;
            float y = BBox.Y;
            float height = BBox.Height + Math.Abs(Velocity.Y);
            float width = BBox.Width + Math.Abs(Velocity.X);

            if (Velocity.X < 0)
            {
                x += Velocity.X;
            }
            if (Velocity.Y < 0)
            {
                y += Velocity.Y;
            }
            return new Rectangle((int)x, (int)y, (int)width, (int)height);
        }
        public override void Update()
        {
            if (CollideableType != CType.UNCOLLIDEABLE)
                CollisionManager.getCM().DeRegEntity(this);
            base.Update();
            CollideMaybe = false;
            if (Velocity.X != 0 || Velocity.Y != 0)
            {
                BBox = new Rectangle((int)(Pos.X - Sprite.Width / SheetSize.X),
                    (int)(Pos.Y - Sprite.Height / SheetSize.Y), (int)(Sprite.Width / SheetSize.X),
                    (int)(Sprite.Height / SheetSize.Y));
            }

            if (CollideableType != CType.UNCOLLIDEABLE)
                CollisionManager.getCM().RegEntity(this);
        }

        public override void Draw(SpriteBatch batch, SpriteEffects effects)
        {
            base.Draw(batch, effects);


            Color color = Color.Aqua;
            switch (CollideableType)
            {
                case CType.FRIENDLY:
                case CType.FLOWER:
                case CType.LEVELUP:
                    color = Color.Green;
                    break;
                case CType.ENEMY:
                    color = Color.Red;
                    break;
                case CType.NEUTRAL:
                case CType.INVISIBLE:
                    color = Color.Blue;
                    break;
                case CType.AVATAR_LARGE:
                case CType.AVATAR_STAR:
                case CType.AVATAR_SMALL:
                    color = Color.Yellow;
                    break;
            }
            if (Game1.DEBUGBBOX)
            {
                batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Top, BBox.Width, 1), color);
                batch.Draw(_texture, new Rectangle(BBox.Right, BBox.Top, 1, BBox.Height), color);
                batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Bottom, BBox.Width, 1), color);
                batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Top, 1, BBox.Height), color);
                if (CollideMaybe)
                {
                    batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Top, BBox.Width, 5), color);
                    batch.Draw(_texture, new Rectangle(BBox.Right, BBox.Top, 5, BBox.Height), color);
                    batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Bottom, BBox.Width, 5), color);
                    batch.Draw(_texture, new Rectangle(BBox.Left, BBox.Top, 5, BBox.Height), color);
                }
            }
        }

        public void ForceDeReg(int dereg)
        {
            Game1.SpriteList.Remove(this);
            CollisionManager.getCM().DeRegEntity(this);
            CollisionManager.getCM().DeRegMoving(this);
        }
        public void Floored(int dereg)
        {
            Velocity = new Vector2(Velocity.X, 0);
        }
        public void BounceFloored(int dereg)
        {
            Velocity = new Vector2(Velocity.X, -Velocity.Y);
        }
        public void Walled(int dereg)
        {
            Velocity = new Vector2(0, Velocity.Y);
        }
        public void BounceWalled(int dereg)
        {
            Velocity = new Vector2(-Velocity.X, Velocity.Y);
        }
    }
}
