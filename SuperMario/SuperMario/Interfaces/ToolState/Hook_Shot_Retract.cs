using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.EnemyState;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using Microsoft.Xna.Framework.Input;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class Hook_Shot_Retract : IToolState
    {
        public Hook_Shot_Retract(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.HOOKSHOTRETRACT;
            tool.CollideableType = CType.SHOHOOKSHOT;
            tool.AutoFrame = true;
            tool.Velocity = new Microsoft.Xna.Framework.Vector2(
                (float)-0.02 * (tool.Pos.X - Mario.GetMario().Pos.X),
                (float)-0.02 * (tool.Pos.Y - Mario.GetMario().Pos.Y));
            if (Math.Abs(tool.Velocity.X) > 24)
                tool.Velocity = new Vector2(24 * Math.Sign(tool.Velocity.X), tool.Velocity.Y);
            if (Math.Abs(tool.Velocity.Y) > 24)
                tool.Velocity = new Vector2(tool.Velocity.X, Math.Sign(tool.Velocity.Y) * 24);
            //tool.Velocity = new Microsoft.Xna.Framework.Vector2((float)-0.03 * (tool.Pos.X - Mario.GetMario().Pos.X), (float)-0.03 * (tool.Pos.Y - Mario.GetMario().Pos.Y));
        }
        public override void Update()
        {
            //tool.Velocity = new Vector2((Mouse.GetState().X + Game1._Camera2D.Position.X - Mario.GetMario().Pos.X) / 100, (Mouse.GetState().Y + Game1._Camera2D.Position.Y - Mario.GetMario().Pos.Y) / 100);
                       if (Vector2.Subtract(Mario.GetMario().Pos, tool.Pos).Length() > 120)
                       {
                           Mario.GetMario().Velocity = -tool.Velocity;
                       }

            base.Update();
        }
    }
}
