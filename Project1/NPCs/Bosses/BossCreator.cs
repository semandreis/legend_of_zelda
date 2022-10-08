using System;
using Microsoft.Xna.Framework;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Bosses
{
    static class BossCreator
    {
        public static IGameObject CreateBoss(Boss boss, Vector2 position)
        {
            return boss switch
            {
                Boss.Aquamentus => new AquamentusObject(position),
                Boss.Dodongo => new DodongoObject(position),
                _ => throw new InvalidOperationException("Can't create boss"),
            };
        }
    }
}
