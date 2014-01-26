using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MitKillsEveryone.Managers
{
    public class SoundManager
    {
        private Song backgroundMusic;
        private Song menuMusic;
        private Song introMusic;
        private Song fullmusic;
        private SoundEffect death1;
        private SoundEffect death2;
        private SoundEffect death3;
        private SoundEffect death4;

        public SoundManager(ContentManager content)
        {
            backgroundMusic = content.Load<Song>(@"sfx/songs/background");
            menuMusic = content.Load<Song>(@"sfx/songs/menu");
            introMusic = content.Load<Song>(@"sfx/songs/intro");
            fullmusic = content.Load<Song>(@"sfx/songs/fullmusic");
            death1 = content.Load<SoundEffect>(@"sfx/death1");
            death2 = content.Load<SoundEffect>(@"sfx/death2");
            death3 = content.Load<SoundEffect>(@"sfx/death3");
            death4 = content.Load<SoundEffect>(@"sfx/death4");
        }

        public void PlayBackgroundMusic()
        {
            if (MediaPlayer.GameHasControl)
            {
                MediaPlayer.Play(backgroundMusic);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayMenuMusic()
        {
            if (MediaPlayer.GameHasControl)
            {
                MediaPlayer.Play(menuMusic);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayIntroMusic()
        {
            if (MediaPlayer.GameHasControl)
            {
                MediaPlayer.Volume = 5;
                MediaPlayer.Play(introMusic);                
                MediaPlayer.IsRepeating = false;
            }
        }

        public void PlayFullMusic()
        {
            if (MediaPlayer.GameHasControl)
            {
                MediaPlayer.Play(fullmusic);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayDeath1()
        {
            death1.Play();
        }

        public void PlayDeath2()
        {
            death2.Play();
        }
        public void PlayDeath3()
        {
            death3.Play();
        }
        public void PlayDeath4()
        {
            death4.Play();
        }


    }
}
