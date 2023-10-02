using SprintZeroSpriteDrawing.Sprites.SpriteFactory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.ProjectileState;

namespace SprintZeroSpriteDrawing.Sprites.ProjectileSprites
{
    public class FireballPool
    {
        public Queue<Fireball> fireballs = new Queue<Fireball>();
        public readonly int MAX = 2;
        public Vector2 position;


        private static FireballPool _fireballPool;
        public static FireballPool GetFireballPool()
        {
            if (_fireballPool == null)
            {
                _fireballPool = new FireballPool((Fireball)ProjectileSpriteFactory.getSpriteFactory().CreateFireball(Mario.GetMario().Pos));
            }
            return _fireballPool;
        }

        public FireballPool(Fireball fireball)
        {
            fireballs.Enqueue(fireball);
            fireballs.Enqueue((Fireball)ProjectileSpriteFactory.getSpriteFactory().CreateFireball(Mario.GetMario().Pos));
        }

        public void Release(Fireball fireball)
        {
            fireballs.Enqueue(fireball);
        }

        
        public Fireball Get()
        {
            Fireball fireball;
            if (fireballs.Count > 0)
            {
                fireball = fireballs.Dequeue();
                fireball.Pos = new Vector2(Mario.GetMario().Pos.X + (Mario.GetMario().GetDirection() * 25), Mario.GetMario().Pos.Y - 48);
                return fireball; 
            }
            else
            {
                return null;
            }
        }
    }
}
