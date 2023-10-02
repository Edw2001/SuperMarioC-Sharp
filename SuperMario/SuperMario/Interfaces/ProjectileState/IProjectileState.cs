using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ProjectileState
{
    public enum State
    {
        APPEAR,
        DISAPPEAR
    }
    public class IProjectileState
    {
        protected Projectile projectile;
        public State CurrState { get; set; }

        public IProjectileState(Projectile nProjectile)
        {
            projectile = nProjectile;
            Enter();
        }

        public virtual void Update() { }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void ChangeState(int state) { }
    }
}
