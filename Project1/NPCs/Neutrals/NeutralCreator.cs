using System;
using Microsoft.Xna.Framework;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Neutrals
{
    static class NeutralCreator
    {
        public static IGameObject CreateNeutral(Neutral neutral, Vector2 position)
        {
            return neutral switch
            {
                Neutral.OldMan => new OldManObject(position),
                Neutral.StaticFire => new StaticFireObject(position),
                _ => throw new NotImplementedException("Can't create neutral"),
            };
        }
    }
}
