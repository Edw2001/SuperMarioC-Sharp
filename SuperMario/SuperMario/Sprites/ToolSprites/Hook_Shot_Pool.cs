using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Sprites.ToolSprites
{
    public class Hook_Shot_Pool
    {
        public Queue<Hook_Shot> hook_Shots = new Queue<Hook_Shot>();
        public static int hook_Shots_Max = 2;
        public static Vector2 position;
        private static Hook_Shot_Pool hook_Shot_Pool;
        public Hook_Shot_Pool(Hook_Shot hook_shot)
        {
            hook_Shots.Enqueue(hook_shot);
            while (hook_Shots.Count < hook_Shots_Max)
                hook_Shots.Enqueue((Hook_Shot)ItemSpriteFactory.getFactory().CreateHookShot(position));

        }
        public void RefillPool()
        {
            while (hook_Shots.Count < hook_Shots_Max)
                hook_Shots.Enqueue((Hook_Shot)ItemSpriteFactory.getFactory().CreateHookShot(position));

        }
        public static Hook_Shot_Pool GetHook_ShotPool()
        {
            if (hook_Shot_Pool == null)
            {
                hook_Shot_Pool = new Hook_Shot_Pool((Hook_Shot)ItemSpriteFactory.getFactory().CreateHookShot(position));
            }
            return hook_Shot_Pool;
        }
        public void Collect(Hook_Shot hook_Shot)
        {
            /*Hook_Shot hook_Shot;
            if (hook_Shots.Count > 0)
            {
                hook_Shot = hook_Shots.Peek();
            }
            else
            {
                hook_Shot = (Hook_Shot)ItemSpriteFactory.getFactory().CreateHookShot(position);
            }*/
            hook_Shots.Clear();
            hook_Shots.Enqueue(hook_Shot);
        }

        public Hook_Shot Get()
        {
            Hook_Shot hook_Shot;
            if (hook_Shots.Count > 0)
            {
                hook_Shot = hook_Shots.Dequeue();
                if (Mario.GetMario().GetDirection() > 0)
                {
                    hook_Shot.Pos = new Vector2(Mario.GetMario().Pos.X + 48, Mario.GetMario().Pos.Y - 24);
                }
                else
                {
                    hook_Shot.Pos = new Vector2(Mario.GetMario().Pos.X - 48, Mario.GetMario().Pos.Y - 24);
                }
                return hook_Shot;
            }
            else
            {
                return null;
            }
        }
    }
}