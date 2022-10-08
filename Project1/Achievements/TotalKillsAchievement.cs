using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Interfaces;
using Zelda.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Achievements
{
    class TotalKillsAchievement : IAchievement
    {
        readonly private static float delay = 3;
        private static float timer = 0;
        public void CheckAchievement(GameTime gameTime, SpriteBatch sb)
        {
            GameManager gm = GameManager.GetInstance();
            if (gm.Player.AchievementsStats.TotalKills >= 5 && timer <= delay)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Murderer", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.TotalKills >= 20 && timer <= delay + 3)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Serial Killer", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.TotalKills >= 40 && timer <= delay + 6)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Warmongerer", new Vector2(50, 750), Color.Gray);
            }
            else if (gm.Player.AchievementsStats.TotalKills >= 56 && timer <= delay + 9)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Geneva Convention Attendee", new Vector2(50, 750), Color.Gray);
            }
        }

    }
}
