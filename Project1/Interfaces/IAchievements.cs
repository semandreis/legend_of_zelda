using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zelda.Interfaces
{
    public interface IAchievements
    {
        int TotalKills { get; set; }
        int KeeseKills { get; set; }
        int StalfosKills { get; set; }
        int GoriyaKills { get; set; }
        int JellyKills { get; set; }
        int WallMasterKills { get; set; }
        int RoomsCleared { get; set; }
        int DistanceTraveled { get; set; }
        int SwordUsed { get; set; }
        int DamageTaken { get; set; }
        int HeartsCollected { get; set; }
        int RupeesCollected { get; set; }
        int DoorwaysTraveled { get; set; }

        SpriteFont achievementFont { get; set; }
        void CheckAchievements(GameTime gameTime, SpriteBatch sb);

    }
}
