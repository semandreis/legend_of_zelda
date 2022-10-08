using Zelda.General;
using Zelda.Interfaces;
using System;

namespace Zelda.Collisions
{
    public interface ICollisionChecker
    {
        void CheckCollision(Tuple<IGameObject, IGameObject, Direction> collision);
    }
}
