using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.Controllers
{
    public class MouseController : IController<ButtonState>
    {

        /********************/
        /*See MouseController2, I did not figure out how we could inherit Icontroller in case since we don't have a isMouseDown(command.key) command*/
        /********************/

        MouseState CurrentState;
        public MouseController()
        {
            CurrentState = Mouse.GetState();
        }

        public override void UpdateInput()
        {
            MouseState PreviousState = CurrentState;

            foreach (KeyValuePair<ButtonState, ICommand> command in CommandBindingList[(int)BindingType.PRESSED].ToImmutableList())
            {
                if(CurrentState.LeftButton == ButtonState.Pressed && PreviousState.LeftButton == ButtonState.Released)
                    CommandBindingList[(int)BindingType.PRESSED][command.Key].Execute();
            }

            /*foreach (KeyValuePair<Keys, ICommand> command in CommandBindingList[(int)BindingType.HELD])
            {
                if (CurrentState.IsKeyDown(command.Key) && PreviousState.IsKeyDown(command.Key))
                    CommandBindingList[(int)BindingType.HELD][command.Key].Execute();
            }

            foreach (KeyValuePair<Keys, ICommand> command in CommandBindingList[(int)BindingType.RELEASED])
            {
                if (!CurrentState.IsKeyDown(command.Key) && PreviousState.IsKeyDown(command.Key))
                    CommandBindingList[(int)BindingType.RELEASED][command.Key].Execute();
            */
        }
    }
}
