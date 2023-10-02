using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZeroSpriteDrawing.Interfaces.Entitiy
{

    /// <summary>
    /// This is a moving, animated, sprite class that is
    /// used to build the most complicated and visually interesting
    /// sprites, such as the main character and complex enemies
    /// </summary>
    public class ITile : ISprite
    {
        public bool IsVis { get; set; }
        public Texture2D Sprite { get; set; }
        public Vector2 Pos { get; set; }

        #region Framing and Animation
        public int Frame { get; set; }
        public int Subframe { get; set; }
        public int SubframeLimit { get; set; }
        public bool AutoFrame { get; set; }
        public int StartFrame { get; set; }
        public int LastFrame { get; set; }
        public Vector2 SheetSize { get; set; }
        public Color tint { get; set; }
        private Vector2 FrameSize;
        #endregion
        public ITile(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos)
        {
            SubframeLimit = 20;
            AutoFrame = true;
            IsVis = true;
            Sprite = nSprite;
            Pos = nPos;
            SheetSize = nSheetSize;
            StartFrame = 0;
            LastFrame = (int)(SheetSize.X * SheetSize.Y);
            tint = Color.White;
            if (nSprite != null)
                FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }
        public ITile(Texture2D nSprite, Vector2 nPos)
        {
            SubframeLimit = 20;
            AutoFrame = true;
            IsVis = true;
            Sprite = nSprite;
            Pos = nPos;
            SheetSize = new Vector2(1, 1);
            StartFrame = 0;
            LastFrame = (int)(SheetSize.X * SheetSize.Y);
            tint = Color.White;
            if (nSprite != null)
                FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }
        public void SetSprite(Texture2D nSprite)
        {
            Sprite = nSprite;
            FrameSize = new Vector2(nSprite.Width / SheetSize.X, nSprite.Height / SheetSize.Y);
        }
        public int NextFrame()
        {
            return Frame++;
        }
        public virtual void Draw(SpriteBatch batch)
        {
            if (IsVis)
            {
                Rectangle Rect = new Rectangle((int)(Frame % (int)SheetSize.X * FrameSize.X), (int)(Frame / (int)SheetSize.X * FrameSize.Y),
                    (int)FrameSize.X, (int)FrameSize.Y);
                batch.Draw(Sprite, Vector2.Add(Pos, -FrameSize), Rect, tint, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            }
        }
        public virtual void Draw(SpriteBatch batch, SpriteEffects effects)
        {
            if (IsVis)
            {
                Rectangle Rect = new Rectangle((int)(Frame % (int)SheetSize.X * FrameSize.X), (int)(Frame / (int)SheetSize.X * FrameSize.Y),
                    (int)FrameSize.X, (int)FrameSize.Y);
                batch.Draw(Sprite, Vector2.Add(Pos, -FrameSize), Rect, tint, 0, new Vector2(0, 0), 1, effects, 0);
            }
        }
        virtual public void Update()
        {
            if (AutoFrame)
                Subframe++;
            if (Subframe >= SubframeLimit)
            {
                Subframe = 0;
                Frame++;
                if (Frame >= LastFrame)
                    Frame = StartFrame;
            }
        }

        #region movement
        public void Move(Vector2 delta)
        {
            Pos = new Vector2(Math.Max(Math.Min(Pos.X + delta.X, Game1.LEVELSIZE.X), 0), Math.Max(Math.Min(Pos.Y + delta.Y, Game1.LEVELSIZE.Y), 0));
        }
        public void MoveX(int delta)
        {
            Pos = Vector2.Add(Pos, new Vector2(delta, 0));
        }
        public void MoveY(int delta)
        {
            Pos = Vector2.Add(Pos, new Vector2(0, delta));
        }
        #endregion
    }
}
