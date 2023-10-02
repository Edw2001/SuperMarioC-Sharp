using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using SprintZeroSpriteDrawing.LevelLoader;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.Commands;
using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using SprintZeroSpriteDrawing.Collision.CollisionManager;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using SprintZeroSpriteDrawing.Sprites.ObstacleSprites;
using SprintZeroSpriteDrawing.Interfaces.BlockState;
using SprintZeroSpriteDrawing.Sprites.MarioActionSprites;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.GameMode;
using SprintZeroSpriteDrawing.Collision;
using SprintZeroSpriteDrawing.Sprites.ProjectileSprites;
using SprintZeroSpriteDrawing.Sprites.SpriteFactory;
using SprintZeroSpriteDrawing.States.MarioState;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StatePowerup;
using SprintZeroSpriteDrawing.Interfaces.MarioState.StateAction;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Interfaces.GameState;
using Microsoft.Xna.Framework.Audio;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Media;
using SprintZeroSpriteDrawing.Sprites.ItemSprites.EquippableItem;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;

namespace SprintZeroSpriteDrawing
{
    
    public class Game1 : Game
    {
        public static GraphicsDeviceManager Graphics { get; set; }
        #region Controller
        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;
        private IController<Keys> quitpauseController;
        private MouseController2 mouseController;
        #endregion

        #region sprites
        //This is the sprite batch that all of my sprites are drawing to, it gets passed around
        private SpriteBatch sBatch;
        //Glorified Arial font for the control list
        private SpriteFont HUDFont;
        //Sprites and their names, could use UUID's if I wanted to, but I like names its unnecessary tho
        public static List<ISprite> SpriteList = new List<ISprite>();
        #endregion
        public int[] LevelOrder { get; set; }

        public static Vector2 LEVELSIZE = new Vector2(1920,1080);
        public static Vector2 PipeExit = new Vector2(1920, 1080);
        private bool piped = false;
        public static int Flagbase = 0;
        public static Camera _Camera2D;
        public static int counter = 0;
        public static bool isTimeCounting = true;
        public static bool DEBUGBBOX = false;
        public static bool PAUSE = false;
        public static bool SPLASH_BACK = false;
        private int splashback_timer = 0;
        public static GameModes currState;
        public static bool underGround = false;
        public static int level_index = 0;
        public static bool level_update = false;
        public static bool switched = false;

        public Game1()
        {
            //starting the graphics device for monogame
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            GenerateLevelOrder();
        }
        public void GenerateLevelOrder()
        {
            Random rand = new Random();
            int[] innerLevels = new int[5] { 2, 3, 4, 5, 6 };
            innerLevels = innerLevels.OrderBy(x => rand.Next()).ToArray();
            LevelOrder = new int[7];
            LevelOrder[0] = 1;
            for (int i = 0; i < 5; i++)
            {
                LevelOrder[i + 1] = innerLevels[i];
            }
            LevelOrder[6] = 7;
        }
        protected override void Initialize()
        {
            mouseController = new MouseController2();
            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();
            quitpauseController = new QuitPauseController();
            
            //CD = CollisionDetector.getCD().DetectColDirection(Mario.GetMario(), Castle.GetCastle());
            Graphics.PreferredBackBufferWidth = (int)LEVELSIZE.X;
            Graphics.PreferredBackBufferHeight = (int)LEVELSIZE.Y;
            Graphics.ApplyChanges();
            currState = GameModes.NORMAL;
            _Camera2D = new Camera(GraphicsDevice.Viewport);

            #region Command Mapping


            quitpauseController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.R, new LevelReset(this), BindingType.PRESSED);
            gamepadController.UpdateBinding(Buttons.Start, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
           
            #endregion

            base.Initialize();
        }
          

        protected override void LoadContent()
        {
            //Loading the images, and creating the sprites too
            BackgroundSpriteFactory.getFactory().LoadContent(Content);
            ItemSpriteFactory.getFactory().LoadContent(Content);
            BlockSpriteFactory.getFactory().LoadContent(Content);
            EnemySpriteFactory.getFactory().LoadContent(Content);
            MarioSpriteFactory.getSpriteFactory().LoadContent(Content);
            ProjectileSpriteFactory.getSpriteFactory().LoadContent(Content);
            Mario.LoadContent(Content);
            BindingCmd.SetGameBinding(keyboardController, gamepadController, quitpauseController, mouseController);
            // set game binding
            //Starting the sprite batch on our new graphics device
            //move init and loading of textures?
            sBatch = new SpriteBatch(GraphicsDevice);
            //Loading the fonts
            HUDFont = Content.Load<SpriteFont>("Fonts/Arial");
            MusicPlayer.GetMusicPlayer().LoadSongs(Content);
            SoundEffectPlayer.GetSoundEffectPlayer().LoadSoundEffects(Content);
            MusicPlayer.GetMusicPlayer().PlaySong();
            Restart();
        }
        public void Restart(String level)
        {
            Hook_Shot_Pool.GetHook_ShotPool().RefillPool();
            MusicPlayer.GetMusicPlayer().ChangeSong((int)MusicPlayer.Songs.DUNGEON);
            SPLASH_BACK = true;
            switched = false;
            SpriteList = new List<ISprite>();
            Mario.GetMario().StatePowerup = new SmallMario(Mario.GetMario());
            LevelLoader.LevelLoader.GetLevelLoader().LoadLevel("Level/level_" + LevelOrder[level_index] + ".txt");
            if(piped)
                Mario.GetMario().Pos = PipeExit;
            CollisionManager.getCM().Init();
            CollisionManager.getCM().RegMoving(Mario.GetMario());
        }
        public void Restart()
        {
            SPLASH_BACK = true;
            switched = false;
            MusicPlayer.GetMusicPlayer().StopSong();
            MusicPlayer.GetMusicPlayer().ChangeSong((int)MusicPlayer.Songs.INTRO);
            SpriteList = new List<ISprite>();
            Mario.GetMario().StatePowerup = new SmallMario(Mario.GetMario());
            Mario.GetMario().Reset();
            underGround = false;
            LevelLoader.LevelLoader.GetLevelLoader().LoadLevel("Level/level_1.txt");
            CollisionManager.getCM().Init();
            CollisionManager.getCM().RegMoving(Mario.GetMario());
            currState = GameModes.START;
            Mario.GetMario().resetTimer();
            isTimeCounting = true;
            counter = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            if(Mario.GetMario().Lives == 0)
            {
                var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.GAMEOVER;
                MediaPlayer.Stop();
                Mario.GetMario().Lives--;
                currState = GameModes.OVER;
            }
            quitpauseController.UpdateInput();
            if (currState != GameModes.PAUSE)
            {
                timeCount(gameTime, Mario.GetMario());
                Mode.GetMode().Update();
                //iterate over all of the sprites and run their update methods every iteration
                foreach (ISprite spriteEntry in SpriteList.ToImmutableList())
                {
                    spriteEntry.Update();
                }
                CollisionManager.getCM().Update();
                base.Update(gameTime);
                mouseController.UpdateInput();
                keyboardController.UpdateInput();
                gamepadController.UpdateInput();
            }

            _Camera2D.LookAt(Mario.GetMario().Pos);
            _Camera2D.Limits = new Rectangle(0, 0, 10010, 1080);

            if (level_update)
            {
                Restart("oops");
                piped = true;
                level_update = false;
            }
            if(currState == GameModes.START)
            {
              
                isTimeCounting = false;
                keyboardController.ClearBinding();
                gamepadController.ClearBinding();
                quitpauseController.ClearBinding();
                keyboardController.UpdateBinding(Keys.Y, new IntCmd(new KeyValuePair<Action<int>, int>(StartGame, 0)), BindingType.PRESSED);
                keyboardController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            }
            if (currState == GameModes.OVER)
            {
                isTimeCounting = false;
                keyboardController.ClearBinding();
                gamepadController.ClearBinding();
                quitpauseController.ClearBinding();
                keyboardController.UpdateBinding(Keys.Y, new LevelReset(this), BindingType.PRESSED);
                keyboardController.UpdateBinding(Keys.O, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            }
            if (currState == GameModes.WIN)
            {
                isTimeCounting = false;
                keyboardController.ClearBinding();
                gamepadController.ClearBinding();
                quitpauseController.ClearBinding();
                keyboardController.UpdateBinding(Keys.R, new LevelReset(this), BindingType.PRESSED);
                keyboardController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            }
            if(currState == GameModes.NORMAL)
            {
                isTimeCounting = true;
                BindingCmd.SetGameBinding(keyboardController, gamepadController, quitpauseController, mouseController);
                quitpauseController.UpdateBinding(Keys.Q, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
                keyboardController.UpdateBinding(Keys.R, new LevelReset(this), BindingType.PRESSED);
                gamepadController.UpdateBinding(Buttons.Start, new IntCmd(new KeyValuePair<Action<int>, int>(ExitWithCode, 0)), BindingType.PRESSED);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (SPLASH_BACK)
            {
                GraphicsDevice.Clear(Color.Black);
                splashback_timer++;
                if (splashback_timer > 30)
                {
                    SPLASH_BACK = false;
                    splashback_timer = 0;
                }
                return;
            }
            if (currState != GameModes.OVER && currState != GameModes.WIN)
            {
                if (underGround)
                {
                    GraphicsDevice.Clear(Color.Black);
                    sBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _Camera2D.GetViewMatrix(new Vector2(1f)));
                    foreach (ISprite spriteEntry in SpriteList)
                    {
                        spriteEntry.Draw(sBatch);
                    }
                    //Write text onto the screen in a nice method
                    sBatch.End();
                }

                else
                {
                    GraphicsDevice.Clear(Color.CornflowerBlue);

                    sBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
                    sBatch.Draw(BackgroundSpriteFactory.getFactory().BackgroundSpriteSheet, new Vector2(0, 478), new Rectangle((int)(_Camera2D.Position.X * 0.5f), (int)(_Camera2D.Position.Y * 0.5f), BackgroundSpriteFactory.getFactory().BackgroundSpriteSheet.Width,
                       BackgroundSpriteFactory.getFactory().BackgroundSpriteSheet.Height), Color.White);
                    sBatch.End();

                    sBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _Camera2D.GetViewMatrix(new Vector2(1f)));
                    foreach (ISprite spriteEntry in SpriteList)
                    {
                        spriteEntry.Draw(sBatch);
                    }
                    //Write text onto the screen in a nice method
                    sBatch.End();
                    if(currState == GameModes.START)
                    {
                        sBatch.Begin();
                        sBatch.Draw(BackgroundSpriteFactory.getFactory().StartScreen, new Vector2(400, 200), new Rectangle (0, 0, BackgroundSpriteFactory.getFactory().StartScreen.Width, BackgroundSpriteFactory.getFactory().StartScreen.Height), Color.White);
                        sBatch.DrawString(HUDFont, "Press Y to start", new Vector2(600, 450), Color.Black);
                        sBatch.DrawString(HUDFont, "Press Q to quit", new Vector2(1150, 450), Color.Black);
                        sBatch.End();
                    }
                }
            }
            else if(currState == GameModes.OVER)
            {

                GraphicsDevice.Clear(Color.White);
                sBatch.Begin();
                sBatch.Draw(BackgroundSpriteFactory.getFactory().GameOverScreen, new Vector2(0, 0), new Rectangle(-200,0,1920,1080), Color.White);
                sBatch.DrawString(HUDFont, "Press Y to restart", new Vector2(300, 800), Color.White);
                sBatch.DrawString(HUDFont, "Press O to quit", new Vector2(1350, 800), Color.White);
                sBatch.End();
            }
            else
            {
                sBatch.Begin();
                sBatch.Draw(BackgroundSpriteFactory.getFactory().WinningScreen, new Vector2(0, 0), new Rectangle(-200, 0, 2224, 1668), Color.White);
                sBatch.DrawString(HUDFont, "Press R to replay", new Vector2(300, 900), Color.Black);
                sBatch.DrawString(HUDFont, "Press Q to quit", new Vector2(1350, 900), Color.Black);
                sBatch.End();
            }

            //Uses AlphaBlend by default, which allows the sprites to easily blend with backgrounds they match with
            //Iterate over the sprite entry list again and draw each sprite

            base.Draw(gameTime);
            
        }
        private void ExitWithCode(int errCode) {
            Console.WriteLine(errCode);
            Exit();
        }
        public void StartGame(int errCode)
        {
            currState = GameModes.NORMAL;
        }
        public static void DebugBBox(int errCode)
        {
            DEBUGBBOX = !DEBUGBBOX;
        }
        public static void PauseGame(int errCode)
        {
            PAUSE = !PAUSE;
            if (PAUSE)
            {
                currState = GameModes.PAUSE;
                var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.PAUSE;
                MediaPlayer.Pause();
            }
            else
            {
                currState = GameModes.NORMAL;
                MediaPlayer.Resume();
            }
        }

        public static void onFlagChanged(int sound)
        {
            SoundEffectPlayer.GetSoundEffectPlayer().PlaySounds(sound);
        }

        public void timeCount(GameTime gameTime, Mario mario)
        {
            if (isTimeCounting)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter >= 1000)
                {
                    mario.Time--;
                    counter = 0;
                }
            }
            if (mario.Time == 0)
            {
                isTimeCounting = false;
                Mario.GetMario().ChangePowerup(4); // Mario dies
                currState = GameModes.OVER;
            }
            if(mario.Time == 100)
            {
                MediaPlayer.Pause();
                var soundEffectPlayer = SoundEffectPlayer.GetSoundEffectPlayer();
                soundEffectPlayer.PlaySoundEffect += new delEventHandler(onFlagChanged);
                soundEffectPlayer.Trigger = (int)SoundEffectPlayer.Sounds.WARNING;
                mario.Time--;
                
                MediaPlayer.Resume();
            }
        }
    }
}