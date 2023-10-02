using Microsoft.Xna.Framework;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup
{
    public class LinkStab : IMarioState
    {
        public LinkStab(Mario nMario) : base(nMario)
        {

        }

        public LinkStab(Mario nMario, ActionState nState) : base(nMario, nState)
        {

        }

        public override void Enter()
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds((int)SoundEffectPlayer.Sounds.SWORD);
            int framecount = 5;
            CollisionManager.getCM().RegMoving(mario);
            if (mario.GetDirection() > 0)
                mario.Pos = new Vector2(mario.Pos.X + 48, mario.Pos.Y);
            mario.SheetSize = new Vector2(2, 5);
            mario.SetSprite(MarioSpriteFactory.getSpriteFactory().swordLinkSpriteSheet);
            previousActionState = currActionState;
            currActionState = ActionState.STAB;
            mario.CollideableType = CType.PROJECTILE;
            mario.IsVis = true;
            mario.Velocity = new Vector2(0, 0);
            mario.Acceleration = new Vector2(0, 0);
            mario.AutoFrame = true;
            mario.Frame = 5;
            mario.StartFrame = 5;
            mario.LastFrame = 9;

           

        }
        public override void Update()
        {
            mario.invunTimer = 0;
            if(mario.Frame == 8)
                ChangeActionState((int)ActionState.IDLE);

        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }


        public override void ChangeActionState(int state)
        {
            switch ((ActionState)state)
            {
                case ActionState.IDLE:
                    Exit();
                    if (mario.GetDirection() > 0)
                        mario.Pos = new Vector2(mario.Pos.X - 48, mario.Pos.Y);
                    mario.CollideableType = CType.AVATAR_SMALL;
                    mario.StateAction = new MarioIdle(mario, currActionState);
                    mario.UpdateBBox();
                    break;
            }
        }
    }
}
