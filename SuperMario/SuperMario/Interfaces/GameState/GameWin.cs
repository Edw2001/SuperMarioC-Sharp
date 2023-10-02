using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.GameMode;

namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public class GameWin : IGameState
    {
        public GameWin(Mode nMode) : base(nMode)
        {
        }

        public override void Enter()
        {
            CurrState = GameModes.WIN;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}