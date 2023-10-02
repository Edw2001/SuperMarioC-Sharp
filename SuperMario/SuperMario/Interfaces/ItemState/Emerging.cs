using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.ItemState
{
    public class Emerging : IItemState
    {
        public Emerging(Item nItem) : base(nItem)
        {
            CurrState = State.EMERGING;
        }
        public override void Enter()
        {
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.ITEM;
            item.Velocity = new Vector2(0, (float)-2);
            item.Acceleration = new Vector2(0, (float).1);
            CollisionManager.getCM().RegMoving(item);
        }
        public override void Exit()
        {
        }
        public override void Update()
        {
            base.Update();
            if(item.Velocity.Y >= 2)
                ChangeState((int)State.IDLE);
        }
        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }
    }
}
