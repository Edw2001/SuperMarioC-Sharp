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
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.MarioState;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory
{
    public class EquippedSword : MarioInventoryState
    {
        public EquippedSword(Mario nMario) : base(nMario)
        {
        }
        public EquippedSword(Mario nMario, HashSet<EquippableItems> inventoryItems) : base(nMario, inventoryItems)
        {
        }
        public override void ItemAction()
        {
            mario.Stabing(0);
        }

        public override void Enter()
        {
            
            mario.CollideableType = CType.AVATAR_SMALL;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.SWORD;
            mario.IsVis = true;
            mario.UpdateBBox();
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(_texture, new Rectangle((int)Icons[0].Pos.X - 48, (int)Icons[0].Pos.Y - 48, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[0].Pos.X, (int)Icons[0].Pos.Y - 48, 1, 48), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[0].Pos.X - 48, (int)Icons[0].Pos.Y, 48, 1), Color.White);
            batch.Draw(_texture, new Rectangle((int)Icons[0].Pos.X - 48, (int)Icons[0].Pos.Y - 48, 1, 48), Color.White);
        }
    }
}
