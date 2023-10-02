using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public enum State
    {
        BOMBIDLE,
        BOMBMOVING,
        BOMBEXPLOSION,
        ARROWSHOOTING,
        ARRROWCOL,
        HOOKSHOTSHOOTING,
        HOOKSHOTCOL,
        HOOKSHOTRETRACT
    }
    public class IToolState
    {
        protected Tool tool;
        public State CurrState { get; set; }
        public IToolState(Tool nTool)
        {
            tool = nTool;
            Enter();
        }
        public virtual void Enter() { }
        public virtual void Update() { }
    }
}
