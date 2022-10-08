using System;
using Microsoft.Xna.Framework;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    static class EnemyCreator
    {
        public static IGameObject CreateEnemy(Enemy enemy, Vector2 position)
        {
            return enemy switch
            {
                Enemy.Goriya => new GoriyaObject(position),
                Enemy.JellyBig => new JellyBigObject(position),
                Enemy.JellySmall => new JellySmallObject(position),
                Enemy.Keese => new KeeseObject(position),
                Enemy.Rope => new RopeObject(position),
                Enemy.Stalfos => new StalfosObject(position),
                Enemy.Gibdo => new GibdoObject(position),
                Enemy.Darknut => new DarknutObject(position),
                Enemy.Trap1 => new TrapObject1(position),
                Enemy.Trap2 => new TrapObject2(position),
                Enemy.Trap3 => new TrapObject3(position),
                Enemy.Trap4 => new TrapObject4(position),
                Enemy.WallMaster => new WallMasterObject(position),
                _ => throw new InvalidOperationException("Can't create enemy"),
            };
        }
    }
}
