using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.BlockState
{
    public enum State
    {
        UNTAPPED,
        BUMPING,
        TAPPED,
        HIDDEN,
        BROKEN,
    }
    public class IBlockState
    {
        public List<Item> Inventory { get; set; }

        protected Block block;
        public State CurrState { get; set; }

        public IBlockState(Block nBlock)
        {
            block = nBlock;
            Inventory = new List<Item>();
            Enter();
        }
        public IBlockState(Block nBlock, List<Item> nInventory)
        {
            block = nBlock;
            Inventory = nInventory;
            Enter();
        }

        public virtual void Update() { }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void ChangeState(int state) { }
    }
}
