using System;
using System.Collections.Generic;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    public interface ICollisionDetector
    {
        List<Tuple<IGameObject, IGameObject, Direction>> FindCollisions(List<IGameObject> objects, List<IGameObject> projectiles);
    }
}
