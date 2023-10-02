using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Inventory
{
    public interface IInventory
    {
        // Add some Item by some quantity
        public bool AddItem(Item item, int quantity);
        // Remove some Item by some quantity
        public bool RemoveItem(Item item);
        public int GetCount(Item item);
        // Check if inventory contains specific item
        public bool CheckItem(Item item);
        // Retrieve item from inventory
        public Item GetItem(Item item);
    }
}
