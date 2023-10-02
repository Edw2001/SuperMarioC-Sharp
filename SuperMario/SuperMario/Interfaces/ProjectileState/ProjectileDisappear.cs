using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ProjectileState
{
    public class ProjectileDisappear : IProjectileState
    {
        public ProjectileDisappear(Projectile nProjectile) : base(nProjectile)
        {
        }

        public override void Enter()
        {
            CurrState = State.DISAPPEAR;
            Game1.SpriteList.Remove(projectile);
            CollisionManager.getCM().DeRegEntity(projectile);
            CollisionManager.getCM().DeRegMoving(projectile);
            projectile.IsVis = false;
            projectile.Velocity = new Vector2(0, 0);
            projectile.Acceleration = new Vector2(0, 0);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.APPEAR:
                    Exit();
                    projectile.State = new ProjectileAppear(projectile);
                    break;
            }
        }
    }
}
