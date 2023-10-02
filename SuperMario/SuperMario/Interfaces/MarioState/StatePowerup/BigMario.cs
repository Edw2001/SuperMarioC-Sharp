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
    public class BigMario : IMarioState
    {
        public BigMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.POWERUP;
            mario.CollideableType = CType.AVATAR_LARGE;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.BIG;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(2, 3);
            mario.SetSprite(Mario.neutralBowLinkSpriteSheet);
            mario.UpdateBBox();
        }
        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }

        public override void ChangePowerupState(int state)
        {
            switch ((PowerupState)state)
            {
                case PowerupState.SMALL:
                    Exit();
                    mario.StatePowerup = new SmallMario(mario);
                    break;
                case PowerupState.FIRE:
                    Exit();
                    mario.StatePowerup = new FireMario(mario);
                    break;
                case PowerupState.DEAD:
                    Exit();
                    mario.StatePowerup = new DeadMario(mario);
                    break;
                case PowerupState.SHIELD:
                    Exit();
                    mario.StatePowerup = new LinkShield(mario);
                    break;
                case PowerupState.SWORD:
                    Exit();
                    mario.StatePowerup = new LinkSword(mario);
                    break;
            }
        }
    }
}