using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.ItemState;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class Item : ICollideable
    {
        public IItemState State { get; set; }

        public Item(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.FRIENDLY;
            State = new Idle(this);
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.BOTTOM, CType.AVATAR_SMALL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.SIDE, CType.AVATAR_SMALL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.TOP, CType.AVATAR_SMALL));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.BOTTOM, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.SIDE, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.TOP, CType.AVATAR_LARGE));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.BOTTOM, CType.AVATAR_STAR));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.SIDE, CType.AVATAR_STAR));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 1)), Direction.TOP, CType.AVATAR_STAR));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 1)), Direction.BOTTOM, CType.BOUNDRY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 1)), Direction.SIDE, CType.BOUNDRY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 1)), Direction.TOP, CType.BOUNDRY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Floored, 1)), Direction.TOP, CType.NEUTRAL));
        }
        public void Kill(int collect)
        {
            Game1.SpriteList.Remove(this);
            CollisionManager.getCM().DeRegEntity(this);
            CollisionManager.getCM().DeRegMoving(this);
        }
        public void Collect(int collect)
        {
            CollisionManager.getCM().DeRegEntity(this);
            CollisionManager.getCM().DeRegMoving(this);
            State.ChangeState((int)Interfaces.ItemState.State.COLLECTING);
        }
        public void ChangeState(int state)
        {
            State.ChangeState(state);
        }
        public override void Update()
        {
            base.Update();
            State.Update();
            if (State.CurrState == Interfaces.ItemState.State.COLLECTING)
            {
                if (CollisionManager.getCM().DeRegEntity(this)) 
                    Game1.SpriteList.Remove(this);
            }
        }
    }
}
