using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.States.BlockState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class Block : ICollideable
    {
        public IBlockState State { get; set; }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            State = new BlockUntapped(this);
            CollideableType = CType.NEUTRAL;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BROKEN)), Direction.ANY, CType.EXPBOMB));
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox) : base (nSprite, nSheetSize, nPos, nBBox)
        {
            State = new BlockUntapped(this);
            CollideableType = CType.NEUTRAL;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BROKEN)), Direction.ANY, CType.EXPBOMB));
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, List<Item> Inventory) : base(nSprite, nSheetSize, nPos)
        {
            State = new BlockUntapped(this, Inventory);
            CollideableType = CType.NEUTRAL;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BROKEN)), Direction.ANY, CType.EXPBOMB));
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Rectangle nBBox, List<Item> Inventory) : base(nSprite, nSheetSize, nPos, nBBox)
        {
            State = new BlockUntapped(this, Inventory);
            CollideableType = CType.NEUTRAL;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BROKEN)), Direction.ANY, CType.EXPBOMB));
        }
        public Block(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration, Rectangle nBBox) : base(nSprite, nSheetSize, nPos, acceleration, nBBox)
        {
            State = new BlockUntapped(this);
            CollideableType = CType.NEUTRAL;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BROKEN)), Direction.ANY, CType.EXPBOMB));
        }
        public void ChangeState(int state)
        {
            State.ChangeState(state);
        }
        public override void Update()
        {
            State.Update();
            base.Update();
        }
    }
}
