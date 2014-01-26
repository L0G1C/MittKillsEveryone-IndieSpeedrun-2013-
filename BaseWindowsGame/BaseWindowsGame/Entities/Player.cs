using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MitKillsEveryone.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Entities
{
    public class Player : Sprite
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle movementBounds;
        private readonly InputManager inputManager;
        private ContentManager content;

        public bool PlayerWalking { get; set; }
        //public bool Flip { get; set; }

        //hacking facing direction. ugly.
        string directionKeyboard = "_l";
        string directionController = "_l";

        public Player(Texture2D texture, Vector2 position, Rectangle movementBounds, ContentManager content) 
            : base(texture, position, movementBounds, 1, 1, 1)
        {
            this.texture = texture;
            this.position = position;
            this.movementBounds = movementBounds;
            this.content = content;

            inputManager = new InputManager(this);
            Speed = 400;
        }

        public override void Update(GameTime gameTime)
        {
            
            inputManager.Update(gameTime);                      
            
            //if(GamePad.GetState(PlayerIndex.One).IsConnected)
            //    AnimatePlayerController();
           // else
           // {
                AnimatePlayerKeyboard();                            
            //}
            

            base.Update(gameTime);
        }

        private void AnimatePlayerKeyboard()
        {

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Right) || ((keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Down)) && directionKeyboard == "_r"))
            {
                Texture = content.Load<Texture2D>(@"gfx/player/player_walk_r");
                Rows = 1;
                Columns = 5;
                FramesPerSecond = 11;
                TotalFrames = 5;
                directionKeyboard = "_r";

            }
            else if (keyboardState.IsKeyDown(Keys.Left) || ((keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Down)) && directionKeyboard == "_l"))
            {
                Texture = content.Load<Texture2D>(@"gfx/player/player_walk_l");
                Rows = 1;
                Columns = 5;
                FramesPerSecond = 11;
                TotalFrames = 5;
                directionKeyboard = "_l";
            }
            else
            {

                Texture = content.Load<Texture2D>(@"gfx/player/player_still" + directionKeyboard);
                Rows = 1;
                Columns = 1;
                FramesPerSecond = 0;
                TotalFrames = 1;
                CurrentFrame = 1;
            }
        }

        #region Animations
        private void AnimatePlayerController()
        {

            var gamePadState = GamePad.GetState(PlayerIndex.One);
            if (gamePadState.IsButtonDown(Buttons.LeftThumbstickRight) || ((gamePadState.IsButtonDown(Buttons.LeftThumbstickUp) || gamePadState.IsButtonDown(Buttons.LeftThumbstickDown)) && directionController == "_r"))
            {
                Texture = content.Load<Texture2D>(@"gfx/player/player_walk_r");
                Rows = 1;
                Columns = 5;
                FramesPerSecond = 11;
                TotalFrames = 5;
                directionController = "_r";

            }
            else if (gamePadState.IsButtonDown(Buttons.LeftThumbstickLeft) || ((gamePadState.IsButtonDown(Buttons.LeftThumbstickUp) || gamePadState.IsButtonDown(Buttons.LeftThumbstickDown)) && directionController == "_l"))
            {
                Texture = content.Load<Texture2D>(@"gfx/player/player_walk_l");
                Rows = 1;
                Columns = 5;
                FramesPerSecond = 11;
                TotalFrames = 5;
                directionController = "_l";
            }
            else
            {

                Texture = content.Load<Texture2D>(@"gfx/player/player_still" + directionController);
                Rows = 1;
                Columns = 1;
                FramesPerSecond = 0;
                TotalFrames = 1;
                CurrentFrame = 1;
            }
        }
        #endregion
    }
}
