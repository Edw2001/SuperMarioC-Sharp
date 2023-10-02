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
    public class MarioPowerupState : IMarioState
    {
        public PowerupState state;
        public MarioPowerupState(Mario mario) : base(mario)
        {
            state = PowerupState.SMALL;
        }

        public MarioPowerupState(PowerupState nstate, Mario mario) : base(mario)
        {
            state = nstate;
        }

        

        public void Update()
        {
        }

        public PowerupState GetState()
        {
            return state;
        }



    }
}
