using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Arkanoid.Models;
using Arkanoid.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Sprites
{
   class  Ball : Sprite
    {
        private Vector2? _startPosition = null;
        private float? _startSpeed;
            
        public bool restart = false;      
        public Ball(Texture2D texture)
          : base(texture)
        {         
            Speed = Game1.globals.BallSpeed;  
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Speed = Game1.globals.BallSpeed;
            if (_startPosition == null)
            {
                _startPosition = Position;
                _startSpeed = Speed;

                Restart();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Game1.globals.isPlaying = true;
            if (!Game1.globals.isPlaying)
            {
                positionToPaddle(sprites);
                return;
            }
            for (int i=0;i<sprites.Count; i++)
            {
                var sprite = sprites[i];
                if (sprite == this)
                    continue;

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;
                   //if(sprite is GoldBlock)
                   // {
                   //     sprites.Remove(sprite);
                   // }
                   // if (sprite is RedBlock)
                   // {
                   //     if (sprite.life == 1)
                   //     {
                   //         sprites.Remove(sprite);
                   //     }
                   //     sprite.life = 1;
                   // }
                }

                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;
                    //if (sprite is GoldBlock)
                    //{
                    //    sprites.Remove(sprite);
                    //}
                    //if(sprite is RedBlock)
                    //{
                    //    if(sprite.life==1)
                    //    {
                    //        sprites.Remove(sprite);
                    //    }
                    //    if(sprites.Count!=1)
                    //    {
                    //        sprite.life = 1;
                    //    }

                        

                    //}

                }

                    if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;
                    //if (sprite is GoldBlock)
                    //{
                    //    sprites.Remove(sprite);
                    //}
                    //if (sprite is RedBlock)
                    //{
                    //    if (sprite.life == 1)
                    //    {
                    //        sprites.Remove(sprite);
                    //    }
                    //    sprite.life = 1;
                    //}

                }

                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;
                    //if (sprite is GoldBlock)
                    //{
                    //    sprites.Remove(sprite);
                    //}
                    //if (sprite is RedBlock)
                    //{
                    //    if (sprite.life == 1)
                    //    {
                    //        sprites.Remove(sprite);
                    //    }
                    //    sprite.life--;
                    //}
                }
               
            }

            if (Position.Y <= 0)
            {
                Velocity.Y = -Velocity.Y;              
            }
               
            else if (Position.Y + _texture.Height >= Game1.globals.ScreenHeight)
            {
                Restart();
                restart = true;   
            }

            if (Position.X <= 0 || Position.X + _texture.Width >= Game1.globals.ScreenWidth)
            {
                Velocity.X = -Velocity.X;
            }
      
            Position += Velocity * Speed;
        }

        private void positionToPaddle(List<Sprite> sprites)
        {
            Vector2 pos = sprites[0].Position;
            pos.X += (sprites[0]._texture.Width / 2) - (this._texture.Width / 2);
            pos.Y -= sprites[0]._texture.Height;
            Position = pos;
        }

        public void Restart()
        {
            var direction = Game1.globals.Random.Next(0, 2);

            switch (direction)
            {
                case 0:
                    Velocity = new Vector2(1, -1);
                    break;
                case 1:
                    Velocity = new Vector2(-1, -1);
                    break;      
            }      
            Speed = (float)_startSpeed;
            Game1.globals.isPlaying = false;
      
        }
    }
}
