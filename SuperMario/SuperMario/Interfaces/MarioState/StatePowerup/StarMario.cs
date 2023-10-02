using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;


namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class StarMario : IMarioState
    {
        public StarMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            mario.CollideableType = CType.AVATAR_STAR;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.STAR;
            mario.IsVis = true;
            mario.UpdateBBox();
        }

        public override void ChangePowerupState(int state)
        {
            switch ((PowerupState)state)
            {
                case PowerupState.BIG:
                    Exit();
                    mario.StatePowerup = new BigMario(mario);
                    break;
                case PowerupState.FIRE:
                    Exit();
                    mario.StatePowerup = new FireMario(mario);
                    break;
                case PowerupState.SMALL:
                    Exit();
                    mario.StatePowerup = new SmallMario(mario);
                    break;
            }
        }
    }
}