using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System.Runtime.CompilerServices;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class SmallMario : IMarioState
    {
        public SmallMario(Mario nMario) : base(nMario)
        {

        }

        public override void Enter()
        {
            mario.CollideableType = CType.AVATAR_SMALL;
            prevPowerupState = currPowerupState;
            currPowerupState = PowerupState.SMALL;
            mario.IsVis = true;
            mario.SheetSize = new Vector2(2, 3);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().normalLinkSpriteSheet);
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
                case PowerupState.DEAD:
                    Exit();
                    mario.StatePowerup = new DeadMario(mario);
                    break;
                case PowerupState.SHIELD:
                    Exit();
                    mario.StatePowerup = new LinkShield(mario);
                    break;
                case PowerupState.SWORD:
                    Exit();
                    mario.StatePowerup = new LinkSword(mario);
                    break;
            }
        }
    }
}