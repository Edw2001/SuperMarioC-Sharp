using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedBow : MarioInventoryState
    {
        public EquippedBow(Mario nMario) : base(nMario)
        {
        }
        public EquippedBow(Mario nMario, HashSet<EquippableItems> inventoryItems) : base(nMario, inventoryItems)
        {
        }

        public override void Enter()
        {
            mario.CollideableType = CType.AVATAR_SMALL;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.BIG;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(2, 3);
            mario.SetSprite(Mario.neutralBowLinkSpriteSheet);
            mario.UpdateBBox();
        }

        public override void ItemAction()
        {
            mario.ShootArrow(0);
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(_texture, new Rectangle((int)Icons[2].Pos.X - 48, (int)Icons[2].Pos.Y - 48, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[2].Pos.X, (int)Icons[2].Pos.Y - 48, 1, 48), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[2].Pos.X - 48, (int)Icons[2].Pos.Y, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[2].Pos.X - 48, (int)Icons[2].Pos.Y - 48, 1, 48), Color.White);
        }
    }
}
