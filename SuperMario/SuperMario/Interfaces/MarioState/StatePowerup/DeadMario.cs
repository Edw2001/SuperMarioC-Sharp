using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Music_SoundEffects;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class DeadMario : IMarioState
    {
        public DeadMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
           
                var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.DIE;
           
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.DEAD;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, 0);
            mario.Acceleration = new Vector2(0, 0);
            mario.SheetSize = new Vector2(1, 1);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().DeadMarioSpriteSheet);
            mario.UpdateBBox();
            mario.Lives--;
        }

        public override void Update()
        {
            mario.ChangeAction((int)MarioState.ActionState.IDLE);
        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }

        public override void ChangePowerupState(int state)
        {
            switch ((PowerupState)state)
            {
                case PowerupState.BIG:
                    Exit();
                    mario.StatePowerup = new BigMario(mario);
                    break;
                case PowerupState.FIRE:
                    Exit();
                    mario.StatePowerup = new FireMario(mario);
                    break;
                case PowerupState.DEAD:
                    Exit();
                    mario.StatePowerup = new DeadMario(mario);
                    break;
            }
        }
    }
}