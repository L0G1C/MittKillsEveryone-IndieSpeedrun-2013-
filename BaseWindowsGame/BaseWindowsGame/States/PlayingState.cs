using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.States
{
    class PlayingState : GameState
    {
        float delay = 10.5f;
        float time = 0f;

        public PlayingState(Game1 game) : base(game)
        {
        }


        public override void Update(GameTime gameTime)
        {

            if (Game.gameStart == false)
            {
                Game.SoundManager.PlayBackgroundMusic();
                Game.gameStart = true;
            }

            Game.keyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();

            Game.player.Update(gameTime);
            Game.background.Update(gameTime, Game.StoryCount);
            Game.background.CheckCollisions(gameTime, Game.player, ref Game.StoryCount);

            if (Game.player.Position.X >= 930 && Game.background.ExitRight != null)
            {
                Game.background = Game.background.ExitRight;
                Game.background.LoadTexture(Game.Content, Game.SoundManager, Game.background.FileName, Game.StoryCount);
                Game.player.Position = new Vector2(26.0f, Game.player.Position.Y);
            }
            else if (Game.player.Position.X <= 25 && Game.background.ExitLeft != null)
            {
                Game.background = Game.background.ExitLeft;
                Game.background.LoadTexture(Game.Content, Game.SoundManager, Game.background.FileName, Game.StoryCount);
                Game.player.Position = new Vector2(929.0f, Game.player.Position.Y);
            }
            else if (Game.player.Position.Y <= 245 && Game.background.ExitUp != null
                && Game.keyboardState.IsKeyDown(Keys.Space))
            {
                Game.background = Game.background.ExitUp;
                Game.background.LoadTexture(Game.Content, Game.SoundManager, Game.background.FileName, Game.StoryCount);
                Game.player.Position = new Vector2(Game.player.Position.X, 320);
            }
            else if (Game.player.Position.Y >= 363 && Game.background.ExitDown != null)
            {
                Game.background = Game.background.ExitDown;
                Game.background.LoadTexture(Game.Content, Game.SoundManager, Game.background.FileName, Game.StoryCount);
                Game.player.Position = new Vector2(Game.background.XSpawnPosition, 245);
            }

            if (Game.StoryCount == 10)
            {
                time += (float) gameTime.ElapsedGameTime.TotalSeconds;

                if(time >= delay)
                    Game.GameState = new CreditsScreenState(Game);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Game.background.Draw(spriteBatch, Game.StoryCount);
            Game.player.Draw(spriteBatch);  
        }
    }
}
