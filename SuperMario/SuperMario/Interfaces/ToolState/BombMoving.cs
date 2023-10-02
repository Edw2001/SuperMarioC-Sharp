using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.ProjectileState;
using SprintZeroSpriteDrawing.Sprites.EnemySprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class BombMoving : IToolState
    {
        private int resetCount = 0;

        public BombMoving(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.BOMBMOVING;
            tool.IsVis = true;
            tool.AutoFrame = false;
            tool.CollideableType = Entitiy.CType.MOVBOMB;
            if (Mario.GetMario().GetDirection() > 0)
            {
                tool.Velocity = new Vector2(10, 0);
            }
            else
            {
                tool.Velocity = new Vector2(-10, 0);
            }
            tool.Acceleration = new Vector2(0, (float).10);
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.AVATAR_LARGE));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.AVATAR_LARGE));


            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.ENEMY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.ENEMY));

            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.SIDE, CType.BOUNDRY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.BOTTOM, CType.BOUNDRY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.TOP, CType.BOUNDRY));

        }
        public override void Update()
        {
            resetCount++;
            if (resetCount > 80)
            {
                tool.AutoFrame = true;
                tool.State = new BombExplosion(tool);
            }
        }
        public virtual void kill(int kill)
        {
            tool.State = new BombExplosion(tool);
        }
    }
}
