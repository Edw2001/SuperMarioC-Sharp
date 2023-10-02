using Microsoft.Xna.Framework;
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
    public class BombIdle : IToolState
    {
        private int resetCount = 0;
        public BombIdle(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.BOMBIDLE;
            tool.CollideableType = Entitiy.CType.BOMB;
            tool.Frame = 0;
            tool.AutoFrame = false;
            tool.Acceleration = new Vector2(0, (float).10);
            tool.IsVis = true;
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Biu, 0)), Direction.SIDE, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Biu, 0)), Direction.SIDE, CType.AVATAR_LARGE));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Floored, 0)), Direction.BOTTOM, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.NEUTRAL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(tool.Walled, 0)), Direction.SIDE, CType.AVATAR_SMALL));

            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.SIDE, CType.BOUNDRY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.BOTTOM, CType.BOUNDRY));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.TOP, CType.BOUNDRY));
        }
        public override void Enter()
        {
            Game1.SpriteList.Add(tool);
            CollisionManager.getCM().RegEntity(tool);
            CollisionManager.getCM().RegMoving(tool);
        }
        public void Biu(int biu)
        {
            tool.State = new BombMoving(tool);

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
