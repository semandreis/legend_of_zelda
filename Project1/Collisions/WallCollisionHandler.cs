using Zelda.General;
using Zelda.Interfaces;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using System;
using Zelda.GameState;
using Zelda.Environment;

namespace Zelda.Collisions
{
    class WallCollisionHandler : ICollisionSingle
    {

        public void Handle(IGameObject obj1, IGameObject obj2, Direction direction)
        {
            obj1.UndoMovement();
            obj2.UndoMovement();

            if ((obj1.ObjectProperty != ObjectType.Wall && obj1.ObjectProperty != ObjectType.Portal) ||
                (obj2.ObjectProperty != ObjectType.Wall && obj2.ObjectProperty != ObjectType.Portal))
            { 
                //Console.WriteLine("wall!!!!"); 
            }
        }

    }
}
