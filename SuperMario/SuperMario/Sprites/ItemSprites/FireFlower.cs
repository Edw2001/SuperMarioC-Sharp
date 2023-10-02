using SprintZeroSpriteDrawing.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;
using SprintZeroSpriteDrawing.Music_SoundEffects;

namespace SprintZeroSpriteDrawing.Sprites.ItemSprites
{
    public class FireFlower : Item
    {
        
        public FireFlower(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
        {
            CollideableType = CType.FLOWER;
        }
        public override void Update()
        {
            base.Update();
            if (State.CurrState == Interfaces.ItemState.State.IDLE)
            {
                Velocity = new Vector2(0, 0);
                Acceleration = new Vector2(0, 0);
            }
            
        }
       
    }
}
    
        
    

