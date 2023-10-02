using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;

namespace SprintZeroSpriteDrawing.LevelLoader
{
    public class LevelLoader
    {
        private static LevelLoader loader;

        public static LevelLoader GetLevelLoader()
        {
            if (loader == null)
                loader = new LevelLoader();
            return loader;
        }
        public void LoadLevel(String levelName)
        {
            int x = 48;
            Game1.LEVELSIZE.X = 1920;
            int y = 48;
            Game1.LEVELSIZE.Y = 1080;

            FileStream fileStream = File.Open(levelName, FileMode.OpenOrCreate, FileAccess.Read);

            while (FindStartLine(fileStream) != 255)
            {
                while (GenerateEntity(x, y, false, fileStream) != -1)
                {
                    x += 48;
                }
                if (x > Game1.LEVELSIZE.X)
                    Game1.LEVELSIZE.X = x;
                x = 48;
                y += 48;
            }
            Game1.LEVELSIZE.Y = y;
            fileStream.Seek(0, SeekOrigin.Begin);
            CollisionManager.getCM().Resize();
            x = 48;
            y = 48;

            while (FindStartLine(fileStream) != 255)
            {
                while (GenerateEntity(x, y, true, fileStream) != -1)
                {
                    x += 48;
                }
                x = 48;
                y += 48;
            }
            fileStream.Close();
        }

        private int FindStartLine(FileStream fileStream)
        {
            char err = (char)((fileStream.ReadByte() + 256) % 256);
            while (!(err == 255 || err == '>'))
            {
                err = (char)((fileStream.ReadByte() + 256) % 256);
            }
            return err;
        }

        private int GenerateEntity(int x, int y, bool gen, FileStream fileStream)
        {
            char err = (char)((fileStream.ReadByte() + 256) % 256);
            if (err == '<')
                return -1;
            if (gen)
            {
                ISprite entity = null;
                switch (err)
                {
                    #region mario

                    case 'M':
                        Mario.GetMario().Pos = new Vector2(x, y);
                        Mario.GetMario().UpdateBBox();
                        entity = Mario.GetMario();
                        break;
                    case 'X':
                        Game1.PipeExit = new Vector2(x - 24, y);
                        return err;

                    #endregion

                    #region enemies

                    case 'G':
                        entity = EnemySpriteFactory.getFactory().CreateGoomba(new Vector2(x, y));
                        break;
                    case 'k':
                        entity = EnemySpriteFactory.getFactory().CreateGreenKoopa(new Vector2(x, y));
                        break;
                    case 'K':
                        entity = EnemySpriteFactory.getFactory().CreateRedKoopa(new Vector2(x, y));
                        break;

                    #endregion

                    #region blocks

                    #region question blocks

                    case '?':
                        entity = BlockSpriteFactory.getFactory().CreateQuestionBlock(new Vector2(x, y), true);
                        break;
                    case '1':
                        entity = BlockSpriteFactory.getFactory().CreateMQuestionBlock(new Vector2(x, y), true);
                        break;
                    case '2':
                        entity = BlockSpriteFactory.getFactory().CreateFQuestionBlock(new Vector2(x, y), true);
                        break;
                    case '3':
                        entity = BlockSpriteFactory.getFactory().CreateSQuestionBlock(new Vector2(x, y), true);
                        break;
                    case '4':
                        entity = BlockSpriteFactory.getFactory().Create5CQuestionBlock(new Vector2(x, y), true);
                        break;
                    case '5':
                        entity = BlockSpriteFactory.getFactory().CreateUQuestionBlock(new Vector2(x, y), true);
                        break;

                    #endregion

                    #region hidden blocks

                    case 'h':
                        entity = BlockSpriteFactory.getFactory().CreateQuestionBlock(new Vector2(x, y), false);
                        break;
                    case '!':
                        entity = BlockSpriteFactory.getFactory().CreateMQuestionBlock(new Vector2(x, y), false);
                        break;
                    case '@':
                        entity = BlockSpriteFactory.getFactory().CreateFQuestionBlock(new Vector2(x, y), false);
                        break;
                    case '#':
                        entity = BlockSpriteFactory.getFactory().CreateSQuestionBlock(new Vector2(x, y), false);
                        break;
                    case '$':
                        entity = BlockSpriteFactory.getFactory().Create5CQuestionBlock(new Vector2(x, y), false);
                        break;
                    case '%':
                        entity = BlockSpriteFactory.getFactory().CreateUQuestionBlock(new Vector2(x, y), false);
                        break;

                    #endregion

                    #region other blocks

                    case 'b':
                        entity = BlockSpriteFactory.getFactory().CreateBrickBlock(new Vector2(x, y));
                        break;
                    case 'g':
                        entity = BlockSpriteFactory.getFactory().CreateGroundBlock(new Vector2(x, y));
                        break;
                    case 's':
                        entity = BlockSpriteFactory.getFactory().CreateStairBlock(new Vector2(x, y));
                        break;
                    case 'u':
                        entity = BlockSpriteFactory.getFactory().CreateUsedBlock(new Vector2(x, y));
                        break;
                    case 'x':
                        entity = BlockSpriteFactory.getFactory().CreateSwitchBlock(new Vector2(x, y));
                        break;
                    case 'o':
                        entity = BlockSpriteFactory.getFactory().CreateSwitchedBlock(new Vector2(x, y));
                        break;

                    #endregion

                    #endregion

                    #region items

                    case 'm':
                        entity = ItemSpriteFactory.getFactory().createSMushroom(new Vector2(x, y));
                        break;
                    case 'f':
                        entity = ItemSpriteFactory.getFactory().createFlower(new Vector2(x, y));
                        break;
                    case 'S':
                        entity = ItemSpriteFactory.getFactory().createStar(new Vector2(x, y));
                        break;
                    case 'c':
                        entity = ItemSpriteFactory.getFactory().createCoin(new Vector2(x, y));
                        break;
                    case 'U':
                        entity = ItemSpriteFactory.getFactory().createUPMushroom(new Vector2(x, y));
                        break;
                    case '^':
                        entity = ItemSpriteFactory.getFactory().CreateSwordPwr(new Vector2(x, y));
                        break;
                    case '&':
                        entity = ItemSpriteFactory.getFactory().CreateShieldPwr(new Vector2(x, y));
                        break;
                    case '*':
                        entity = ItemSpriteFactory.getFactory().CreateBowPwr(new Vector2(x, y));
                        break;
                    case '(':
                        entity = ItemSpriteFactory.getFactory().CreateBombPwr(new Vector2(x, y));
                        break;
                    case ')':
                        entity = ItemSpriteFactory.getFactory().CreateHookshotPwr(new Vector2(x, y));
                        break;

                    #endregion

                    #region obstacles

                    case 'T':
                        entity = BlockSpriteFactory.getFactory().CreatePipeTop(new Vector2(x, y));
                        break;
                    case 'B':
                        entity = BlockSpriteFactory.getFactory().CreatePipeBottom(new Vector2(x, y));
                        break;
                    case 'V':
                        entity = BlockSpriteFactory.getFactory().CreateEnterPipeTop(new Vector2(x, y));
                        break;
                    case 'P':
                        entity = BlockSpriteFactory.getFactory().CreatePPipeTop(new Vector2(x, y));
                        break;
                    case 'C':
                        entity = BlockSpriteFactory.getFactory().CreateCastle(new Vector2(x, y));
                        break;
                    case '[':
                        entity = BlockSpriteFactory.getFactory().CreatePoleBot(new Vector2(x, y));
                        if(Game1.Flagbase < y)
                            Game1.Flagbase = y;
                        break;
                    case ']':
                        entity = BlockSpriteFactory.getFactory().CreatePoleTop(new Vector2(x, y));
                        break;
                    case 'F':
                        entity = BlockSpriteFactory.getFactory().CreateFlag(new Vector2(x, y));
                        break;

                    #endregion


                    default:
                        return err;
                }
                Game1.SpriteList.Add(entity);
            }

            return err;
        }
       

    }
}
