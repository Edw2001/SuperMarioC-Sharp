using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class ArrowShooting : IToolState
    {
        public ArrowShooting(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.ARROWSHOOTING;
            tool.CollideableType = Entitiy.CType.SHOARROW;
            tool.CollideMaybe = false;
            tool.AutoFrame = false;

            tool.Velocity = new Vector2((Mouse.GetState().X + Game1._Camera2D.Position.X - Mario.GetMario().Pos.X) / 100, (Mouse.GetState().Y + Game1._Camera2D.Position.Y - Mario.GetMario().Pos.Y) / 100);
            tool.Acceleration = new Vector2(0, (float)0.1);

            tool.IsVis = true;
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.SIDE, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.TOP, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.BOTTOM, CType.NEUTRAL));
            /*tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.SIDE, CType.SHOARROW));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.TOP, CType.SHOARROW));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.BOTTOM, CType.SHOARROW));*/
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.SIDE, CType.ENEMY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.TOP, CType.ENEMY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.BOTTOM, CType.ENEMY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.SIDE, CType.COLARROW));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.TOP, CType.COLARROW));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Miss, 0)), Direction.BOTTOM, CType.COLARROW));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.COLARROW));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.COLARROW));
            CollisionManager.getCM().RegEntity(tool);
            CollisionManager.getCM().RegMoving(tool);


        }
        public override void Enter()
        {
            Game1.SpriteList.Add(tool);

        }
        public void Miss(int miss)
        {
            tool.State = new ArrowCollectiblecs(tool);

        }

    }
}
