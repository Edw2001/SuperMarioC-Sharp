using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction
{
    public class MarioIdle : IMarioState
    {
        public MarioIdle(Mario nMario) : base(nMario)
        {

        }
        public MarioIdle(Mario nMario, ActionState nState): base(nMario, nState)
        {

        }
        public override void Enter()
        {

            //CollisionManager.getCM().DeRegMoving(mario);
            mario.SheetSize = new Vector2(2, 3);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().normalLinkSpriteSheet);
            currActionState = ActionState.IDLE;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, mario.Velocity.Y);
            mario.Acceleration = new Vector2(0, (float) .1);
            mario.StartFrame = 0;
            mario.Frame = 0;
            mario.LastFrame = 1;
            mario.AutoFrame = false;
        }

        public override void ChangeActionState(int state)
        {
            switch((ActionState)state)
            {
                case ActionState.JUMPING:
                    Exit();
                    mario.StateAction = new MarioJumping(mario, currActionState);
                    break;
                case ActionState.WALKING:
                    Exit();
                    mario.StateAction = new MarioWalking(mario, currActionState);
                    break;
                case ActionState.CROUCHING:
                    Exit();
                    mario.StateAction = new MarioCrouching(mario, currActionState);
                    break;
                case ActionState.STAB:
                    mario.StateAction = new LinkStab(mario, currActionState);
                    break;
                case ActionState.SHIELDED:
                    mario.StateAction = new LinkShielded(mario, currActionState);
                    break;
            }
        }

    }
}
