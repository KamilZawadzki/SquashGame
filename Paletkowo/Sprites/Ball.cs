using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Paletkowo.Models;
using Paletkowo.States;
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
        public bool restart = false;
        private bool check_hit = false;
        
    
        public Ball(Texture2D texture)
          : base(texture)
        {         
            Speed = 3f;
            Game1.punkty.score_bot = 0;
            Game1.punkty.score_player = 0;
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
                         if(check_hit==false)
                            {
                                if (Player==true)
                                {
                                    Console.WriteLine("hit");
                                    Game1.punkty.score_player++;
                                    Player =false;
                                    Console.WriteLine("Player score: " + Game1.punkty.score_player);
                                    check_hit = true;
                                }
                                else
                                {
                                    Console.WriteLine("hit");
                                    Game1.punkty.score_bot++;
                                    Player = true;
                                    Console.WriteLine("Bot score: " + Game1.punkty.score_bot);
                                    check_hit = true;
                                }
                                
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
                else
                {
                    if (sprite == sprites[0])
                    {
                        if (Player == true)
                        {
                            if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                            {
                                check_hit = false;
                             //   Player = false;
                                Console.WriteLine(Player.ToString());
                                this.Velocity.X = -this.Velocity.X;
                            }
                            
                            if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                            {
                                check_hit = false;
                            //    Player = false;
                                Console.WriteLine(Player.ToString());
                                this.Velocity.X = -this.Velocity.X;
                            }
                           
                            if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                            {
                                check_hit = false;
                             //   Player = false;
                                Console.WriteLine(Player.ToString());
                                this.Velocity.Y = -this.Velocity.Y;
                            }
                            
                            if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                            {
                                check_hit = false;
                             //   Player = false;
                                Console.WriteLine(Player.ToString());
                                this.Velocity.Y = -this.Velocity.Y;
                            }
                               
                        }
                        
                    }
                    else
                    {
                        if(sprite==sprites[5])
                        {
                            if(Player==false)
                            {
                                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                                {
                                //    Player = true;
                                    Console.WriteLine(Player.ToString());
                                    this.Velocity.X = -this.Velocity.X;
                                    check_hit = false;
                                }
                                    
                                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                                {
                                //    Player = true;
                                    Console.WriteLine(Player.ToString());
                                    this.Velocity.X = -this.Velocity.X;
                                    check_hit = false;
                                }
                                   
                                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                                {
                                 //   Player = true;
                                    Console.WriteLine(Player.ToString());
                                    this.Velocity.Y = -this.Velocity.Y;
                                    check_hit = false;
                                }
                                    
                                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                                {
                                //    Player = true;
                                    Console.WriteLine(Player.ToString());
                                    this.Velocity.Y = -this.Velocity.Y;
                                    check_hit = false;
                                }
                                    
                               
                            }   
                           
                        }
                    }
                }
                
            }

            if (Position.Y <= 0)
            {
                Velocity.Y = -Velocity.Y;
                if (check_hit == false)
                {
                    if(Player==true)
                    {
                        Game1.punkty.score_player--;
                        Console.WriteLine("Player score: " + Game1.punkty.score_player);
                        Player = false;
                        check_hit = true;
                    }
                    else
                    {
                        Game1.punkty.score_bot--;
                        Console.WriteLine("Bot score: " + Game1.punkty.score_bot);
                        Player = true;
                        check_hit = true;
                    }
                    
                }  
            }
               
            else if (Position.Y + _texture.Height >= Game1.ScreenHeight)
            {
                if (Player == true)
                {
                    Game1.punkty.score_player--;
                    Console.WriteLine("Player score: " + Game1.punkty.score_player);
                }
                else
                {
                    Game1.punkty.score_bot--;
                    Console.WriteLine("Bot score: " + Game1.punkty.score_bot);
                }
                Restart();
                restart = true;
   
            }
               
            if (Position.X <= 0 || Position.X + _texture.Width >= Game1.ScreenWidth)
            {
                Velocity.X = -Velocity.X;
                
                if (check_hit == false)
                {
                    if(Player==true)
                    {
                        Game1.punkty.score_player--;
                        Console.WriteLine("Player score: " + Game1.punkty.score_player);
                        Player = false;
                        check_hit = true;
                    }
                    else
                    {
                        Game1.punkty.score_bot--;
                        Console.WriteLine("Bot score: " + Game1.punkty.score_bot);
                        Player = true;
                        check_hit = true;
                    }                   
                }
            }
               


            Position += Velocity * Speed;
        }

        public void Restart()
        {
            var direction = Game1.Random.Next(0, 2);

            switch (direction)
            {
                case 0:
                    Velocity = new Vector2(1, 1);
                    break;
                case 1:
                    Velocity = new Vector2(-1, 1);
                    break;      
            }
            Position = (Vector2)_startPosition;
            Speed = (float)_startSpeed;
            _isPlaying = false;
        }
    }
}
