using MitKillsEveryone.Constant;
using MitKillsEveryone.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Entities.Backgrounds
{
    /// <summary>
    /// Entrance
    /// </summary>
    public class Background2 : Background
    {
        private Item pottedPlant;
        private Item door;
        private Item dude1;

        public Background2()
        {
            FileName = "background2";
            XSpawnPosition = 380;
        }

        override public void LoadBackgrounds(int storyCount)
        {

            door = new Item(Content.Load<Texture2D>(@"gfx/items/nothing"), new Vector2(390, 180));
            iM.Items.Add(door);

            if (storyCount < 2)
            {
                dude1 = new Item(Content.Load<Texture2D>(@"gfx/Dudes/dude1"), new Vector2(180, 350));
                pottedPlant = new Item(Content.Load<Texture2D>(@"gfx/items/knifeinpot"), new Vector2(680, 220));
                iM.Items.Add(pottedPlant);
            }
            else
            {
                dude1 = new Item(Content.Load<Texture2D>(@"gfx/Dudes/dude1dead"), new Vector2(180, 400));
            }
            iM.Items.Add(dude1);

            ExitLeft = new Background1();
            ExitUp = null;
        }

        public override void CheckCollisions(GameTime gameTime, Player player, ref int storyCount)
        {
            if (iM.Items.Contains(pottedPlant) && pottedPlant.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount == 0)
                {
                    OutputText = "There is a totally inconspicuous potted plant here\r\n[SPACE] to search";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        storyCount++;
                        iM.Items.Remove(pottedPlant);                        
                    }
                }
                else
                {
                    OutputText = "You have already searched the totally inconspicuous potted plant";
                }
            }
            else if (iM.Items.Contains(door) && door.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount < 6)
                {
                    OutputText = "There is a door that leads to the bathroom, but it's locked.\r\nYou'll need to find the key to the bathroom";
                }
                else
                {
                    OutputText = "You could try the key you found on this door\r\n[SPACE] to unlock door";
                    ExitUp = new Background3();
                }
            }
            else if (iM.Items.Contains(dude1) && dude1.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount == 0)
                {
                    OutputText = Constants.Dude1Name + ": \"Good morning Mit!\"\r\n\"I sure hope I don't get stabbed in the face today\"";
                }
                else if (storyCount == 1)
                {
                    OutputText = "[SPACE] to stab " + Constants.Dude1Name + " in the face";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        //Voicework and scene here?
                        SoundManager.PlayDeath1();
                        dude1.Texture = Content.Load<Texture2D>(@"gfx/Dudes/dude1dead");
                        dude1.Position = new Vector2(dude1.Position.X, dude1.Position.Y + 50); //he jumped up when layying down
                        storyCount++;
                    }
                }
                else
                {
                    OutputText = Constants.Dude1Name + " has been stabbed in the face";
                }
            }
        }
    }
}
