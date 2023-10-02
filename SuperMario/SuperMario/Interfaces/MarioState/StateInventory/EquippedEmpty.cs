using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;
using Bomb = SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem.Bomb;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedEmpty : MarioInventoryState
    {
        public EquippedEmpty(Mario nMario) : base(nMario)
        {
            PlayerInventory = new HashSet<EquippableItems>(){};
        }
        public EquippedEmpty(Mario nMario, HashSet<EquippableItems> inventoryItems) : base(nMario, inventoryItems)
        {
        }

    }
}
