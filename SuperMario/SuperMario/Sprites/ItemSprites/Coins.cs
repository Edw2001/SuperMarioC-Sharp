using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Music_SoundEffects;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class Coins : Item
    {
        public Coins(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {

        }
        public override void Update()
        {
            base.Update();
            if (State.CurrState == Interfaces.ItemState.State.EMERGING && Velocity.Y >= 0)
            {
                State.CurrState = Interfaces.ItemState.State.COLLECTING;
                var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.COIN;
            }
        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }
    }
}
