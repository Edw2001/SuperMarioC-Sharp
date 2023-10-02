using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class LinkShielded : IMarioState
    {
        public LinkShielded(Mario nMario) : base(nMario)
        {

        }

        public LinkShielded(Mario nMario, ActionState nState) : base(nMario, nState)
        {
            
        }

        public override void Enter()
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds((int)SoundEffectPlayer.Sounds.SHIELD);
            CollisionManager.getCM().RegMoving(mario);
            currActionState = ActionState.SHIELDED;
            mario.IsVis = true;
            mario.CollideableType = CType.NEUTRAL;
            mario.Velocity = new Vector2(0, (float).1);
            mario.Acceleration = new Vector2(0, (float).1);
            mario.AutoFrame = false;
            mario.Frame = 5;
            mario.StartFrame = 5;
            mario.LastFrame = 6;
        }
        public override void Update()
        {

        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
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

