using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MitKillsEveryone.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Managers
{
    public class InputManager
    {
        private Sprite sprite;        

        public InputManager(Sprite sprite)
        {
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {
            //var currentGamePadState = GamePad.GetState(PlayerIndex.One);
            //if (currentGamePadState.IsConnected)
            //{
            //    HandleControllerInput();
            //}
            //else
            //{
                HandleKeyboardInput();
            //}
                  
        }

        private void HandleKeyboardInput()
        {
            var keyboardState = Keyboard.GetState();
            UpdateVelocityFromKeyboard(keyboardState);

        }

        private void HandleControllerInput()
        {
            var controllerState = GamePad.GetState(PlayerIndex.One);
            UpdateVelocityFromController(controllerState);
        }

        private void UpdateVelocityFromKeyboard(KeyboardState keyboardState)
        {

            var keyDictionary = new Dictionary<Keys, Vector2>()
                {
                    {Keys.Left, new Vector2(-1, 0)},
                    {Keys.Right, new Vector2(1, 0)},
                    {Keys.Up, new Vector2(0, -1)},
                    {Keys.Down, new Vector2(0, 1)},
                    
                };

            var velocity = Vector2.Zero;

            foreach (var key in keyDictionary)
            {
                if (keyboardState.IsKeyDown(key.Key))
                    velocity += key.Value;
            }

            if (velocity != Vector2.Zero)
                velocity.Normalize();

            sprite.Velocity = velocity;
        }

        private void UpdateVelocityFromController(GamePadState controllerState)
        {
            var buttonDictionary = new Dictionary<Buttons, Vector2>()
                {
                    {Buttons.LeftThumbstickLeft, new Vector2(-1, 0)},
                    {Buttons.LeftThumbstickRight, new Vector2(1, 0)},
                    {Buttons.LeftThumbstickUp, new Vector2(0, -1)},
                    {Buttons.LeftThumbstickDown, new Vector2(0, 1)},
                    
                };

            var velocity = Vector2.Zero;

            foreach (var button in buttonDictionary)
            {
                if (controllerState.IsButtonDown(button.Key))
                    velocity += button.Value;
            }

            if (velocity != Vector2.Zero)
                velocity.Normalize();

            sprite.Velocity = velocity;
        }
    }
}
