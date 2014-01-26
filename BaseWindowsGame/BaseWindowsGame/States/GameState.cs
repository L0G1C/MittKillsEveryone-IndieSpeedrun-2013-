using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MitKillsEveryone;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MitKillsEveryone.States
{
    /// <summary>
    /// Base class, will not be instantiated
    /// </summary>
    public abstract class GameState
    {
        protected readonly Game1 Game;

        public GameState(Game1 game)
        {
            this.Game = game;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
