using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.EnemyState;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.EnemySprites
{
    public class Enemy : ICollideable
    {
        public IEnemyState State;
        private bool frozen = true;
        public Enemy(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            State = new EnemyMoving(this);


            //NOTE:: KOOPA's DONT BOUNCE BECAUSE THEY CONTACT WITH TWO BLOCKS AT ONCE AND DOUBLE CANCEL THEIR VELOCITY

            CollideableType = CType.ENEMY;
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Damage, 0)), Direction.TOP, CType.AVATAR_SMALL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Damage, 0)), Direction.TOP, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Damage, 0)), Direction.TOP, CType.AVATAR_STAR));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 0)), Direction.SIDE, CType.AVATAR_SMALL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 0)), Direction.SIDE, CType.AVATAR_LARGE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 0)), Direction.SIDE, CType.AVATAR_STAR));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 0)), Direction.SIDE, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Floored, 0)), Direction.BOTTOM, CType.NEUTRAL));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(BounceWalled, 0)), Direction.SIDE, CType.ENEMY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Floored, 0)), Direction.BOTTOM, CType.ENEMY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.BOUNDRY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.BOUNDRY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.BOUNDRY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.PROJECTILE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.PROJECTILE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.PROJECTILE));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.BOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.BOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.BOMB));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.MOVBOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.MOVBOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.MOVBOMB));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.EXPBOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.EXPBOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.EXPBOMB));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.SHOARROW));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.SHOARROW));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.SHOARROW));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.COLARROW));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.COLARROW));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.COLARROW));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.SHOHOOKSHOT));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.SHOHOOKSHOT));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.SHOHOOKSHOT));

            CollisionManager.getCM().RegMoving(this);
        }
        public override void Update()
        {
            if (!frozen)
            {
                base.Update();
                State.Update();
            }
            if (frozen && Vector2.Subtract(Pos, Game1._Camera2D.Position).X < 1920)
            {
                Velocity = new Vector2(-2, 0); //This speed is high, but its used to fix something else
                Acceleration = new Vector2(0, (float).065);
                CollisionManager.getCM().RegMoving(this);
                frozen = false;
            }
        }

        public virtual void Damage(int kill)
        {
            Kill(kill);
        }
        public virtual void Kill(int kill)
        {
            CollideableType = CType.UNCOLLIDEABLE;
            Game1.SpriteList.Remove(this);
            CollisionManager.getCM().DeRegEntity(this);
            CollisionManager.getCM().DeRegMoving(this);
        }
    }
}
