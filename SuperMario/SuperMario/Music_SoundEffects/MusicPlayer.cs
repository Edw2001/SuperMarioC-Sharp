using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace SprintZeroSpriteDrawing.Music_SoundEffects
{
    public class MusicPlayer
    {
        Song overworldMusic;
        Song starmanMusic;
        Song underworldMusic;
        Song dungeonMusic;
        Song introMusic;
       

        public enum Songs
        {
            OVERWORLD,
            UNDERWORLD,
            STARMAN,
            DUNGEON,
            INTRO
        }
        private static MusicPlayer _musicPlayer;

        public static MusicPlayer GetMusicPlayer()
        {
            if (_musicPlayer == null)
            {
                _musicPlayer = new MusicPlayer();
            }
            return _musicPlayer;
        }

        public void LoadSongs(ContentManager content)
        {
            overworldMusic = content.Load<Song>("Music/MainThemeOverworld");
            starmanMusic = content.Load<Song>("Music/Starman");
            underworldMusic = content.Load<Song>("Music/Underworld");
            introMusic = content.Load<Song>("LOZMusic/Intro");
            dungeonMusic = content.Load<Song>("LOZMusic/Dungeon");
        }
        public void PlaySong()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.IsMuted = false;
            MediaPlayer.Play(introMusic); 
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
        }
        public void ChangeSong(int song)
        {
            MediaPlayer.Stop();
            switch(song)
            {
                case (int)Songs.OVERWORLD:
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(overworldMusic);
                    break;
                case (int)Songs.UNDERWORLD:
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(underworldMusic);
                    break;
                case (int)Songs.STARMAN:
                    MediaPlayer.Play(starmanMusic);
                    break;
                case (int)Songs.INTRO:
                    MediaPlayer.Play(introMusic);
                    break;
                case (int)Songs.DUNGEON:
                    MediaPlayer.Play(dungeonMusic);
                    break;
            }
        }

       
        public void Mute(int mute)
        {
            MediaPlayer.IsMuted = !MediaPlayer.IsMuted;
            
            if(SoundEffect.MasterVolume == 0.0f)
            {
                SoundEffect.MasterVolume = 1.0f;
            }
            else
            {
                SoundEffect.MasterVolume = 0.0f;
            }
        }

       
    }
}
