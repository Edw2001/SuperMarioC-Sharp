using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.MarioActionSprites
{
    public class MarioSpriteFactory
    {



        public Texture2D spriteSheet;
        public Vector2 sheetSize;
        public Vector2 frameSize;
        #region Mario Sprite Sheets
        public Texture2D SmallMarioSpriteSheet;
        public Texture2D BigMarioSpriteSheet;
        public Texture2D FireMarioSpriteSheet;
        #endregion
        #region Link Sprite Sheets
        public Texture2D bombLinkSpriteSheet;
        public Texture2D bowLinkSpriteSheet;
        public Texture2D neutralBowLinkSpriteSheet;
        public Texture2D upBowLinkSpriteSheet;
        public Texture2D downBowLinkSpriteSheet;
        public Texture2D normalLinkSpriteSheet;
        public Texture2D swordLinkSpriteSheet;
        #endregion

        public Vector2 position { get; set; }

        #region Small Mario
        private Texture2D SmallRunningSpriteSheet;
        private Texture2D SmallJumpingSpriteSheet;
        private Texture2D SmallIdleSpriteSheet;

        #endregion

        #region Big Mario
        private Texture2D BigRunningSpriteSheet;
        private Texture2D BigJumpingSpriteSheet;
        private Texture2D BigIdleSpriteSheet;
        private Texture2D BigCrouchingSpriteSheet;
        #endregion

        #region Fire Mario
        private Texture2D FireRunningSpriteSheet;
        private Texture2D FireJumpingSpriteSheet;
        private Texture2D FireIdleSpriteSheet;
        private Texture2D FireCrouchingSpriteSheet;
        #endregion

        #region Dead Mario
        public Texture2D DeadMarioSpriteSheet;
        #endregion



        private static MarioSpriteFactory factory;
        public static MarioSpriteFactory getSpriteFactory()
        {
            if (factory == null)
            {
                factory = new MarioSpriteFactory();
            }
            return factory;
        }
        public void LoadContent(ContentManager content)
        {
            SmallMarioSpriteSheet = content.Load<Texture2D>("SmallMario/SmallMarioSpriteSheet");
            BigMarioSpriteSheet = content.Load<Texture2D>("BigMario/BigMarioSpriteSheet");
            FireMarioSpriteSheet = content.Load<Texture2D>("FireMario/FireMarioSpriteSheet");
            DeadMarioSpriteSheet = content.Load<Texture2D>("SmallMario/smallDying");

            normalLinkSpriteSheet = content.Load<Texture2D>("Link/LinkNormalShield");
            bowLinkSpriteSheet = content.Load<Texture2D>("Link/LinkBow");
            bombLinkSpriteSheet = content.Load<Texture2D>("Link/LinkBomb");
            swordLinkSpriteSheet = content.Load<Texture2D>("Link/LinkSword");
            upBowLinkSpriteSheet = content.Load<Texture2D>("Link/Bow/LinkBowUp");
            downBowLinkSpriteSheet = content.Load<Texture2D>("Link/Bow/LinkBowDown");
            neutralBowLinkSpriteSheet = content.Load<Texture2D>("Link/Bow/LinkBowNeutral");

        }
        public ISprite createMario(Vector2 nPos)
        {
            return Mario.GetMario();

        }





    }
}