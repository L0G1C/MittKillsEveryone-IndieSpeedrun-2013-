using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MitKillsEveryone.Constant;

namespace MitKillsEveryone.Entities.Backgrounds
{
    public class Background3 : Background
    {
        /// <summary>
        /// Bathroom
        /// </summary>
        private Item grenade;
        private Item dude3;

        public Background3()
        {
            FileName = "background3";
        }

        override public void LoadBackgrounds(int storyCount)
        {         

            if (storyCount < 7)
            {
                dude3 = new Item(Content.Load<Texture2D>(@"gfx/Dudes/dude3"), new Vector2(180, 350));
                grenade = new Item(Content.Load<Texture2D>(@"gfx/items/grenadeinsink"), new Vector2(640, 185));
                iM.Items.Add(grenade);   
            }
            else
            {
                dude3 = new Item(Content.Load<Texture2D>(@"gfx/Dudes/dude3dead"), new Vector2(180, 350));
            }
            iM.Items.Add(dude3);

            ExitDown = new Background2();
        }

        public override void CheckCollisions(GameTime gameTime, Player player, ref int storyCount)
        {
            if (iM.Items.Contains(grenade) && grenade.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount == 6)
                {
                    OutputText = "Hmm.. There is a hand grenade in the sink\r\n[SPACE] to pick it up";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        storyCount++;
                        iM.Items.Remove(grenade);
                    }
                }
                else
                {
                    OutputText = "It looks like a normal sink";
                }
            }

            else if (iM.Items.Contains(dude3) && dude3.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount < 7)
                {
                    OutputText = Constants.Dude3Name + ": \"Hey Mit, have you seen Tim?\r\nI think he went to the freezer room to get something\"";
                }
                else if (storyCount == 7)
                {
                    OutputText = "[SPACE] to blow " + Constants.Dude3Name + " up with a hand grenade";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        //Voicework and scene here?
                        SoundManager.PlayDeath3();
                        dude3.Texture = Content.Load<Texture2D>(@"gfx/Dudes/dude3dead");
                        storyCount++;
                    }
                }
                else
                {
                    OutputText = Constants.Dude3Name + " has been blown to smithereens by a hand grenade";
                }
            }
        }
    }
}
