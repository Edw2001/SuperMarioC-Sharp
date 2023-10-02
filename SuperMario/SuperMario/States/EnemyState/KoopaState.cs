using SprintZeroSpriteDrawing.Interfaces.EnemyState;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.EnemyState
{
    public class KoopaState : IEnemyState
    {
        public State state;
        public KoopaState(Enemy nEnemy) : base(nEnemy)
        {
            state = State.MOVING;
        }
        public KoopaState(State nstate, Enemy enemy) : base(enemy)
        {
            state = nstate;
        }
        public void update()
        {

        }
        public State GetState()
        {
            return state;
        }
    }
}
