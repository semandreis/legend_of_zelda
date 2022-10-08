using System;
using System.Collections.Generic;
using System.Text;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    interface ICollisionSingle
    {

        void Handle(IGameObject object1, IGameObject object2, Direction direction);

    }
}
