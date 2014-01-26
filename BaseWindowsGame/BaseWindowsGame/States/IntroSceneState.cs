using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.States
{
    class IntroSceneState : GameState
    {       

        public IntroSceneState(Game1 game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Game.introStart == false)
            {
                Game.SoundManager.PlayIntroMusic();
                Game.introStart = true;
            }


            Game.gameStart = false;            
            Game.introScreen.Update(gameTime);

            if (Game.introScreen.IntroDone)
            {
                Game.introScreen.IntroDone = false;
                Game.GameState = new PlayingState(Game);
            }
        }

        

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.introScreen.Draw(spriteBatch);
        }
    }
}