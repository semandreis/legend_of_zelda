using System;
using System.Collections.Generic;
using Zelda.Interfaces;
using System.Text;
using Zelda.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Achievements
{
    class KeeseKillsAchievement : IAchievement
    {
        readonly private static float delay = 3;
        private static float timer = 0;
        public void CheckAchievement(GameTime gameTime, SpriteBatch sb)
        {
            GameManager gm = GameManager.GetInstance();
            if (gm.Player.AchievementsStats.KeeseKills >= 1 && timer <= delay)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Keese Killer", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.KeeseKills >= 8 && timer <= delay + 3)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Keese Pillager", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.KeeseKills >= 17 && timer <= delay + 6)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Keese Obliterator", new Vector2(50, 750), Color.Gray);
            }
        }
    }
}
