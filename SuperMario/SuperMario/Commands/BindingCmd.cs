using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using SprintZeroSpriteDrawing.Sprites.MarioSprites;
using SprintZeroSpriteDrawing;
using SprintZeroSpriteDrawing.Interfaces.MarioState;
using SprintZeroSpriteDrawing.GameMode;
using SprintZeroSpriteDrawing.Interfaces.GameState;
using SprintZeroSpriteDrawing.Music_SoundEffects;
using SprintZeroSpriteDrawing.Controllers;
using SprintZeroSpriteDrawing.States.MarioState;
using SprintZeroSpriteDrawing.Sprites.ToolSprites;

namespace SprintZeroSpriteDrawing.Commands
{
    public class BindingCmd
    {
        public static void SetGameBinding(IController<Keys> keyboardController, IController<Buttons> gamepadController, IController<Keys> QuitPauseController, MouseController2 mouseController)
        {
            keyboardController.ClearBinding();
            gamepadController.ClearBinding();
            QuitPauseController.ClearBinding();
            keyboardController.UpdateBinding(Keys.C, new IntCmd(new KeyValuePair<Action<int>, int>(Game1.DebugBBox, -1)), BindingType.PRESSED);
            QuitPauseController.UpdateBinding(Keys.P, new IntCmd(new KeyValuePair<Action<int>, int>(Game1.PauseGame, -1)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.A, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().MoveAction, -1)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Left, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().MoveAction, -1)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.D, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().MoveAction, 1)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Right, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().MoveAction, 1)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.A, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, (int)(ActionState.IDLE))), BindingType.RELEASED);
            keyboardController.UpdateBinding(Keys.Left, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, (int)(ActionState.IDLE))), BindingType.RELEASED);

            keyboardController.UpdateBinding(Keys.D, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, (int)(ActionState.IDLE))), BindingType.RELEASED);
            keyboardController.UpdateBinding(Keys.Right, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, (int)(ActionState.IDLE))), BindingType.RELEASED);

            keyboardController.UpdateBinding(Keys.O, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().TakeDamage, -1)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.W, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().IncreaseAction, (int)ActionState.JUMPING)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Up, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().IncreaseAction, (int)ActionState.JUMPING)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.S, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().DecreaseAction, (int)ActionState.CROUCHING)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.Down, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().DecreaseAction, (int)ActionState.CROUCHING)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.M, new IntCmd(new KeyValuePair<Action<int>, int>(MusicPlayer.GetMusicPlayer().Mute, 0)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.D1, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeItem, (int)EquippableItems.SWORD)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.D2, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeItem, (int)EquippableItems.SHIELD)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.D3, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeItem, (int)EquippableItems.BOW)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.D4, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeItem, (int)EquippableItems.BOMB)), BindingType.PRESSED);
            keyboardController.UpdateBinding(Keys.D5, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeItem, (int)EquippableItems.HOOKSHOT)), BindingType.PRESSED);

            keyboardController.UpdateBinding(Keys.Space, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().UseItem, 0)), BindingType.PRESSED);
 

            gamepadController.UpdateBinding(Buttons.LeftStick, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, -1)), BindingType.PRESSED);
            gamepadController.UpdateBinding(Buttons.RightStick, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, 1)), BindingType.PRESSED);

            gamepadController.UpdateBinding(Buttons.DPadUp, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, 3)), BindingType.PRESSED);
            gamepadController.UpdateBinding(Buttons.DPadDown, new IntCmd(new KeyValuePair<Action<int>, int>(Mario.GetMario().ChangeAction, 4)), BindingType.PRESSED);
        }
    }
}
