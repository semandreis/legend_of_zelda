using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Interfaces;
using Zelda.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Achievements
{
    class SwordUsedAchievement : IAchievement
    {
        readonly private static float delay = 3;
        private static float timer = 0;
        public void CheckAchievement(GameTime gameTime, SpriteBatch sb)
        {

            GameManager gm = GameManager.GetInstance();
            if (gm.Player.AchievementsStats.SwordUsed >= 1 && timer <= delay)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Fencer", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.SwordUsed >= 20 && timer <= delay + 3)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Swordsman", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.SwordUsed >= 150 && timer <= delay + 6)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Samurai", new Vector2(50, 750), Color.Gray);
            }
            else if (gm.Player.AchievementsStats.SwordUsed >= 10000 && timer <= delay + 9)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Your fingers gotta be tired", new Vector2(50, 750), Color.Gray);
            }
        }
    }
}
