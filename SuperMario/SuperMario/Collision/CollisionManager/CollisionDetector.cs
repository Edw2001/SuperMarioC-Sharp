using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SprintZeroSpriteDrawing.Collision
{
    // Add the grid and create the map
    // Map <new Vecrtor2(x, y), Values will be the items stored in each sepreate grid>
    public class CollisionDetector
    {
        private static CollisionDetector CD;

        public static CollisionDetector getCD()
        {
            if (CD == null)
                CD = new CollisionDetector();
            return CD;
        }
        public Direction DetectColDirection(ICollideable FirstObject, ICollideable SecondObject)
        {
            Rectangle Intersection = Rectangle.Intersect(FirstObject.BBox, SecondObject.BBox);
            if (!Intersection.IsEmpty)
            {
                if ((Intersection.Height >= Intersection.Width) && (Math.Abs(FirstObject.Velocity.X - SecondObject.Velocity.X) > Math.Abs(FirstObject.Velocity.Y - SecondObject.Velocity.Y)))
                {
                    return Direction.SIDE;
                }
                if ((Intersection.Height <= Intersection.Width) && (FirstObject.Velocity.Y - SecondObject.Velocity.Y) >= 0)
                {
                    return Direction.BOTTOM;
                }
                if((Intersection.Height <= Intersection.Width) && (FirstObject.Velocity.Y - SecondObject.Velocity.Y) <= 0)
                {
                    return Direction.TOP;
                }
            }
            return Direction.NULL;
        }

        public Vector2 BuildWalkback(ICollideable FirstObject, ICollideable SecondObject)
        {
            Rectangle Intersection = Rectangle.Intersect(FirstObject.BBox, SecondObject.BBox);
            Vector2 walkback = new Vector2();

            if (Intersection.Height > Intersection.Width && FirstObject.BBox.X < SecondObject.BBox.X)
            {
                walkback.X = -Intersection.Width;
            }
            else if (Intersection.Height > Intersection.Width)
            {
                walkback.X = Intersection.Width;
            }
            else if (FirstObject.BBox.Y < SecondObject.BBox.Y)
            {
                walkback.Y = -Intersection.Height;
            }
            else
            {
                walkback.Y = Intersection.Height;
            }
            return walkback;
        }
    }
}
