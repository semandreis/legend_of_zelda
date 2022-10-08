using System.Collections.Generic;
using Zelda.General;

namespace Zelda.Link
{
    public interface IPlayerStats
    {
        Projectile Proj0 { get; set; }
        Projectile Proj1 { get; set; }
        bool IsHealthy();
        bool IsAlive();
        bool IsBerserk();
        void BerserkMode();
        void IncreaseHealth(int change);
        bool OneHP();
        void ChangeHealth(int change);
        int FullHeartCount();
        bool HasHalfHeart();
        void SetProj0(Projectile p);
        void SetProj1(Projectile p);
        int KillStreak { get; set; }
    }
}
