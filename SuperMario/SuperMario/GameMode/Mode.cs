using SprintZeroSpriteDrawing.Interfaces.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZeroSpriteDrawing.GameMode
{
    public class Mode
    {

        private static Mode _mode;
        public IGameState State { get; set; }

        public static Mode GetMode()
        {
            if(_mode == null) _mode = new Mode();
            return _mode;
        }
        public Mode()
        {
            State = new GameNormal(this);
        }

        public void ChangeState(int state)
        {
            this.State.ChangeState(state);
        }

        public void ToggleDebugBoxes(bool toggle)
        {
            toggle = !toggle;
        }

        public void Update()
        {
            State.Update();
        }



    }
}
