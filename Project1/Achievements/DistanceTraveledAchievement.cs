using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Interfaces;
using Zelda.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Achievements
{
    class DistanceTraveledAchievement : IAchievement
    {
        readonly private static float delay = 3;
        private static float timer = 0;

        public void CheckAchievement(GameTime gameTime, SpriteBatch sb)
        {
            
            
            GameManager gm = GameManager.GetInstance();
            if(gm.Player.AchievementsStats.DistanceTraveled >= 1 && timer <= delay)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Beginner Walker", new Vector2(50, 750), Color.Gray);             

            } else if(gm.Player.AchievementsStats.DistanceTraveled >= 1000 && timer <= delay + 3)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Intermediate Walker", new Vector2(50, 750), Color.Gray);
                
            }
            else if (gm.Player.AchievementsStats.DistanceTraveled >= 10000 && timer <= delay + 6)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Advanced Walker", new Vector2(50, 750), Color.Gray);
            }
            else if (gm.Player.AchievementsStats.DistanceTraveled >= 100000 && timer <= delay + 9)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                sb.DrawString(gm.Player.AchievementsStats.achievementFont, "Achievement Unlocked: Insane Walker", new Vector2(50, 750), Color.Gray);
            }
            



        }
    }
}
