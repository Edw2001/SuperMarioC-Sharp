using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.GameMode;

namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public class GamePause : IGameState
    {
        public GamePause(Mode nMode) : base(nMode)
        {
        }

        public override void Enter()
        {
            CurrState = GameModes.PAUSE;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}