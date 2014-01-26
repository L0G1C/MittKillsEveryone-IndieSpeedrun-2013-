using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MitKillsEveryone.Entities
{
    public class Sprite
    {        
        private Vector2 position;
        private readonly Rectangle movementBounds;
        private int rows;
        private int columns;
        private double framesPerSecond;
        private int totalFrames;
        private double timeSinceLastFrame;
        private int currentFrame;
        protected bool AnimationPlayedOnce;


        #region props
        public Texture2D Texture { get; set; }
        public Vector2 Velocity { get; set; }
        protected float Speed { get; set; }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public double FramesPerSecond
        {
            get { return framesPerSecond; }
            set { framesPerSecond = value; }
        }

        public int TotalFrames
        {
            get { return totalFrames; }
            set { totalFrames = value; }
        }

        public int CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public bool Flip { get; set; }

        public float Width { get { return Texture.Width / columns; } }
        public float Height { get { return Texture.Height / rows; } }
        public Rectangle BoundingBox
        {
            get { return CreateBoundingBoxFromPosition(position); }
        }

        #endregion


        public Sprite(Texture2D texture, Vector2 position, Rectangle movementBounds)
            : this(texture, position, movementBounds, 1, 1, 1)
        {
        }

        /// <summary>
        /// Main Constructor.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="movementBounds"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="framesPerSecond"></param>
        /// <param name="totalFrames"></param>
        public Sprite(Texture2D texture, Vector2 position, Rectangle movementBounds, int rows, int columns, double framesPerSecond, int totalFrames = 0)
        {
            this.Texture = texture;
            this.position = position;
            this.movementBounds = movementBounds;
            this.rows = rows;
            this.columns = columns;
            this.framesPerSecond = framesPerSecond;

            if (totalFrames == 0)
                this.totalFrames = rows * columns;
            else
                this.totalFrames = totalFrames;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            var imageWidth = Texture.Width / columns;
            var imageHeight = Texture.Height / rows;

            var currentRow = currentFrame / columns;
            var currentColumn = currentFrame % columns;


            var sourceRectangle = new Rectangle(imageWidth * currentColumn, imageHeight * currentRow, imageWidth, imageHeight);

            var destinationRectangle = new Rectangle((int)position.X, (int)position.Y, imageWidth, imageHeight);

            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);    
            
            

            //spriteBatch.Draw(texture, position, Color.White);
        }


        public virtual void Update(GameTime gameTime)
        {
            UpdateAnimation(gameTime);

            //Get X and Y updates separately
            var newPositionX = position.X + ((Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds) * Speed);
            var newPositionY = position.Y + ((Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds) * Speed);

            //checking x and y separately for recangle collision, so diagnol move does not stop sprite            
            if (Blocked(new Vector2(newPositionX, position.Y)) && !Blocked(new Vector2(position.X, newPositionY)))
                position = new Vector2(position.X, newPositionY);

            else if (Blocked(new Vector2(position.X, newPositionY)) && !Blocked(new Vector2(newPositionX, position.Y)))
                position = new Vector2(newPositionX, position.Y);

            else if (Blocked(new Vector2(newPositionX, newPositionY)))
                return;
            else

                position = new Vector2(newPositionX, newPositionY);
        }

        private void UpdateAnimation(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceLastFrame > SecondsBetweenFrames())
            {
                currentFrame++;
                timeSinceLastFrame = 0;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
                AnimationPlayedOnce = true; 
            }
        }


        private bool Blocked(Vector2 newPosition)
        {
            var boundingBox = CreateBoundingBoxFromPositionForBlocked(newPosition);
            return !movementBounds.Contains(boundingBox);
        }

        private Rectangle CreateBoundingBoxFromPosition(Vector2 position)
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)Width, (int)Height);
        }

        private Rectangle CreateBoundingBoxFromPositionForBlocked(Vector2 position)
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)Width, (int)Height);
        }


        private double SecondsBetweenFrames()
        {
            return 1 / framesPerSecond;
        }
    }
}
