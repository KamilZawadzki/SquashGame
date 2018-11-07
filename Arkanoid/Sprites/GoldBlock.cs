using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid.Sprites
{
    class GoldBlock : Sprite
    {
        Texture2D _texture;
        public GoldBlock(Texture2D texture) : base(texture)
        {
            _texture = texture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
        
            
            // TODO: trzeba ogarnąć te kolizje

                //if (sprites[1].Velocity.X > 0 && this.IsTouchingLeft(sprites[1]))
                //{
                //    sprites[1].Velocity.X = -sprites[1].Velocity.X;
                //    sprites.Remove(this);
                //    Console.WriteLine("LEFT");


                //}
                //if (sprites[1].Velocity.X < 0 && this.IsTouchingRight(sprites[1]))
                //{
                //    sprites[1].Velocity.X = -sprites[1].Velocity.X;
                //    sprites.Remove(this);
                //    Console.WriteLine("RIGHT");

                //}
                //if (sprites[1].Velocity.Y < 0 && this.IsTouchingTop(sprites[1]))
                //{
                //    sprites[1].Velocity.Y = -sprites[1].Velocity.Y;
                //    sprites.Remove(this);   
                //    Console.WriteLine("TOP");

                //}
                //if ( this.IsTouchingBottom(sprites[1]))
                //{
                //    sprites[1].Velocity.Y = -sprites[1].Velocity.Y;
                //    sprites.Remove(this);      
                //    Console.WriteLine("Bottom");

                //}

            
            //base.Update(gameTime, sprites);
        }
    }
}
