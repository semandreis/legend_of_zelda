using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Interfaces;
using Zelda.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Achievements
{
    class StalfosKillsAchievement : IAchievement
    {
        readonly private static float delay = 3;
        private static float timer = 0;
        public void CheckAchievement(GameTime gameTime, SpriteBatch sb)
        {

            GameManager gm = GameManager.GetInstance();
            if (gm.Player.AchievementsStats.StalfosKills >= 1 && timer <= delay)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Stalfos Killer", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.StalfosKills >= 7 && timer <= delay + 3)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Stalfos Pillager", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.StalfosKills >= 13 && timer <= delay + 6)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Stalfos Obliterator", new Vector2(50, 750), Color.Gray);
            }
        }
    }
}
