using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.States.BlockState;

namespace SprintZeroSpriteDrawing.LevelLoader
{
    public class Checkpoint
    {
        private List<ISprite> spriteList;
        private List<ICollideable>[,] entityList;
        private List<ICollideable> movingEntities;
        private Vector2 marioPos;

        public Checkpoint(Vector2 mPos, CollisionManager cm, List<ISprite> sList)
        {
            this.marioPos = mPos;
            entityList = cm.MomentityList();
            movingEntities = cm.MovingMomento();
            spriteList = sList;
        }

    }
}
