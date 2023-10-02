using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class BlockSpriteFactory
    {
        public Vector2 nPos { get; set; }
        public Vector2 SheetSize;

        public Texture2D BrickBlockSpriteSheet;
        public Texture2D QuestionBlockSpriteSheet;
        public Texture2D UsedBlockSpriteSheet;
        public Texture2D HiddenBlockSpriteSheet;
        public Texture2D GroundBlockSpriteSheet;
        public Texture2D SwitchBlockSpriteSheet;
        public Texture2D StairBlockSpriteSheet;
        public Texture2D ExplodingBrickBlockSpriteSheet;
        public Texture2D PipeBottomSpriteSheet;
        public Texture2D PipeTopSpriteSheet;
        public Texture2D CastleSpriteSheet;
        public Texture2D PoleBottomSpriteSheet;
        public Texture2D PoleTopSpriteSheet;
        public Texture2D FlagSpriteSheet;
        public Texture2D UGBrick;
        public Texture2D UGBroken;
        public Texture2D UGGround;
        public Texture2D MSBase;
        public Texture2D MasterSword;


        private static BlockSpriteFactory sprite;

        public static BlockSpriteFactory getFactory() 
        {
            if (sprite == null)
            {
                sprite = new BlockSpriteFactory();
            }
            return sprite;
        }

        public void LoadContent(ContentManager content)
        {
            HiddenBlockSpriteSheet = content.Load<Texture2D>("Obstacles/InvisibleBlock");
            UsedBlockSpriteSheet = content.Load<Texture2D>("Obstacles/HitQuestionBlock(Overworld)");
            BrickBlockSpriteSheet = content.Load<Texture2D>("Obstacles/BrickBlock(Overworld)");
            QuestionBlockSpriteSheet = content.Load<Texture2D>("Obstacles/QuestionBlock(Overworld)");
            GroundBlockSpriteSheet = content.Load<Texture2D>("Obstacles/GroundBlock(Overworld)");
            SwitchBlockSpriteSheet = content.Load<Texture2D>("Obstacles/Switch");
            StairBlockSpriteSheet = content.Load<Texture2D>("Obstacles/StairBlock");
            ExplodingBrickBlockSpriteSheet = content.Load<Texture2D>("ExplodingBlock");
            PipeBottomSpriteSheet = content.Load<Texture2D>("Obstacles/pipe_bot");
            PipeTopSpriteSheet = content.Load<Texture2D>("Obstacles/pipe_top");
            CastleSpriteSheet = content.Load<Texture2D>("Obstacles/castle");
            PoleBottomSpriteSheet = content.Load<Texture2D>("Obstacles/pole_bot");
            PoleTopSpriteSheet = content.Load<Texture2D>("Obstacles/pole_top");
            FlagSpriteSheet = content.Load<Texture2D>("Obstacles/flag");
            UGBrick = content.Load<Texture2D>("Obstacles/UG-BrickBlock");
            UGBroken = content.Load<Texture2D>("Obstacles/UG-BrokenBlock");
            UGGround = content.Load<Texture2D>("Obstacles/UG-GroundBlock");
            MSBase = content.Load<Texture2D>("Obstacles/MasterSwordBase");
            MasterSword = content.Load<Texture2D>("Obstacles/MasterSword");

        }
        
        public ISprite CreateBrickBlock(Vector2 nPos)
        {
            ISprite block;

            if (Game1.underGround)
            {
                block = new UGBrickBlock(UGBrick, new Vector2(1, 1), nPos);
                ((ICollideable)block).CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(((Block)block).ChangeState, (int)State.BROKEN)), Direction.BOTTOM, CType.AVATAR_LARGE));
                ((ICollideable)block).CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(((Block)block).ChangeState, (int)State.BUMPING)), Direction.BOTTOM, CType.AVATAR_SMALL));

            }
            else
            {
                block = new BrickBlock(BrickBlockSpriteSheet, new Vector2(1, 1), nPos);
                ((ICollideable)block).CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(((Block)block).ChangeState, (int)State.BROKEN)), Direction.BOTTOM, CType.AVATAR_LARGE));
                ((ICollideable)block).CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(((Block)block).ChangeState, (int)State.BUMPING)), Direction.BOTTOM, CType.AVATAR_SMALL));

            }
            return block;
        }
        public ISprite CreateSwitchBlock(Vector2 nPos)
        {
            ISprite block;
            block = new SwitchBlock(SwitchBlockSpriteSheet, new Vector2(2, 3), nPos);
            ((ICollideable)block).LastFrame = 4;
            return block;
        }
        public ISprite CreateSwitchedBlock(Vector2 nPos)
        {
            ISprite block;
            block = new SwitchedBlock(BrickBlockSpriteSheet, new Vector2(1, 1), nPos);
            ((ITile)block).tint = Color.Gray;
            return block;
        }
        public ISprite CreateGroundBlock(Vector2 nPos)
        {
            ISprite block;
            if (Game1.underGround)
            {
                block = new UGGround(UGGround, new Vector2(1, 1), nPos);
            }
            else
            {
                block = new GroundBlock(GroundBlockSpriteSheet, new Vector2(1, 1), nPos);
            }

            return block;
        }
        public ISprite CreateBoundryBlock(Vector2 nPos)
        {
            var block = new BounderyBlock(GroundBlockSpriteSheet, new Vector2(1, 1), nPos);
            return block;
        }
        public ISprite CreateStairBlock(Vector2 nPos)
        {
            return new StairBlock(StairBlockSpriteSheet, new Vector2(1, 1), nPos);
        }
        public ISprite CreateQuestionBlock(Vector2 nPos, bool vis)
        {
            return vis ? new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48)))
            }) : new InvisibleBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48)))
            });
        }
        public ISprite CreateMQuestionBlock(Vector2 nPos, bool vis)
        {
            return vis ? new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item>{(Item)ItemSpriteFactory.getFactory().createSMushroom(Vector2.Add(nPos, new Vector2(0, -48)))}) :
                    new InvisibleBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> {(Item)ItemSpriteFactory.getFactory().createSMushroom(Vector2.Add(nPos, new Vector2(0, -48))) });
        }
        public ISprite CreateFQuestionBlock(Vector2 nPos, bool vis)
        {
            return vis ? new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createFlower(Vector2.Add(nPos, new Vector2(0, -48))) }) :
                new InvisibleBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createFlower(Vector2.Add(nPos, new Vector2(0, -48))) });
        }
        public ISprite CreateSQuestionBlock(Vector2 nPos, bool vis)
        {
            return vis ? new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createStar(Vector2.Add(nPos, new Vector2(0, -48))) }) :
                new InvisibleBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createStar(Vector2.Add(nPos, new Vector2(0, -48))) });
        }
        public ISprite CreateUQuestionBlock(Vector2 nPos, bool vis)
        {
            return vis ? new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createUPMushroom(Vector2.Add(nPos, new Vector2(0, -48))) })
                    : new InvisibleBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createUPMushroom(Vector2.Add(nPos, new Vector2(0, -48))) });
        } 
        public ISprite Create5CQuestionBlock(Vector2 nPos, bool vis)
        {
            return vis ? new QuestionBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))), 
                (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))), (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))),
                (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))), (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48)))
            }) : new InvisibleBlock(QuestionBlockSpriteSheet, new Vector2(2, 2), nPos, new List<Item> { (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))),
                    (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))), (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))),
                    (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48))), (Item)ItemSpriteFactory.getFactory().createCoin(Vector2.Add(nPos, new Vector2(0, -48)))
                });
        }
        public ISprite CreateUsedBlock(Vector2 nPos)
        {
            return new UsedBlock(UsedBlockSpriteSheet, new Vector2(1, 1), nPos);
        }
        public ISprite CreateBrokenBlock(Vector2 nPos)
        {
            if (Game1.underGround)
            {
                return new FourExplodingBrick(UGBroken, new Vector2(2, 2), nPos);
            }
            else
            {
                return new FourExplodingBrick(ExplodingBrickBlockSpriteSheet, new Vector2(2, 2), nPos);
            }
        }
        public ISprite CreatePipeBottom(Vector2 nPos)
        {
            return new Pipe_Bot(PipeBottomSpriteSheet, new Vector2(1, 1), nPos);
        }
        public ISprite CreatePipeTop(Vector2 nPos)
        {
            return new Pipe_Top(PipeTopSpriteSheet, new Vector2(1, 1), nPos);
        }
        public ISprite CreatePPipeTop(Vector2 nPos)
        {
            return new Pipe_Top(PipeTopSpriteSheet, new Vector2(1, 1), nPos, new List<Item>{(Item)ItemSpriteFactory.getFactory().CreatePiranaPlant(Vector2.Add(nPos, new Vector2(-24, -48)))});
        }
        public ISprite CreateEnterPipeTop(Vector2 nPos)
        {
            return new PIpeTopEnter(PipeTopSpriteSheet, new Vector2(1, 1), nPos) ;
        }
        public ISprite CreateCastle(Vector2 nPos)
        {
            return new Castle(CastleSpriteSheet, new Vector2(1, 1), nPos);  
        }
        public ISprite CreatePoleTop(Vector2 nPos)
        {
            return new Pole_Top(MasterSword, new Vector2(1, 1), nPos);
        }
        public ISprite CreatePoleBot(Vector2 nPos)
        {
            return new Pole_Bot(MSBase, new Vector2(1, 1), nPos);
        }
        public ISprite CreateFlag(Vector2 nPos)
        {
            return new Flag(FlagSpriteSheet, new Vector2(1, 1), nPos);
        }
    }
}
