using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MitKillsEveryone.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MitKillsEveryone.States
{
    class CreditsScreenState : GameState
    {
        public CreditsScreenState(Game1 game) : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (Game.creditsStart == false)
            {
                Game.SoundManager.PlayFullMusic();
                Game.creditsStart = true;
            }

            Game.gameStart = false;            
            Game.credits.Update(gameTime);

            if (Game.credits.creditsDone)
            {
                Game.credits.creditsDone = false;     
                Game.LoadContentFromCredits();
                Game.GameState = new TitleScreenState(Game);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.credits.Draw(spriteBatch);
        }
    }
}
