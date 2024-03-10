using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameTest.Sprites
{
    public class Dan : Sprite
    {
        private float ThoiGian; //_time

        public Dan(Texture2D texture): base(texture)
        {

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
        
        
            ThoiGian += (float)gameTime.ElapsedGameTime.TotalSeconds; // thời gian sau thời gian trc đó

            if (ThoiGian >= LifeSpan)
                IsRemoved = true;

            ViTri += Chieu * LinearVelocity;
        }
    }
}
