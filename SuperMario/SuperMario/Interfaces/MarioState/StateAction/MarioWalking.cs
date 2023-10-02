using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using SprintZeroSpriteDrawing.Collision.CollisionManager;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction
{
    public class MarioWalking: IMarioState
    {
        public MarioWalking(Mario nMario): base(nMario)
        {

        }
        public MarioWalking(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }

        public override void Enter()
        {
            int direction = 4; 
            CollisionManager.getCM().RegMoving(mario);
            currActionState = ActionState.WALKING;
            mario.IsVis = true;
            if (mario.effects == SpriteEffects.FlipHorizontally)
            {
                direction *= -1;
            }
            mario.Velocity = new Vector2((float)(direction), mario.Velocity.Y);
            mario.Acceleration = new Vector2(0, (float)0.1);
            mario.AutoFrame = true;
            mario.Frame = 3;
            mario.StartFrame = 3;
            mario.LastFrame = 5;
           
        }
        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.IDLE:
                    Exit();
                    mario.StateAction = new MarioIdle(mario, currActionState);
                    break;
                case ActionState.JUMPING:
                    Exit();
                    mario.StateAction = new MarioJumping(mario, currActionState);
                    break;
                case ActionState.RUNNING:
                    Exit();
                    mario.StateAction = new MarioRunning(mario, currActionState);
                    break;
            }
        }
    }
}
