using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using Bomb = SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem.Bomb;

namespace SprintZeroSpriteDrawing.States.MarioState
{
    public enum EquippableItems
    {
        SWORD,
        SHIELD,
        BOW,
        BOMB,
        HOOKSHOT
    }

    public class MarioInventoryState : IMarioState
    {
        public static Texture2D SwordHUDTexture { get; set; }
        public static Texture2D ShieldHUDTexture { get; set; }
        public static Texture2D BowHUDTexture { get; set; }
        public static Texture2D BombHUDTexture { get; set; }
        public static Texture2D HookshotHUDTexture { get; set; }
        public static List<ITile> Icons { get; set; }
        public HashSet<EquippableItems> PlayerInventory { get; set; }
        protected Texture2D _texture;
        public MarioInventoryState(Mario nMario) : base(nMario)
        {
            _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
                Icons = new List<ITile>()
                {
                    new ITile(SwordHUDTexture, new Vector2(800, 100)), new ITile(ShieldHUDTexture, new Vector2(900, 100)),
                    new ITile(BowHUDTexture, new Vector2(1000, 100)),
                    new ITile(BombHUDTexture, new Vector2(2, 2), new Vector2(1100, 100)),
                    new ITile(HookshotHUDTexture, new Vector2(2, 2), new Vector2(1200, 100))
                };
                foreach (ITile icon in Icons)
                {
                    icon.tint = Color.Gray;
                }
        }
        public MarioInventoryState(Mario nMario, HashSet<EquippableItems> inventoryItems) : base(nMario)
        {
            PlayerInventory = inventoryItems;
            _texture = new Texture2D(Game1.Graphics.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });
        }
        public virtual void ItemAction()
        {
        }
        public void EquipItem(int item)
        {
            PlayerInventory.Add((EquippableItems)item);
            Icons[item].tint = Color.White;
            switch ((EquippableItems)item)
            {
                case EquippableItems.BOMB:
                    BombPool.GetBombPool().RefillPool();
                    break;
                case EquippableItems.BOW:
                    ArrowPool.GetArrowPool().RefillPool();
                    break;
            }
        }
        public virtual void Draw(SpriteBatch batch)
        {
            int posoffset = -250;
            foreach (ITile icon in Icons)
            {
                icon.Pos = new Vector2(Math.Max(mario.Pos.X - 960 + 398, 398) + posoffset, 200);
                icon.Draw(batch);
                posoffset += 125;
            }
        }
        public void SwitchToItem(int item)
        {
            if (PlayerInventory.Contains((EquippableItems)item))
            {
                switch ((EquippableItems)item)
                {
                    case EquippableItems.SWORD:
                        mario.StateInventory = new EquippedSword(mario, PlayerInventory);
                        break;
                    case EquippableItems.SHIELD:
                        mario.StateInventory = new EquippedShield(mario, PlayerInventory);
                        break;
                    case EquippableItems.BOMB:
                            mario.StateInventory = new EquippedBomb(mario, PlayerInventory);
                        break;
                    case EquippableItems.BOW:
                            mario.StateInventory = new EquippedBow(mario, PlayerInventory);
                        break;
                    case EquippableItems.HOOKSHOT:
                            mario.StateInventory = new EquippedHookshot(mario, PlayerInventory);
                        break;
                }
            }
        }
    }
}
