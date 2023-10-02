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
    public class GameStart : IGameState
    {
        public GameStart(Mode nMode) : base(nMode)
        {
        }

        public override void Enter()
        {
            CurrState = GameModes.START;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}