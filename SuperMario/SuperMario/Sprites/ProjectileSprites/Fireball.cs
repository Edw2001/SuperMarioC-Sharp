using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.ProjectileState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ProjectileSprites
{
    public class Fireball : Projectile
    {
        
        public Fireball(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.SIDE, CType.ENEMY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.BOTTOM, CType.ENEMY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.TOP, CType.ENEMY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.SIDE, CType.BOUNDRY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.BOTTOM, CType.BOUNDRY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.TOP, CType.BOUNDRY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(kill, 0)), Direction.SIDE, CType.NEUTRAL));

        }

        public virtual void kill(int kill)
        {
            this.State = new ProjectileDisappear(this);
            FireballPool.GetFireballPool().Release(this);
        }

        public override void Update()
        {
            base.Update();

        }
    }
}
