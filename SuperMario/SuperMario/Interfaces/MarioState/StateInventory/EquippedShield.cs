using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedShield : MarioInventoryState
    {
        public EquippedShield(Mario nMario) : base(nMario)
        {
        }
        public EquippedShield(Mario nMario, HashSet<EquippableItems> inventoryItems) : base(nMario, inventoryItems)
        {
        }
        public override void Enter()
        {
            mario.CollideableType = CType.AVATAR_SMALL;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.SHIELD;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(2, 3);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().normalLinkSpriteSheet);
            mario.UpdateBBox();
        }
        public override void ItemAction()
        {
            mario.ShieldPlayer(0);
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(_texture, new Rectangle((int)Icons[1].Pos.X - 48, (int)Icons[1].Pos.Y - 48, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[1].Pos.X, (int)Icons[1].Pos.Y - 48, 1, 48), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[1].Pos.X - 48, (int)Icons[1].Pos.Y, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[1].Pos.X - 48, (int)Icons[1].Pos.Y - 48, 1, 48), Color.White);
        }
    }
}
