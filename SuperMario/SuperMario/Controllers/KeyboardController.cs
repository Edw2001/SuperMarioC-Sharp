using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Controllers
{
    /// <summary>
    /// This is a keys based implementation of the IController interface that fires commands
    /// stored in a dictionary when their assosiated keys are pressed
    /// </summary>
    public class KeyboardController : IController<Keys>
    {
        /// <summary>
        /// This is the previous state of the keys array assosiated with
        /// this given keyboard when the last update was called
        /// </summary>
        KeyboardState PreviousState;

        public KeyboardController(){
            PreviousState = Keyboard.GetState();
        }

        public override void UpdateInput() {
            KeyboardState CurrentState = Keyboard.GetState();
            foreach (KeyValuePair<Keys, ICommand> command in CommandBindingList[(int)BindingType.PRESSED].ToImmutableList())
            {
                if (CurrentState.IsKeyDown(command.Key) && !PreviousState.IsKeyDown(command.Key))
                    CommandBindingList[(int)BindingType.PRESSED][command.Key].Execute();
            }

            foreach (KeyValuePair<Keys, ICommand> command in CommandBindingList[(int)BindingType.HELD])
            {
                if (CurrentState.IsKeyDown(command.Key) && PreviousState.IsKeyDown(command.Key))
                    CommandBindingList[(int)BindingType.HELD][command.Key].Execute();
            }

            foreach (KeyValuePair<Keys, ICommand> command in CommandBindingList[(int)BindingType.RELEASED])
            {
                if(!CurrentState.IsKeyDown(command.Key) && PreviousState.IsKeyDown(command.Key))
                    CommandBindingList[(int)BindingType.RELEASED][command.Key].Execute();
            }
            PreviousState = CurrentState;
        }
    }
}
