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
    class Ball : Sprite
    {
        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;
        public double score=0;
        public Ball(Texture2D texture)
          : base(texture)
        {
            Speed = 3f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (_startPosition == null)
            {
                _startPosition = Position;
                _startSpeed = Speed;

                Restart();

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _isPlaying = true;
            if (!_isPlaying)
                return;
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (sprite == sprites[2] || sprite == sprites[3] || sprite == sprites[4])
                {
                    if (sprite == sprites[2])
                    {
                        if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                        {
                            Console.WriteLine("hit");                 
                            score++;
                            Console.WriteLine("Score: " + score);
                        }
                    }
                }

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                    this.Velocity.X = -this.Velocity.X;
                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                    this.Velocity.X = -this.Velocity.X;
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                    this.Velocity.Y = -this.Velocity.Y;
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                    this.Velocity.Y = -this.Velocity.Y;


            }

            if (Position.Y <= 0)
            {
                Velocity.Y = -Velocity.Y;
                score--;
                Console.WriteLine("Score: " + score);
            }
               
            else if (Position.Y + _texture.Height >= Game1.ScreenHeight)
            {
                Restart();
                score = 0;
            }
               
            if (Position.X <= 0 || Position.X + _texture.Width >= Game1.ScreenWidth)
            {
                Velocity.X = -Velocity.X;
                score--;
                Console.WriteLine("Score: " + score);
            }
               


            Position += Velocity * Speed;
        }

        public void Restart()
        {
            var direction = Game1.Random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    Velocity = new Vector2(1, 1);
                    break;
                case 1:
                    Velocity = new Vector2(1, -1);
                    break;
                case 2:
                    Velocity = new Vector2(-1, -1);
                    break;
                case 3:
                    Velocity = new Vector2(-1, 1);
                    break;
            }
            Position = (Vector2)_startPosition;
            Speed = (float)_startSpeed;
            _isPlaying = false;
        }
    }
}
