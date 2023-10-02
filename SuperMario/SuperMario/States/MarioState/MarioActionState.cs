using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.States.MarioState
{
    public class MarioActionState : IMarioState
	{
		public ActionState state;
        public MarioActionState(Mario mario) : base(mario)
		{
			state = ActionState.IDLE;
		}

		public MarioActionState (ActionState nstate, Mario mario): base(mario)
		{
			state = nstate;
		}

		public void Dammage()
		{
			state = ActionState.DAMMAGED;
		}

        public void Update()
        {
        }

        public ActionState GetState()
        {
            return state;
        }



    }
}
