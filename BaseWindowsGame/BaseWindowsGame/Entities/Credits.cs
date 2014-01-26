using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Entities
{
    public class Credits : Sprite
    {
        private KeyboardState keyboardState;
        private Texture2D creditsBackground;
        private Texture2D credits;
        private float skipDelay = 1.0f;
        private float currentTime = 0.0f;
        private bool showSkip;

        private int currentMaxTextPos;
        private int currentTextSpeed;

        private Texture2D skipButton;
        private Texture2D currentText;
        private Vector2 currentTextPos;
        private bool stopText;

        public bool creditsDone { get; set; }

        public Credits(Texture2D texture, Vector2 position, Rectangle movementBounds, ContentManager content) : base(texture, position, movementBounds)
        {            
            credits = content.Load<Texture2D>(@"gfx/scenes/creditstext");
            skipButton = content.Load<Texture2D>(@"gfx/scenes/skipButton");
            currentTextPos = new Vector2(250, 600);
            currentMaxTextPos = 320;
            currentTextSpeed = 25;
        }

        public override void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            keyboardState = Keyboard.GetState();

            if (currentTime > skipDelay)
            {
                showSkip = true;

                if (keyboardState.IsKeyDown(Keys.Space))
                    creditsDone = true;
            }

            if (!stopText)
            {
                currentTextPos = new Vector2(0, currentTextPos.Y - (currentTextSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds));
                if (currentTextPos.Y <= currentMaxTextPos)
                    stopText = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {                        
            spriteBatch.Draw(credits, currentTextPos, Color.White);


            if (showSkip)
                spriteBatch.Draw(skipButton, new Vector2(800, 600), Color.White);

            base.Draw(spriteBatch);
        }
    }
}
