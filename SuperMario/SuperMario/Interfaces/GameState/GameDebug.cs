using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.GameMode;

namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public class GameDebug : IGameState
    {
        public GameDebug(Mode nMode) : base(nMode)
        {
        }

        public override void Enter()
        {
            CurrState = GameModes.DEBUG;
            mode.ToggleDebugBoxes(Game1.DEBUGBBOX);
        }

        public override void ChangeState(int state)
        {
            switch ((GameModes)state)
            {
                case GameModes.COLLISIONS:
                    Exit();
                    mode.State = new GameCollisions(mode);
                    break;
                case GameModes.NORMAL:
                    Exit();
                    mode.State = new GameNormal(mode);
                    break;
                case GameModes.PAUSE:
                    Exit();
                    mode.State = new GamePause(mode);
                    break;
            }
        }
    }
}
