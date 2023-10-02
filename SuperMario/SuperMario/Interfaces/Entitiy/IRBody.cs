using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZeroSpriteDrawing.Interfaces.Entitiy;

public class IRBody : ITile
{
    public Vector2 Anchor { get; set; }
    public Vector2 Velocity { get; set; }
    public Vector2 Acceleration { get; set; }

    public IRBody(Texture2D nSprite, Vector2 nPos) : base(nSprite, nPos)
    {
        Anchor = nPos;
        Velocity = new Vector2(0, 0);
        Acceleration = new Vector2(0, 0);
    }

    public IRBody(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos) : base(nSprite, nSheetSize, nPos)
    {
        Anchor = nPos;
        Velocity = new Vector2(0, 0);
        Acceleration = new Vector2(0, 0);
    }

    public IRBody(Texture2D nSprite, Vector2 nSheetSize, Vector2 nPos, Vector2 acceleration) : base(nSprite, nSheetSize,
        nPos)
    {
        Anchor = nPos;
        Velocity = new Vector2(0, 0);
        Acceleration = acceleration;
    }

    public override void Update()
    {
        base.Update(); //Framing updates
        Move(Velocity);
        Velocity = Vector2.Add(Velocity, Acceleration);
    }

}