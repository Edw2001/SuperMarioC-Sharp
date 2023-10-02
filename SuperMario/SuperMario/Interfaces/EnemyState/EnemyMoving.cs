using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces.ItemState;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Interfaces.EnemyState
{
    public class EnemyMoving : IEnemyState
    {
        public EnemyMoving(Enemy nEnemy) : base(nEnemy)
        {
            CurrState = State.MOVING;
            enemy.CollideableType = CType.ENEMY;
            enemy.Velocity = new Vector2(-3, 0);
            enemy.Acceleration = new Vector2(0, (float).065);
            CollisionManager.getCM().RegEntity(enemy);
        }
    }
}
