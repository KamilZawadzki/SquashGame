using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Sprites
{
    class Paddle : Sprite
    {

        public Paddle(Texture2D texture) : base(texture)
        {
            Speed = 5f;        
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Input == null)
                throw new Exception("Please give value to Input");

            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;

            Position += Velocity;
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.globals.ScreenWidth - _texture.Width);
            Velocity = Vector2.Zero;
        }
    }
}
