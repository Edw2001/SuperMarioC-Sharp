using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZeroSpriteDrawing.Interfaces.Entitiy;

namespace SprintZeroSpriteDrawing.Sprites.ObstacleSprites
{
    internal class FourExplodingBrick : Block
    {   
        List<Block> blocks = new List<Block>();
        public FourExplodingBrick(Texture2D SpriteSheet, Vector2 nSheetSize, Vector2 nPos) : base(SpriteSheet, nSheetSize, nPos)
        {
            if (Game1.underGround)
            {
                blocks.Add(new UGExplo(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(1, -4), new Vector2(0, (float)0.05)));
                blocks.Add(new UGExplo(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(-1, -4), new Vector2(0, (float)0.05)));
                blocks.Add(new UGExplo(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(1, -2), new Vector2(0, (float)0.05)));
                blocks.Add(new UGExplo(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(-1, -2), new Vector2(0, (float)0.05)));
            }
            else
            {
                blocks.Add(new ExplodingBrickBlock(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(1, -4), new Vector2(0, (float)0.05)));
                blocks.Add(new ExplodingBrickBlock(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(-1, -4), new Vector2(0, (float)0.05)));
                blocks.Add(new ExplodingBrickBlock(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(1, -2), new Vector2(0, (float)0.05)));
                blocks.Add(new ExplodingBrickBlock(SpriteSheet, new Vector2(2, 2), nPos, new Vector2(-1, -2), new Vector2(0, (float)0.05)));
            }
           
        }
        public override void Update()
        {
            foreach (var block in blocks)
            {
                block.Update();
                
            }
            if (blocks[1].Pos.Y > 1080)
            {
                Game1.SpriteList.Remove(this);
            }


        }
        public override void Draw(SpriteBatch batch)
        {
            foreach (var block in blocks)
            {
                block.Draw(batch);
            }
        }

    }
}
