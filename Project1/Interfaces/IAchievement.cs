using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zelda.Interfaces
{
    public interface IAchievement
    {

        void CheckAchievement(GameTime gameTime, SpriteBatch sb);

    }
}
