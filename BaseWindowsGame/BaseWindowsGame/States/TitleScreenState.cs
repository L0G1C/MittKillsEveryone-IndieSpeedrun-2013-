using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.States
{
    class TitleScreenState : GameState
    {
        public TitleScreenState(Game1 game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))            
                Game.Exit();


            Game.gameStart = false;
            Game.introStart = false;
            Game.titleScreen.Update(gameTime);

            if (Game.currentKeyboardState.GetPressedKeys().Length > 0 &&
                !(Game.previousKeyboardState.GetPressedKeys().Length > 0))
                Game.GameState = new IntroSceneState(Game);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.titleScreen.Draw(spriteBatch);
        }
    }
}