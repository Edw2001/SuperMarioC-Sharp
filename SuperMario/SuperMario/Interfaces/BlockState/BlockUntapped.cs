using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public class BlockUntapped : IBlockState
    {
        public BlockUntapped(Block nBlock) : base(nBlock)
        {
        }
        public BlockUntapped(Block nBlock, List<Item> nInventory) : base(nBlock, nInventory)
        {
        }

        public override void Enter()
        {
            CurrState = State.UNTAPPED;
            block.IsVis = true;
            block.Velocity = new Vector2(0,0);
            block.Acceleration = new Vector2(0, 0);
        }

        public override void ChangeState(int state)
        {
            switch ((State)state)
            {
                case State.BUMPING:
                    Exit();
                    block.State = new BlockBumping(block, Inventory);
                    break;
                case State.BROKEN:
                    Exit();
                    block.State = new BlockBroken(block, Inventory);
                    break;
            }
        }
    }
}
