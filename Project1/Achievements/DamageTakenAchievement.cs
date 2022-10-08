using System;
using System.Collections.Generic;
using System.Text;
using Zelda.GameState;
using Zelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Achievements
{
    class DamageTakenAchievement : IAchievement
    {
        readonly private static float delay = 3;
        private static float timer = 0;
        public void CheckAchievement(GameTime gameTime, SpriteBatch sb)
        {
            GameManager gm = GameManager.GetInstance();
            if (gm.Player.AchievementsStats.DamageTaken >= 1 && timer <= delay)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Beginner Masochist", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.DamageTaken >= 10 && timer <= delay + 3)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Intermediate Masochist", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.DamageTaken >= 40 && timer <= delay + 6)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Advanced Masochist", new Vector2(50, 750), Color.Gray);
            }
            else if (gm.Player.AchievementsStats.DamageTaken >= 100 && timer <= delay + 9)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Insane Masochist", new Vector2(50, 750), Color.Gray);
            }

        }
    }
}
