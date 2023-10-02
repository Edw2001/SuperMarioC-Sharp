using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.GameMode;


namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public class GameCollisions : IGameState
    {
        public GameCollisions (Mode nMode) : base(nMode)
        {
        }

        public override void Enter()
        {
            CurrState = GameModes.COLLISIONS;
            
        }

        public override void ChangeState(int state)
        {
            switch ((GameModes)state)
            {
                case GameModes.NORMAL:
                    Exit();
                    mode.State = new GameNormal(mode);
                    break;
                case GameModes.DEBUG:
                    Exit();
                    mode.State = new GameDebug(mode);
                    break;
                case GameModes.PAUSE:
                    Exit();
                    mode.State = new GamePause(mode);
                    break;
            }
        }
    }
}