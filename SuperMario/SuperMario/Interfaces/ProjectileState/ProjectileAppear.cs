using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Music_SoundEffects;

namespace SprintZeroSpriteDrawing.Interfaces.ProjectileState
{
    public class ProjectileAppear : IProjectileState
    {
        public ProjectileAppear(Projectile nProjectile) : base(nProjectile)
        {

        }
 
        public override void Enter()
        {
            
            CurrState = State.APPEAR;
            projectile.IsVis = true;
            projectile.Velocity = new Vector2((float).4 * Mario.GetMario().GetDirection(), (float).5);
            projectile.Acceleration = new Vector2(0, (float).065); 
            Game1.SpriteList.Add(projectile);
            CollisionManager.getCM().RegEntity(projectile);
            CollisionManager.getCM().RegMoving(projectile);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.DISAPPEAR:
                    Exit();
                    projectile.State = new ProjectileDisappear(projectile);
                    break;
            }
        }
    }
}

