using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SprintZeroSpriteDrawing.Interfaces;

namespace SprintZeroSpriteDrawing.Controllers
{
    public class MouseController2
    {
        public List<ICommand> LeftMouseCommands;
        public List<ICommand> RightMouseCommands;
        MouseState prevMouseState;
        public MouseController2()
        {
            LeftMouseCommands = new List<ICommand>();
            RightMouseCommands = new List<ICommand>();
            prevMouseState = Mouse.GetState();
        }
        public void RegisterLeftClickCommand(ICommand command)
        {
            LeftMouseCommands.Add(command);
        }
        
        public void RegisterRightClickCommand(ICommand command)
        {
            RightMouseCommands.Add(command);
        }
        public void UpdateInput()
        {
            MouseState mouseState = Mouse.GetState();
            
            foreach (ICommand command in LeftMouseCommands.ToImmutableList())
            {
              if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                  command.Execute();
            }

            prevMouseState = mouseState; 
        }

    }
}
