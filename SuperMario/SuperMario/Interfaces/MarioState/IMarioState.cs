using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState
{
    public enum PowerupState
    {
        SMALL,
        BIG,
        FIRE,
        STAR,
        DEAD,
        SHIELD,
        SWORD
    }

    public enum ActionState
    {
        JUMPING,
        FALLING,
        POLESLIDE,
        WALKING,
        RUNNING,
        CROUCHING,
        IDLE,
        DAMMAGED,
        STAB,
        SHIELDED
    }
    public class IMarioState
    {
        protected Mario mario;
        protected IMarioState previousPowerupState;
        public ActionState currActionState { get; set; }
        public ActionState previousActionState{ get; set; }
        public PowerupState currPowerupState { get; set; }
        public PowerupState prevPowerupState { get; set; }
        private static IMarioState marioState;
        public IMarioState(Mario nMario)
        {
            mario = nMario;
            Enter();
        }

        public IMarioState(Mario nMario, ActionState nState)
        {
            mario = nMario;
            previousActionState = nState;
            Enter();
        }
        public IMarioState(Mario nMario, PowerupState nState)
        {
            mario = nMario;
            prevPowerupState = nState;
            Enter();
        }

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location) { }
        public virtual void Enter() { }
        public virtual void Exit()
        {
            previousPowerupState = this;        
        }
        public virtual void ChangeActionState(int state){ }
        public virtual void ChangePowerupState(int state){ }
    }
}
