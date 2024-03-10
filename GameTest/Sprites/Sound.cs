using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace GameTest.Sprites
{
    public class Sound
    {
        private Song _song;

        public Sound(ContentManager content, string soundPath)
        {
            _song = content.Load<Song>(soundPath);
        }

        public void Play()
        {
            MediaPlayer.Play(_song);
        }
    }
}
