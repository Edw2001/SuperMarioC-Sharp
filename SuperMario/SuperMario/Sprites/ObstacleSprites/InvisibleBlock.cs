using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    public class InvisibleBlock : Block
    {
        public InvisibleBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            IsVis = false;
            LastFrame = 3;
            CollideableType = CType.INVISIBLE;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_SMALL));

        }
        public InvisibleBlock(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, List<Item> inventory) : base(nSprite, nSheetSize, nPos, inventory)
        {
            IsVis = false;
            LastFrame = 3;
            CollideableType = CType.INVISIBLE;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeState, (int)Interfaces.BlockState.State.BUMPING)), Direction.BOTTOM, CType.AVATAR_SMALL));

        }
    }
}
