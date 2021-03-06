﻿using Arkanoid.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Sprites
{
    class Sprite
    {
        public Texture2D _texture { get; set; }

        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;
        public Input Input;
        public bool Player = true;
        public int life=2;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        #region Collision
        protected bool IsTouchingLeft(Sprite sprite)
        {
            
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Left &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;     
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
            
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Top &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right;
           
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
                this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                this.Rectangle.Right > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Right;
            
        }




        #endregion

        #region Collisions with Blocks
        protected bool IsTop(Sprite sprite)
        {
            return this.Rectangle.Bottom > sprite.Rectangle.Top + sprite.Velocity.Y &&
                  this.Rectangle.Top < sprite.Rectangle.Top &&
                  this.Rectangle.Right > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsRight(Sprite sprite)
        {

            return this.Rectangle.Left < sprite.Rectangle.Right + sprite.Velocity.X &&
              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;

        }
        protected bool IsLeft(Sprite sprite)
        {

            return this.Rectangle.Right > sprite.Rectangle.Left + sprite.Velocity.X &&
              this.Rectangle.Left < sprite.Rectangle.Left &&
              this.Rectangle.Bottom > sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsBottom(Sprite sprite)
        {

            return this.Rectangle.Top < sprite.Rectangle.Bottom + sprite.Velocity.Y &&
                this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                this.Rectangle.Right > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Right;

        }
        #endregion



    }
}
