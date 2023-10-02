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
    public class MarioCrouching : IMarioState
    {
        public MarioCrouching(Mario nMario) : base(nMario)
        {

        }
        public MarioCrouching(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }

        public override void Enter()
        {
            CollisionManager.getCM().RegMoving(mario);
            currActionState = ActionState.CROUCHING;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, 2);
            mario.Acceleration = new Vector2(0, 0);
            if(mario.StatePowerup.currPowerupState != PowerupState.SMALL)
            {
                mario.Frame = 6;
                mario.AutoFrame = false;
            }
             
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
            }
        }
    }
}