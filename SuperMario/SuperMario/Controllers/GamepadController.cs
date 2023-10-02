using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Controllers
{
    public class GamepadController : IController<Buttons>
    {
        GamePadState previousState;
        int playerIndex = 0;
        public GamepadController() {
            previousState = GamePad.GetState(playerIndex);
        }
        public GamepadController(int nPlayerIndex)
        {
            playerIndex = nPlayerIndex;
            previousState = GamePad.GetState(playerIndex);
        }

        public bool PluggedIn()
        {
            return GamePad.GetState(playerIndex).IsConnected;
        }

        public override void UpdateInput() {
            if (PluggedIn())
            {
                GamePadState CurrentState = GamePad.GetState(playerIndex);
                foreach (KeyValuePair<Buttons, ICommand> command in CommandBindingList[(int)BindingType.PRESSED])
                {
                    if (CurrentState.IsButtonDown(command.Key) && !previousState.IsButtonDown(command.Key))
                        CommandBindingList[(int)BindingType.PRESSED][command.Key].Execute();
                }

                foreach (KeyValuePair<Buttons, ICommand> command in CommandBindingList[(int)BindingType.HELD])
                {
                    if (CurrentState.IsButtonDown(command.Key) && previousState.IsButtonDown(command.Key))
                        CommandBindingList[(int)BindingType.HELD][command.Key].Execute();
                }

                foreach (KeyValuePair<Buttons, ICommand> command in CommandBindingList[(int)BindingType.RELEASED])
                {
                    if (!CurrentState.IsButtonDown(command.Key) && previousState.IsButtonDown(command.Key))
                        CommandBindingList[(int)BindingType.RELEASED][command.Key].Execute();
                }

                previousState = CurrentState;
            }
        }
    }
}
