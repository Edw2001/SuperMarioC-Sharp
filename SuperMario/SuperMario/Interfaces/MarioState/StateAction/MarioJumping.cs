using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using Microsoft.Xna.Framework.Input;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction
{
    public class MarioJumping : IMarioState
    {
        private int startDir = 0;
        public MarioJumping(Mario nMario): base(nMario)
        {

        }
        public MarioJumping(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }

        public override void Enter()
        {
            CollisionManager.getCM().RegMoving(mario);
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.JUMPSUPER;
            currActionState = ActionState.JUMPING;
            mario.IsVis = true;
            mario.Velocity = new Vector2(mario.Velocity.X, -10);
            mario.Acceleration = new Vector2(0, (float)0.25);
            mario.Frame = 1;
            mario.AutoFrame = false;
            
        }
        public override void Update()
        {
            if (mario.Velocity.Y >= 0)
                ChangeActionState((int)ActionState.FALLING);
        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }

        
        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.RUNNING:
                    mario.Velocity = new Vector2(mario.GetDirection(), mario.Velocity.Y);
                    break;
                case ActionState.WALKING:
                    mario.Velocity = new Vector2(mario.GetDirection(), mario.Velocity.Y);
                    break;
                case ActionState.IDLE:
                    mario.Velocity = new Vector2(0, mario.Velocity.Y);
                    break;
                case ActionState.FALLING:
                    Exit();
                    mario.StateAction = new MarioFalling(mario, previousActionState);
                    break;
                case ActionState.POLESLIDE:
                    Exit();
                    mario.StateAction = new MarioPoleslide(mario, currActionState);
                    break;
            }
        }
    }
}
