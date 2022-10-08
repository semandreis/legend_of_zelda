using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Interfaces;
using Zelda.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Achievements
{
    class DoorwaysTraveledAchievement : IAchievement
    {
        readonly private static float delay = 3;
        private static float timer = 0;
        public void CheckAchievement(GameTime gameTime, SpriteBatch sb)
        {
            //divide 2
            GameManager gm = GameManager.GetInstance();
            if (gm.Player.AchievementsStats.DoorwaysTraveled >= 1 && timer <= delay)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Beginner Doorway Explorer", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.DoorwaysTraveled >= 10 && timer <= delay + 3)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Intermediate Doorway Explorer", new Vector2(50, 750), Color.Gray);

            }
            else if (gm.Player.AchievementsStats.DoorwaysTraveled >= 50 && timer <= delay + 6)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Advanced Doorway Explorer", new Vector2(50, 750), Color.Gray);
            }
            else if (gm.Player.AchievementsStats.DoorwaysTraveled >= 100 && timer <= delay + 9)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Insane Doorway Explorer", new Vector2(50, 750), Color.Gray);
            }
        }
    }
}
