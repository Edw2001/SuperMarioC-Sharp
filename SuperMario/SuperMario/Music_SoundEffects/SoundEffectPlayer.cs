using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using System.ComponentModel;

namespace SprintZeroSpriteDrawing.Music_SoundEffects
{
    public delegate void delEventHandler(int sound);
    public class SoundEffectPlayer
    {
        public enum Sounds
        {
            ONEUP,
            BREAKBLOCK,
            BUMP,
            COIN,
            FIREBALL,
            FLAGPOLE,
            GAMEOVER,
            JUMPSMALL,
            JUMPSUPER,
            KICK,
            DIE,
            PAUSE,
            PIPEPOWERDOWN,
            POWERUP,
            ITEM,
            STAGECLEAR,
            STOMP,
            WARNING,
            ARROWSHOOT,
            BOMBBLOW,
            ENEMYHIT,
            GETITEM,
            GETRUPEE,
            SHIELD,
            SWORD

        }

        public int _trigger;
        List<SoundEffect> soundEffects = new List<SoundEffect>();

        public event delEventHandler PlaySoundEffect;

        private static SoundEffectPlayer _soundEffectPlayer;

        public static SoundEffectPlayer GetSoundEffectPlayer()
        {
            if(_soundEffectPlayer == null)
            {
                _soundEffectPlayer = new SoundEffectPlayer();
            }
            return _soundEffectPlayer;
        }

        public int Trigger 
        {
            set
            {
                if(value != _trigger)
                {
                    _trigger = value;
                   
                        PlaySoundEffect?.Invoke(_trigger);
                    _trigger = -1;
                }
            }
        }

        public void LoadSoundEffects(ContentManager content)
        {
            #region Mario Sound Effects
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/1-up"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/breakblock"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/bump"));
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/GetRupee"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/fireball"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/flagpole"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/gameover"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/jump-small"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/jump-super"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/kick"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/mariodie"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/pause"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/pipe_powerdown"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/powerup"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/powerup_appears"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/stageClear"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/stomp"));
            soundEffects.Add(content.Load<SoundEffect>("SoundEffects/warning"));
            #endregion
            #region Zelda Sound Effects
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/ArrowShoot"));
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/BombBlow"));
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/EnemyHit"));
            //soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/Game Over"));
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/GetItem"));
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/GetRupee"));
            //soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/Item"));
            //soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/Secret"));
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/Shield"));
            soundEffects.Add(content.Load<SoundEffect>("LOZSoundEffects/SwordSlash"));
            #endregion

        }
        public void PlaySounds(int sound)
        {
            
              SoundEffect temp;
            temp = soundEffects[sound];

            try
            { 
                temp.Play();    
            }
            catch (Exception e)
            {
               
                
            }
        }

        public void AddSounds(int sound)
        {

        }
    }
}
