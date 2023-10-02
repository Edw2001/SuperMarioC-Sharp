using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Collision;
using SprintZeroSpriteDrawing.Commands;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.GameState;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Interfaces.ProjectileState;
using SprintZeroSpriteDrawing.Interfaces.ToolState;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using Microsoft.Xna.Framework.Media;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateInventory;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;
using SprintZeroSpriteDrawing.States.MarioState;

namespace SprintZeroSpriteDrawing.Sprites.MarioSprites
{
    public class Mario : ICollideable
    {

        #region Mario Sprite Sheets
        public static Texture2D SmallMarioSpriteSheet;
        public static Texture2D BigMarioSpriteSheet;
        public static Texture2D FireMarioSpriteSheet;
        public static SpriteFont OverlayFont;
        #endregion
        #region Link Sprite Sheets
        public static Texture2D bombLinkSpriteSheet;
        public static Texture2D bowLinkSpriteSheet;
        public static Texture2D normalLinkSpriteSheet;
        public static Texture2D swordLinkSpriteSheet;
        public static Texture2D neutralBowLinkSpriteSheet;
        public static Texture2D upBowLinkSpriteSheet;
        public static Texture2D downBowLinkSpriteSheet;
        #endregion

        public int Score = 0;
        public int Coins = 0;
        public int Lives = 5;
        public int Time = 400;
        public int invunTimer = 0;
        public SpriteEffects effects;
        private static Mario _mario;
        bool left = false;
        bool right = false;
        public bool fireBall { get; set; }
        public IMarioState StatePowerup;
        public IMarioState StateAction;
        public MarioInventoryState StateInventory;

        public int[] currState;

        public static Mario GetMario()
        {
            if (_mario == null)
            {
                _mario = new Mario(normalLinkSpriteSheet, new Vector2(2, 3), new Vector2(0, 0));
            }
            return _mario;
        }

        private Mario(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.AVATAR_SMALL;
            effects = SpriteEffects.None;
            LastFrame = 1;
            StartFrame = 0;
            StatePowerup = new SmallMario(this);
            StateAction = new MarioIdle(this);
            StateInventory = new EquippedEmpty(this);
            currState = new int[5];

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(TakeDamage, 0)), Direction.ANY, CType.EXPBOMB));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(TakeDamage, 0)), Direction.SIDE, CType.ENEMY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.IDLE)), Direction.SIDE, CType.ENEMY));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ToWin, 0)), Direction.SIDE, CType.CASTLE));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.IDLE)), Direction.SIDE, CType.ENEMY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(TakeDamage, 0)), Direction.SIDE, CType.PIRANA));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.IDLE)), Direction.SIDE, CType.PIRANA));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.POLESLIDE)), Direction.SIDE, CType.FLAG));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.POLESLIDE)), Direction.BOTTOM, CType.FLAG));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.FALLING)), Direction.TOP, CType.INVISIBLE));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Drag, 100)), Direction.BOTTOM, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.FALLING)), Direction.TOP, CType.NEUTRAL));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Impact, (int)ActionState.FALLING)), Direction.SIDE, CType.NEUTRAL));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Drag, 100)), Direction.BOTTOM, CType.MOVBOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.FALLING)), Direction.TOP, CType.MOVBOMB));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Impact, (int)ActionState.FALLING)), Direction.SIDE, CType.MOVBOMB));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(CollectCoin, 1)), Direction.ANY, CType.FRIENDLY));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Oneup, 1)), Direction.ANY, CType.ONEUP));

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(KillEnemy, 100)), Direction.BOTTOM, CType.ENEMY)); //Score 100 pts

            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.BIG)), Direction.ANY, CType.LEVELUP));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.FIRE)), Direction.ANY, CType.FLOWER));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.STAR)), Direction.ANY, CType.STAR));


            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(EquipItem, (int)EquippableItems.SWORD)), Direction.ANY, CType.SWORD_PWR));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(EquipItem, (int)EquippableItems.SHIELD)), Direction.ANY, CType.SHIELD_PWR));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(EquipItem, (int)EquippableItems.BOW)), Direction.ANY, CType.BOW_PWR));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(EquipItem, (int)EquippableItems.BOMB)), Direction.ANY, CType.BOMB_PWR));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(EquipItem, (int)EquippableItems.HOOKSHOT)), Direction.ANY, CType.HOOKSHOT_PWR));


            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangePowerup, (int)PowerupState.DEAD)), Direction.BOTTOM, CType.BOUNDRY));

            // change
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Drag, 100)), Direction.BOTTOM, CType.PIPE_ENTER));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(ChangeAction, (int)ActionState.FALLING)), Direction.TOP, CType.PIPE_ENTER));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(Impact, (int)ActionState.FALLING)), Direction.SIDE, CType.PIPE_ENTER));
            CollisionResponse.Add(new Tuple<ICommand, Direction, CType>(new IntCmd(new KeyValuePair<Action<int>, int>(PipeEnterLevelChange, 0)), Direction.BOTTOM, CType.PIPE_ENTER));
        }

        public override void Update()
        {
            StatePowerup.Update();
            StateAction.Update();
            base.Update();
            invunTimer++;
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch, effects);
            //batch.DrawString(OverlayFont, "Coins: " + Coins.ToString("000"), new Vector2(100, 100), Color.Black);
            batch.DrawString(OverlayFont, "Time: " + Time.ToString(), new Vector2(Math.Max(Pos.X + 700, 1660), 100), Color.White);
            batch.DrawString(OverlayFont, "Rupees: " + Coins.ToString("000") + "    Score: " + Score.ToString("0000000") + "    Lives: " + Lives.ToString("00"), new Vector2(Math.Max(Pos.X - 860, 100), 100), Color.White);
            batch.DrawString(OverlayFont, "1:       2:         3: x" + ArrowPool.GetArrowPool().arrows.Count.ToString("0") + "     4: x" + BombPool.GetBombPool().bombs.Count.ToString("0") + "        5:", new Vector2(Math.Max(Pos.X - 860, 100), 148), Color.White);
            StateInventory.Draw(batch);
        }

        public void Reset()
        {
            resetTimer();
            Score = 0;
            Coins = 0;
            Lives = 5;
        }

        public static void LoadContent(ContentManager content)
        {
            SmallMarioSpriteSheet = content.Load<Texture2D>("SmallMario/SmallMarioSpriteSheet");
            BigMarioSpriteSheet = content.Load<Texture2D>("BigMario/BigMarioSpriteSheet");
            FireMarioSpriteSheet = content.Load<Texture2D>("FireMario/FireMarioSpriteSheet");
            OverlayFont = content.Load<SpriteFont>("Fonts/Arial");

            normalLinkSpriteSheet = content.Load<Texture2D>("Link/LinkNormalShield");
            bowLinkSpriteSheet = content.Load<Texture2D>("Link/LinkBow");
            bombLinkSpriteSheet = content.Load<Texture2D>("Link/LinkBomb");
            swordLinkSpriteSheet = content.Load<Texture2D>("Link/LinkSword");

            MarioInventoryState.SwordHUDTexture = content.Load<Texture2D>("Tools/sword");
            MarioInventoryState.ShieldHUDTexture = content.Load<Texture2D>("Tools/Sheild");
            MarioInventoryState.BowHUDTexture = content.Load<Texture2D>("Tools/Bow");
            MarioInventoryState.BombHUDTexture = content.Load<Texture2D>("Tools/Bomb");
            MarioInventoryState.HookshotHUDTexture = content.Load<Texture2D>("Tools/HookshotRe");

            upBowLinkSpriteSheet = content.Load<Texture2D>("Link/Bow/LinkBowUp");
            downBowLinkSpriteSheet = content.Load<Texture2D>("Link/Bow/LinkBowDown");
            neutralBowLinkSpriteSheet = content.Load<Texture2D>("Link/Bow/LinkBowNeutral");
        }
        public void Impact(int state)
        {
            Velocity = new Vector2(0, Velocity.Y);
        }
        public void ChangePowerup(int powerup)
        {
            if (powerup != 4 && powerup < 7)
                Score += 1000;
            if (powerup > (int)StatePowerup.currPowerupState)
                StatePowerup.ChangePowerupState(powerup % 7);
            if (powerup == (int)PowerupState.DEAD)
                Game1.level_update = true;
        }
        public void EquipItem(int item)
        {
            StateInventory.EquipItem(item);
        }
        public void ChangeAction(int action)
        {
            StateAction.ChangeActionState(action);
        }
        public void ChangeItem(int item)
        {
            StateInventory.SwitchToItem(item);
        }
        public void Drag(int coeff)
        {
            Velocity = Vector2.Multiply(Velocity, new Vector2((float)(coeff / 100.0), 0));
        }
        public void TakeDamage(int powerup)
        {
            if (invunTimer > 75 || powerup == -1)
            {


                if (StatePowerup.currPowerupState != PowerupState.SMALL)
                {
                    var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                    soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                    soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.PIPEPOWERDOWN;
                    ChangePowerup((int)PowerupState.SMALL + 7);
                }
                else
                {
                    ChangePowerup((int)PowerupState.DEAD);
                }

                invunTimer = 0;

            }
        }
        public void ToWin(int action)
        {
            Game1.currState = GameModes.WIN;
            ChangeAction((int)ActionState.IDLE);
        }

        public void IncreaseAction(int action)
        {
            if (StateAction.currActionState == ActionState.IDLE)
            {
                ChangeAction((int)ActionState.JUMPING); //jump
            }
            else if (StateAction.currActionState == ActionState.CROUCHING)
            {
                ChangeAction((int)ActionState.IDLE);
            }
            else if (StateAction.currActionState == ActionState.WALKING)
            {
                ChangeAction((int)ActionState.JUMPING);
            }
        }

        public void DecreaseAction(int action)
        {
            if (StateAction.currActionState == ActionState.JUMPING)
            {
                ChangeAction((int)ActionState.IDLE);
            }
            else if (StateAction.currActionState == ActionState.IDLE)
            {
                ChangeAction((int)ActionState.CROUCHING); //crounch
            }
            else if (StateAction.currActionState == ActionState.WALKING)
            {
                ChangeAction((int)ActionState.IDLE);
            }
        }
        public int GetDirection()
        {
            return effects == SpriteEffects.None ? 4 : -4;
        }
        //action positive is right
        public void MoveAction(int action)
        {
            Frame = 0;
            if (action < 0)
            {
                if (effects == SpriteEffects.None && right == true)
                {
                    right = false;
                    ChangeAction((int)ActionState.IDLE);

                }
                else if (effects == SpriteEffects.None)//right
                {
                    this.effects = SpriteEffects.FlipHorizontally;
                    ChangeAction((int)ActionState.IDLE);

                }
                else
                {
                    ChangeAction((int)ActionState.WALKING);
                    left = true;
                }
            }
            else if (action > 0)
            {
                if (effects == SpriteEffects.FlipHorizontally && left == true)
                {
                    left = false;
                    ChangeAction((int)ActionState.IDLE);
                }
                else if (effects == SpriteEffects.FlipHorizontally)//left
                {
                    this.effects = SpriteEffects.None;
                    ChangeAction((int)ActionState.IDLE);
                }
                else
                {
                    ChangeAction((int)ActionState.WALKING);
                    right = true;
                }
            }
            else
            {
                ChangeAction((int)ActionState.IDLE);
                right = false;
                left = false;
            }

        }

        public void CollectCoin(int coin)
        {
            

            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds((int)SoundEffectPlayer.Sounds.COIN);
            Score += 200;
            Coins += coin;
            if (Coins >= 100)
            {
                Coins -= 100;
                Lives++;
            }
        }
        public void Oneup(int coin)
        {
            Lives++;
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.ONEUP;
        }
        public void KillEnemy(int points)
        {
            Score += points;
            GetMario().Velocity = new Vector2(GetMario().Velocity.X, -2);
            var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
            soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
            soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.STOMP;
        }
        public void resetTimer()
        {
            Time = 400;
        }
        public void ShootFire(int Powerup)
        {
            if ((int)(Mario.GetMario().StatePowerup.currPowerupState) == Powerup)
            {
                Fireball fire = FireballPool.GetFireballPool().Get();
                if (fire != null)
                {
                    fire.State = new ProjectileAppear((Projectile)fire);
                    var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                    soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                    soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.FIREBALL;
                }
            }
        }

        public void ShieldPlayer(int Powerup)
        {
            if ((int)(Mario.GetMario().StatePowerup.currPowerupState) == Powerup)
            {
                ChangeAction((int)ActionState.SHIELDED);
            }
        }

        public void Stabing(int Powerup)
        {
            if ((int)(Mario.GetMario().StatePowerup.currPowerupState) == Powerup)
            {
                ChangeAction((int)ActionState.STAB);
            }
        }
        public void UseItem(int x)
        {
            StateInventory.ItemAction();
        }
        public void ShootArrow(int x)
        {
            Arrow arrow = ArrowPool.GetArrowPool().Get();
            if(arrow != null)
            {
                arrow.State = new ArrowShooting(arrow);
            }
        }
        public void PlaceBomb(int x)
        {
            Bomb bomb = BombPool.GetBombPool().Get();
            if (bomb != null)
            {
                bomb.State = new BombIdle((Tool)bomb);
            }
        }
        public void ShootHookShot(int x)
        {
            Hook_Shot hookShot = Hook_Shot_Pool.GetHook_ShotPool().Get();   
            if(hookShot != null)
            {
                hookShot.State = new Hook_Shot_Shooting(hookShot);
            }
        }

        
        public void PipeEnterLevelChange(int x)
        {
            if (StateAction.currActionState == ActionState.CROUCHING)
            {
                Game1.level_update = true;
                Game1.level_index++;
                if(Game1.level_index != 6)
                    Game1.underGround = true;
                else
                    Game1.underGround = false;

                
                var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.PIPEPOWERDOWN;
            }

        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }
    }
}

