using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Entities
{
    public class Intro : Sprite
    {        
        private KeyboardState keyboardState;
        private float skipDelay = 1.0f;
        private float currentTime = 0.0f;
        private bool showSkip;
        private float frame1Done = 9.0f;
        private float frame2Done = 51.0f;
        private float frame3Done = 86.0f;
        private float frame4Done = 107.0f;
        private int currentMaxTextPos;
        private int currentTextSpeed;

        private Texture2D skipButton;
        private Texture2D currentText;
        private Vector2 currentTextPos;
        private ContentManager content;

        private bool stopText;
        private int currentFrame;

        public bool IntroDone { get; set; }
        


        public Intro(Texture2D texture, Vector2 position, Rectangle movementBounds, ContentManager content) : base(texture, position, movementBounds)
        {
            skipButton = content.Load<Texture2D>(@"gfx/scenes/skipButton");
            currentText = content.Load<Texture2D>(@"gfx/scenes/introFrame1text");
            currentTextPos = new Vector2(650, 600);
            currentMaxTextPos = 525;
            currentTextSpeed = 25;
            currentFrame = 1;

            this.content = content;

           
        }

        public override void Update(GameTime gameTime)
        {
            currentTime += (float) gameTime.ElapsedGameTime.TotalSeconds;

            keyboardState = Keyboard.GetState();

            if (currentTime > skipDelay)
            {
                showSkip = true;

                if (keyboardState.IsKeyDown(Keys.Space))
                    IntroDone = true;
            }

            if (!stopText)
            {
                currentTextPos = new Vector2(0, currentTextPos.Y - (currentTextSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds));
                if (currentTextPos.Y <= currentMaxTextPos)
                    stopText = true;
            }

            if (currentTime > frame1Done)
            {
                
                Texture = content.Load<Texture2D>(@"gfx/scenes/introframe2");
                currentText = content.Load<Texture2D>(@"gfx/scenes/introFrame2text");

                if (stopText && currentFrame == 1)
                {
                    currentTextPos = new Vector2(300, 600);
                    currentTextSpeed = 15;
                    currentMaxTextPos = 90;
                    currentFrame++;
                    stopText = false;
                }

                
               
            }
            if (currentTime > frame2Done)
            {
                Texture = content.Load<Texture2D>(@"gfx/scenes/introframe3");
                currentText = content.Load<Texture2D>(@"gfx/scenes/introFrame3text");

                if (stopText && currentFrame == 2)
                {
                    currentTextPos = new Vector2(300, 600);
                    currentTextSpeed = 16;
                    currentMaxTextPos = 90;
                    currentFrame++;
                    stopText = false;
                }

                
                
            }
            if (currentTime > frame3Done)
            {
                Texture = content.Load<Texture2D>(@"gfx/scenes/introframe4");
                currentText = content.Load<Texture2D>(@"gfx/scenes/introFrame4text");

                if (stopText && currentFrame == 3)
                {
                    currentTextPos = new Vector2(300, 600);
                    currentTextSpeed = 15;
                    currentMaxTextPos = 300;
                    currentFrame++;
                    stopText = false;
                }

               
               

            }

            if (currentTime > frame4Done)
                IntroDone = true;



            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            

            base.Draw(spriteBatch);

            if (showSkip)
                spriteBatch.Draw(skipButton, new Vector2(800, 600), Color.White);

            spriteBatch.Draw(currentText, currentTextPos, Color.White);  
           
        }

      
    }
}
