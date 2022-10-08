using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Achievements;
using Zelda.GameState;
using Zelda.Interfaces;

namespace Zelda.Link
{
    class AchievementsStats : IAchievements
    {

        public int TotalKills { get; set; }
        public int KeeseKills { get; set; }
        public int StalfosKills { get; set; }
        public int GoriyaKills { get; set; }
        public int JellyKills { get; set; }
        public int WallMasterKills { get; set; }
        public int RoomsCleared { get; set; }
        public int DistanceTraveled { get; set; }
        public int SwordUsed { get; set; }
        public int DamageTaken { get; set; }
        public int HeartsCollected { get; set; }
        public int RupeesCollected { get; set; }
        public int DoorwaysTraveled { get; set; }

        public SpriteFont achievementFont { get; set; }

        private IAchievement DistanceTraveledCheck;
        private IAchievement DamageTakenCheck;
        private IAchievement DoorwaysTraveledCheck;
        private IAchievement GoriyaKillsCheck;
        private IAchievement KeeseKillsCheck;
        private IAchievement JellyKillsCheck;
        private IAchievement StalfosKillsCheck;
        private IAchievement TotalKillsCheck;
        private IAchievement WallMasterKillsCheck;
        private IAchievement SwordUsedCheck;
        private IAchievement RoomsClearedCheck;
        private IAchievement RupeesCollectedCheck;
        private IAchievement HeartsCollectedCheck;




        public AchievementsStats()
        {
            TotalKills = 0;
            KeeseKills = 0;
            StalfosKills = 0;
            GoriyaKills = 0;
            JellyKills = 0;
            WallMasterKills = 0;
            RoomsCleared = 0;
            DistanceTraveled = 0;
            SwordUsed = 0;
            DamageTaken = 0;
            HeartsCollected = 0;
            RupeesCollected = 0;
            DoorwaysTraveled = 0;
            GameManager _gameManager = GameManager.GetInstance();
            achievementFont = _gameManager.Content.Load<SpriteFont>("Ubuntu32");
        }

        public void CheckAchievements(GameTime gameTime, SpriteBatch sb)
        {
            DistanceTraveledCheck = new DistanceTraveledAchievement();
            DamageTakenCheck = new DamageTakenAchievement();
            DoorwaysTraveledCheck = new DoorwaysTraveledAchievement();
            GoriyaKillsCheck = new GoriyaKillsAchievement();
            KeeseKillsCheck = new KeeseKillsAchievement();
            JellyKillsCheck = new JellyKillsAchievement();
            StalfosKillsCheck = new StalfosKillsAchievement();
            TotalKillsCheck = new TotalKillsAchievement();
            WallMasterKillsCheck = new WallMasterKillsAchievement();
            SwordUsedCheck = new SwordUsedAchievement();
            RoomsClearedCheck = new RoomsClearedAchievement();
            RupeesCollectedCheck = new RupeesCollectedAchievement();
            HeartsCollectedCheck = new HeartsCollectedAchievement();

            DistanceTraveledCheck.CheckAchievement(gameTime, sb);
            DamageTakenCheck.CheckAchievement(gameTime, sb);
            DoorwaysTraveledCheck.CheckAchievement(gameTime, sb);
            GoriyaKillsCheck.CheckAchievement(gameTime, sb);
            KeeseKillsCheck.CheckAchievement(gameTime, sb);
            JellyKillsCheck.CheckAchievement(gameTime, sb);
            StalfosKillsCheck.CheckAchievement(gameTime, sb);
            TotalKillsCheck.CheckAchievement(gameTime, sb);
            WallMasterKillsCheck.CheckAchievement(gameTime, sb);
            SwordUsedCheck.CheckAchievement(gameTime, sb);
            RoomsClearedCheck.CheckAchievement(gameTime, sb);
            RupeesCollectedCheck.CheckAchievement(gameTime, sb);
            HeartsCollectedCheck.CheckAchievement(gameTime, sb);
        }
    }
}
