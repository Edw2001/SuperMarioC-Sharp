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
    public class LinkSword : IMarioState
    {
        public LinkSword(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.POWERUP;
            mario.CollideableType = CType.AVATAR_SMALL;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.SWORD;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(2, 5);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().swordLinkSpriteSheet);
            mario.UpdateBBox();
        }
        public override void Update()
        {

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
                case PowerupState.FIRE:
                    Exit();
                    mario.StatePowerup = new FireMario(mario);
                    break;
                case PowerupState.SHIELD:
                    Exit();
                    mario.StatePowerup = new LinkShield(mario);
                    break;
            }
        }
    }
}
