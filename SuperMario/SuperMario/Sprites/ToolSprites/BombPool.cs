using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Sprites.SpriteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.ToolState;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class BombPool
    {
        public Queue<Bomb> bombs = new Queue<Bomb>();
        public static int BombsMax = 3;
        public static Vector2 position;
        private static BombPool _bombPool;
        public BombPool(Bomb bomb)
        {

        }
        public static BombPool GetBombPool()
        {
            if (_bombPool == null)
            {
                _bombPool = new BombPool((Bomb)ItemSpriteFactory.getFactory().CreateBomb(position));
            }
            return _bombPool;
        }
        public void RefillPool()
        {
            while (bombs.Count < BombsMax)
                bombs.Enqueue((Bomb)ItemSpriteFactory.getFactory().CreateBomb(position));
        }
        public Bomb Get()
        {
            Bomb bomb;
            if (bombs.Count > 0)
            {
                bomb = bombs.Dequeue();
                if (Mario.GetMario().GetDirection() > 0)
                {
                    bomb.Pos = new Vector2(Mario.GetMario().Pos.X, Mario.GetMario().Pos.Y - 56);
                    bomb.Velocity = new Vector2(5, -1);
                }
                else
                {
                    bomb.Pos = new Vector2(Mario.GetMario().Pos.X, Mario.GetMario().Pos.Y - 56);
                    bomb.Velocity = new Vector2(-5, -1);
                }

                return bomb;
            }
            else
            {
                return null;
            }
        }
    }
}

