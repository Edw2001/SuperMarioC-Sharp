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
    public class BlockBumping : IBlockState
    {
        private Vector2 anchor;

        public BlockBumping(Block nBlock) : base(nBlock)
        {
        }
        public BlockBumping(Block nBlock, List<Item> nInventory) : base(nBlock, nInventory)
        {
        }

        public override void Enter()
        {
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.BUMP;
            CurrState = State.BUMPING;
            block.IsVis = true;
            anchor = block.Pos;
            block.Velocity = new Vector2(0,-2);
            block.Acceleration = new Vector2(0, (float)0.065);
            if (Inventory.Count > 0)
            {
                Game1.SpriteList.Add(Inventory[0]);
                Inventory[0].ChangeState((int)ItemState.State.EMERGING);
                CollisionManager.getCM().RegEntity(Inventory[0]);
                Inventory.RemoveAt(0);
            }
        }

        public override void Exit()
        {
            block.Pos = anchor;
        }
        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.TAPPED:
                    Exit();
                    block.State = new BlockTapped(block, Inventory);
                    break;
                case State.UNTAPPED:
                    Exit();
                    block.State = new BlockUntapped(block, Inventory);
                    break;
            }
        }

        public override void Update()
        {
            //reminder that (0,0) is top right
            if(Inventory.Count == 0 && block.Pos.Y > anchor.Y)
                ChangeState((int)State.TAPPED);
            else if(block.Pos.Y > anchor.Y)
                ChangeState((int)State.UNTAPPED);
            //we need to add logic to release an item
        }
    }
}
