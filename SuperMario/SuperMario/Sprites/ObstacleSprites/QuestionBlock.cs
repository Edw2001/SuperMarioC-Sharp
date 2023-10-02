using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.States.BlockState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class QuestionBlock : Block
    {
        public QuestionBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base (nSprite, nSheetSize, nPos)
        {
            LastFrame = 3;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_SMALL));
        }
        public QuestionBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, List<Item> Inventory) : base(nSprite, nSheetSize, nPos, Inventory)
        {
            LastFrame = 3;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_SMALL));
        }
    }
}
