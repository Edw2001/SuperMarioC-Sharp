using System;
using System.Collections.Generic;
using System.Threading;
using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class PiranaPlant : Item
    {
        private bool emerged = false;
        private int timer = 0;
        private Vector2 anchor = Vector2.Zero;
        public PiranaPlant(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.PIRANA;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Retire, 0)), Direction.TOP, CType.PROJECTILE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Retire, 0)), Direction.BOTTOM, CType.PROJECTILE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Retire, 0)), Direction.SIDE, CType.PROJECTILE));
        }
        public override void Update()
        {
            base.Update();
            State.Update();
            if (State.CurrState == Interfaces.ItemState.State.EMERGING && !emerged)
            {
                anchor = Pos;
                emerged = true;
                CollisionManager.getCM().RegMoving(this);
                Velocity = new Vector2(0, -2);
                Acceleration = new Vector2(0, (float).1);
            }
            else if (State.CurrState == Interfaces.ItemState.State.IDLE)
            {
                timer++;
                Pos = anchor;
                Velocity = new Vector2(0, 0);
                Acceleration = new Vector2(0, 0);
                if (timer >= 200)
                {
                    timer = 0;
                    Collect(0);
                }
            }
        }
        public void Retire(int remove)
        {
            Collect(0);
        }
    }
}
