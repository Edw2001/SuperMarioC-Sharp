using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Music_SoundEffects;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class FireMario : IMarioState
    {
        public FireMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.POWERUP;
            mario.CollideableType = CType.AVATAR_LARGE;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.FIRE;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(2, 3);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().bombLinkSpriteSheet);
            mario.UpdateBBox();
            mario.fireBall = true;
        }

        public override void Exit()
        {
            mario.fireBall = false;
        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }

        public override void ChangePowerupState(int state)
        {
            switch ((PowerupState)state)
            {
                case PowerupState.DEAD:
                    Exit();
                    mario.StatePowerup = new SmallMario(mario);
                    break;
                case PowerupState.SMALL:
                    Exit();
                    mario.StatePowerup = new SmallMario(mario);
                    break;
                case PowerupState.BIG:
                    Exit();
                    mario.StatePowerup = new BigMario(mario);
                    break;
            }
        }
    }
}