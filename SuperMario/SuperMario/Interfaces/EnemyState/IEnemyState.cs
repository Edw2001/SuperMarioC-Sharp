using SprintZeroSpriteDrawing.Interfaces.ItemState;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.EnemyState
{
    public enum State
    {
        MOVING,
        SHELLIDLE,
        SHELLMOVING
    }
    public class IEnemyState
    {
        protected Enemy enemy;
        public State CurrState { get; set; }
        public IEnemyState(Enemy nEnemy)
        {
            enemy = nEnemy;
            Enter();
        }
        public virtual void Update() { }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void ChangeState(int state) { }
    }
}
