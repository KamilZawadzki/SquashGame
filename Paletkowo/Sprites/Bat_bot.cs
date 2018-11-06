using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paletkowo.Sprites
{
    class Bat_bot : Sprite
    {
        public Bat_bot(Texture2D texture)
            : base(texture)
        {
            Speed = 5f;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (sprites[1].Position.Y > 150)
            {
                if (sprites[1].Position.X<sprites[5].Position.X)
                {
                    Velocity.X = -Speed;
                    Position = Position + Velocity;
                    Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - _texture.Width);
                    Velocity = Vector2.Zero;
                }
                if(sprites[1].Position.X>sprites[5].Position.X)
                {
                    Velocity.X = Speed;
                    Position = Position + Velocity;
                    Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - _texture.Width);
                    Velocity = Vector2.Zero;
                }    
            }
        }

    }
}
