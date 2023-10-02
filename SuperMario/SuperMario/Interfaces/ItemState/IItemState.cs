using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Sprites.ItemSprites;

namespace SprintZeroSpriteDrawing.Interfaces.ItemState
{
    public enum State
    {

        EMERGING,
        IDLE,
        COLLECTING
    }
    public class IItemState
    {
        protected Item item;
        public State CurrState { get; set; }
        public IItemState(Item nItem)
        {
            item = nItem;
            Enter();
        }
        public virtual void Update() { }
        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void ChangeState(int state)
        {
            Exit();
            switch ((State)state)
            {
                case State.EMERGING:
                    item.State = new Emerging(item);
                    break;
                case State.IDLE:
                    item.State = new Idle(item);
                    break;
                case State.COLLECTING:
                    item.State = new Collecting(item);
                    break;
            }
        }
    }
}
