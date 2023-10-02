using System;
using System.Collections.Generic;
using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class SuperMushroom : Item
    {
        private bool emerge = false;
        public SuperMushroom(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.LEVELUP;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 1)), Direction.SIDE, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Floored, 1)), Direction.BOTTOM, CType.NEUTRAL));

        }
        public override void Update()
        {
            base.Update();
            
            if (State.CurrState == Interfaces.ItemState.State.EMERGING && !emerge)
            {
                if (Mario.GetMario().Pos.X - Pos.X > 0)
                {
                    Velocity = new Vector2(2, 0);
                    Acceleration = new Vector2(0, (float).065);
                }
                else {
                    Velocity = new Vector2(-2, 0);
                    Acceleration = new Vector2(0, (float).065);
                }
                CollisionManager.getCM().RegMoving(this);
                emerge = true;
            }
        }
    }
}
