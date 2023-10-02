using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem;
using Bomb = SprintZeroSpriteDrawing.Sprites.ItemSprites.Bomb;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class ItemSpriteFactory
    {
        public Vector2 nPos { get; set; }
        public Vector2 SheetSize;

        public Texture2D Coin;
        public Texture2D FireFlower;
        public Texture2D SMushroom;
        public Texture2D UPMushroom;
        public Texture2D Star;
        public Texture2D Pirana;
        public Texture2D Bomb;
        public Texture2D Arrow;
        public Texture2D Hookshot;

        public Texture2D SwordPwr;
        public Texture2D ShieldPwr;
        public Texture2D BowPwr;
        public Texture2D BombPwr;
        public Texture2D HookshotPwr;

        private static ItemSpriteFactory sprite;
        public static ItemSpriteFactory getFactory()
        {
            if (sprite == null)
            {
                sprite = new ItemSpriteFactory();
            }
            return sprite;
        }

        public void LoadContent(ContentManager content)
        {
            Coin = content.Load<Texture2D>("Items/Rupee");
            FireFlower = content.Load<Texture2D>("Items/FireFlower");
            SMushroom = content.Load<Texture2D>("Items/SuperMushroom");
            UPMushroom = content.Load<Texture2D>("Items/1UPMushroom");
            Star = content.Load<Texture2D>("Items/Starman");
            Pirana = content.Load<Texture2D>("Enemy/Piranha");
            Bomb = content.Load<Texture2D>("Tools/Bomb");
            Arrow = content.Load<Texture2D>("Tools/ArrowRe");
            Hookshot = content.Load<Texture2D>("Tools/HookshotRe");


            SwordPwr = content.Load<Texture2D>("Tools/sword");
            ShieldPwr = content.Load<Texture2D>("Tools/Sheild");
            BowPwr = content.Load<Texture2D>("Tools/Bow");
            BombPwr = content.Load<Texture2D>("Tools/Bomb");
            HookshotPwr = content.Load<Texture2D>("Tools/HookshotRe");
        }

        public ISprite createCoin(Vector2 nPos)
        {
            return new Coins(Coin, new Vector2(1, 1), nPos);
        }
        public ISprite createFlower(Vector2 nPos)
        {
            return new FireFlower(FireFlower, new Vector2(4, 2), nPos);
        }
        public ISprite createUPMushroom(Vector2 nPos)
        {
            return new OneUPMushroom(UPMushroom, new Vector2(1, 1), nPos);
        }
        public ISprite createSMushroom(Vector2 nPos)
        {
            return new SuperMushroom(SMushroom, new Vector2(1, 1), nPos);
        }
        public ISprite createStar(Vector2 nPos)
        {
            return new Starman(Star, new Vector2(2, 2), nPos);
        }
        public ISprite CreatePiranaPlant(Vector2 nPos)
        {
            return new PiranaPlant(Pirana, new Vector2(2, 1), nPos);
        }
        public ISprite CreateSwordPwr(Vector2 nPos)
        {
            return new Sword(SwordPwr, new Vector2(1, 1), nPos);
        }
        public ISprite CreateShieldPwr(Vector2 nPos)
        {
            return new Shield(ShieldPwr, new Vector2(1, 1), nPos);
        }
        public ISprite CreateBowPwr(Vector2 nPos)
        {
            return new Bow(BowPwr, new Vector2(1, 1), nPos);
        }
        public ISprite CreateBombPwr(Vector2 nPos)
        {
            return new ItemSprites.EquippableItem.Bomb(BombPwr, new Vector2(2, 2), nPos);
        }
        public ISprite CreateHookshotPwr(Vector2 nPos)
        {
            return new Hookshot(HookshotPwr, new Vector2(2, 2), nPos);
        }
        public ISprite CreateHookShot(Vector2 nPos)
        {
            return new Hook_Shot(Hookshot, new Vector2(2, 2), nPos);
        }
        public ISprite CreateBomb(Vector2 nPos)
        {
            return new Bomb(Bomb, new Vector2(2, 2), nPos);
        }
        public ISprite CreateArrow(Vector2 nPos)
        {
            return new Arrow(Arrow, new Vector2(1, 1), nPos);
        }
    }
}

