using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedHookshot : MarioInventoryState
    {
        public EquippedHookshot(Mario nMario) : base(nMario)
        {
        }
        public EquippedHookshot(Mario nMario, HashSet<EquippableItems> inventoryItems) : base(nMario, inventoryItems)
        {
        }
        public override void ItemAction()
        {
            mario.ShootHookShot(0);
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(_texture, new Rectangle((int)Icons[4].Pos.X - 48, (int)Icons[4].Pos.Y - 48, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[4].Pos.X, (int)Icons[4].Pos.Y - 48, 1, 48), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[4].Pos.X - 48, (int)Icons[4].Pos.Y, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[4].Pos.X - 48, (int)Icons[4].Pos.Y - 48, 1, 48), Color.White);
        }
    }
}
