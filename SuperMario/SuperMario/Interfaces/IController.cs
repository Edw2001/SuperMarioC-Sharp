using System;
using System.Collections.Generic;
using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace SprintZeroSpriteDrawing.Interfaces
{
    public enum BindingType{
        PRESSED = 0,
        HELD = 1,
        RELEASED = 2
    }

    /// <summary>
    /// This code sets up the requirements for a controller specifying
    /// a command binding list and an input updating method to fire commands.
    /// </summary>
    /// <typeparam name="T"> This is the type of trigger: (Keys, Buttons, Etc)</typeparam>
    public class IController<T>
    {
        /// <summary>
        /// This maps the commands assositated with each key
        /// </summary>
        protected List<Dictionary<T, ICommand>> CommandBindingList { get; set; }
        public IController()
        {
            CommandBindingList = new List<Dictionary<T, ICommand>>()
            {
                new Dictionary<T, ICommand>(),
                new Dictionary<T, ICommand>(),
                new Dictionary<T, ICommand>()
            };
        }


        public virtual void UpdateInput()
        {
            throw new NotImplementedException("Implement Controllers Update Input Method");
        }
        //This could really be an abstract class... The update bindings method is the same either way
        public void UpdateBinding(T key, ICommand command, BindingType bindingType)
        {
            if (!CommandBindingList[(int)bindingType].TryAdd(key, command))
            {
                CommandBindingList[(int)bindingType].Remove(key);
                CommandBindingList[(int)bindingType].Add(key, command);
            }
        }

        public void ReplaceBinding(List<Dictionary<T, ICommand>> nCommandBindingList)
        {
            CommandBindingList = nCommandBindingList;
        }
        public void ClearBinding()
        {
            CommandBindingList = new List<Dictionary<T, ICommand>>()
            {
                new Dictionary<T, ICommand>(),
                new Dictionary<T, ICommand>(),
                new Dictionary<T, ICommand>()
            };
        }
        public bool RemoveBinding(T key, BindingType bindingType)
        {
            if (CommandBindingList[(int)bindingType].ContainsKey(key))
            {
                CommandBindingList[(int)bindingType].Remove(key);
                return true;
            }
            return false;
        }
        public void RemoveBinding(T key)
        {
            foreach (Dictionary<T, ICommand> bindingList in CommandBindingList)
            {
                if (bindingList.ContainsKey(key))
                {
                    bindingList.Remove(key);
                }
            }
        }
    }
}
