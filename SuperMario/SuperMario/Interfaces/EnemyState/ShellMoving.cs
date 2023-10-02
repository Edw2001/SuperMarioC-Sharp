using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.EnemyState
{
    public class ShellMoving : IEnemyState
    {
        public ShellMoving(Enemy nEnemy) : base(nEnemy)
        {
            CurrState = State.SHELLMOVING;
            enemy.CollideableType = CType.PROJECTILE;
            enemy = nEnemy;
            enemy.Velocity = new Vector2(10, 0);
            enemy.Acceleration = new Vector2(0, (float).10);
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(enemy.BounceWalled, 0)), Direction.SIDE, CType.NEUTRAL));
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(enemy.BounceWalled, 0)), Direction.SIDE, CType.AVATAR_SMALL));
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(enemy.BounceWalled, 0)), Direction.SIDE, CType.AVATAR_LARGE));
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.SIDE, CType.BOUNDRY));
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.BOTTOM, CType.BOUNDRY));
            enemy.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Kill, 0)), Direction.TOP, CType.BOUNDRY));
        }
        public virtual void Kill(int kill)
        {
            Game1.SpriteList.Remove(enemy);
            CollisionManager.getCM().DeRegEntity(enemy);
            CollisionManager.getCM().DeRegMoving(enemy);
        }
    }
}
