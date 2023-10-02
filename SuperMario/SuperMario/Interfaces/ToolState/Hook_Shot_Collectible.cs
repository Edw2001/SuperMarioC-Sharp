using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.EnemyState;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class Hook_Shot_Collectible : IToolState
    {
        private int resetCount = 0;
        public Hook_Shot_Collectible(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTCOL;
            tool.CollideableType = Entitiy.CType.COLHOOKSHOT;
            tool.CollideMaybe = false;
            tool.AutoFrame = false;
            tool.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            tool.Acceleration = new Microsoft.Xna.Framework.Vector2(0, 0);
        }
        public override void Update()
        {
            resetCount++;
            if (resetCount > 80)
            {
                tool.AutoFrame = true;
                tool.State = new Hook_Shot_Retract(tool);
            }
        }
    }
}
