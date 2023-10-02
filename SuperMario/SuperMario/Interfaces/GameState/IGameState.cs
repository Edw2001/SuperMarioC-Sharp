using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SprintZeroSpriteDrawing.GameMode;

namespace SprintZeroSpriteDrawing.Interfaces.GameState
{
    public enum GameModes
    {
        NORMAL,
        DEBUG,
        COLLISIONS,
        PAUSE,
        OVER,
        WIN,
        START
    }

    
    public class IGameState
    {
        public static GameModes GM;
        protected Mode mode;
        public GameModes CurrState { get; set; }


        public IGameState(Mode nMode)
        {
            mode = nMode;
            Enter();
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location) { }
        public virtual void Enter() { }
        public virtual void Exit(){ }
        public virtual void ChangeState(int state) { }
    }
}