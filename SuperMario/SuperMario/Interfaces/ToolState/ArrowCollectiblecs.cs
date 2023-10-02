using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.ToolState
{
    public class ArrowCollectiblecs : IToolState
    {
        public ArrowCollectiblecs(Tool nTool) : base(nTool)
        {
            tool = nTool;
            CurrState = State.ARRROWCOL;
            tool.CollideableType = Entitiy.CType.COLARROW;
            tool.AutoFrame = false;
            tool.Velocity = new Vector2(0, 0);
            tool.Acceleration = new Vector2(0, 0);
            tool.IsVis = true;
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.SIDE, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.SIDE, CType.AVATAR_LARGE));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.TOP, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.TOP, CType.AVATAR_LARGE));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.BOTTOM, CType.AVATAR_SMALL));
            tool.CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Collect, 0)), Direction.BOTTOM, CType.AVATAR_LARGE));



        }
        public override void Update()
        {
            base.Update();
            //CollisionManager.getCM().DeRegMoving(tool);
            //CollisionManager.getCM().DeRegMoving(tool);        
        }
        public virtual void Collect(int collect)
        {
            tool.CollideableType = CType.UNCOLLIDEABLE;
            Game1.SpriteList.Remove(tool);
        }
    }
}
