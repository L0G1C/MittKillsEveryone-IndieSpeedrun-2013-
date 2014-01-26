using MitKillsEveryone.Constant;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Entities.Backgrounds
{
    /// <summary>
    /// Kitchen
    /// </summary>
    public class Background1 : Background
    {
        private Item dude2;
        private bool spacePressed;
        private Item sword;

        public Background1()
        {
            FileName = "background1";
            spacePressed = false;
        }

        override public void LoadBackgrounds(int storyCount)
        {
            if (storyCount < 4)
            {
                dude2 = new Item(Content.Load<Texture2D>(@"gfx/Dudes/dude2"), new Vector2(680, 200));
            }
            else
            {
                dude2 = new Item(Content.Load<Texture2D>(@"gfx/Dudes/dude2dead"), new Vector2(680, 350));
            }
            iM.Items.Add(dude2);

            if (storyCount == 8)
            {
                sword = new Item(Content.Load<Texture2D>(@"gfx/items/sword"), new Vector2(200, 200));
                iM.Items.Add(sword);
            }

            ExitRight = new Background2();
            ExitLeft = new Background4();
        }

        public override void CheckCollisions(GameTime gameTime, Player player, ref int storyCount)
        {
            if (iM.Items.Contains(sword) && sword.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount == 8)
                {
                    OutputText = "Huh. There's a samurai sword on the floor here\r\n[SPACE] to pick it up";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        iM.Items.Remove(sword);
                        storyCount++;
                    }
                }
            }
            else if (iM.Items.Contains(dude2) && dude2.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount < 3)
                {
                    OutputText = Constants.Dude2Name + ": \"'Sup Mit!\"\r\n\"Man, Tim is such a cool guy\r\nHe makes pizzas so fast and so delicious\r\nDon't you just love Tim?\"";
                }
                else if (storyCount == 3)
                {
                    OutputText = "[SPACE] to shoot " + Constants.Dude2Name + " in the face";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        spacePressed = true;
                    }
                    if (keyboardState.IsKeyUp(Keys.Space) && spacePressed)
                    {
                        spacePressed = false;
                        //Voicework and scene here?
                        SoundManager.PlayDeath2();
                        dude2.Texture = Content.Load<Texture2D>(@"gfx/Dudes/dude2dead");
                        dude2.Position = new Vector2(dude2.Position.X, dude2.Position.Y + 150); //he jumped up when layying down
                        storyCount++;
                    }
                }
                else if (storyCount == 4)
                {
                    OutputText = Constants.Dude2Name + " has been shot in the face\r\n[SPACE] to loot his body";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        storyCount++;
                    }
                }
                else
                {
                    OutputText = Constants.Dude2Name + " has been shot in the face\r\nAlso you have looted his body";
                }
            }
        }
    }
}
