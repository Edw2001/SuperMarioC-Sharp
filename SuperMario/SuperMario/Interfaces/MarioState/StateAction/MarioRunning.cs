using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Collision.CollisionManager;


namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction
{
    public class MarioRunning: IMarioState
    {
        public MarioRunning(Mario nMario): base(nMario)
        {

        }
        public MarioRunning(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }
        public override void Enter()
        {
            CollisionManager.getCM().RegMoving(mario);
            currActionState = ActionState.RUNNING;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, (float).1);
            mario.Acceleration = new Vector2(0, 0);
            mario.StartFrame = 2;
            mario.Frame = 2;
            mario.LastFrame = 2;
            mario.AutoFrame = false;
        }

        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.IDLE:
                    Exit();
                    mario.StateAction = new MarioIdle(mario, currActionState);
                    break;
                case ActionState.WALKING:
                    Exit();
                    mario.StateAction = new MarioWalking(mario, currActionState);
                    break;
                case ActionState.JUMPING:
                    Exit();
                    mario.StateAction = new MarioJumping(mario, currActionState);
                    break;
            }
        }
    }
}
