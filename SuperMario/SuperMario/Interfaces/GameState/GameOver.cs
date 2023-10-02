using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.GameMode;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Interfaces.MarioState;

namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public class GameOver : IGameState
    {
        public GameOver(Mode nMode) : base(nMode)
        {
        }

        public override void Enter()
        {
            CurrState = GameModes.OVER;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}