using System.Collections.Generic;
using Zelda.General;

namespace Zelda.Link
{
    public interface IPlayerInventory
    {
        void PickupItem(Item item);
        void PickUpProjectile(Projectile p);
        void PickUpHasable(Item item);
        void ChangeHasable(Item item, bool hasItem);
        bool HasItem(Item item);
        void UseItem(Item item);
        int ItemCount(Item item);
        List<Item> GetCountables();
        List<Item> GetHasables();
        List<Projectile> GetProjectiles();
        void ActivateKillStreak();
        void DeActivateKillStreak();
        void ActivateBeams();
        void DeActivateBeams();
    }
}
