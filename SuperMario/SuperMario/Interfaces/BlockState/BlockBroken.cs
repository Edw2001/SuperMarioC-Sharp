using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Music_SoundEffects;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockBroken : IBlockState
    {
        public BlockBroken(Block nBlock) : base(nBlock)
        {
        }
        public BlockBroken(Block nBlock, List<Item> nInventory) : base(nBlock, nInventory)
        {
        }

        public override void Enter()
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds((int)SoundEffectPlayer.Sounds.BREAKBLOCK);
            CurrState = State.BROKEN;
            Game1.SpriteList.Remove(block);
            CollisionManager.getCM().DeRegEntity(block);
            Game1.SpriteList.Add((Block)(BlockSpriteFactory.getFactory().CreateBrokenBlock(block.Pos)));
        }


        public override void Exit()
        {
            base.Exit();
        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }
    }
}
