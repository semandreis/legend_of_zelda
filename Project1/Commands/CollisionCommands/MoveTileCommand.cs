using Zelda.Interfaces;
using Zelda.Environment;
using Zelda.Link;
using Zelda.General;
using Microsoft.Xna.Framework;
using System;

namespace Zelda.Commands.CollisionCommands
{
    class MoveTileCommand : ICommand
    {
        private readonly MovingTileObject _tile;
        private readonly Direction _direction;

        public MoveTileCommand(IGameObject tile, Direction direction)
        {
            _tile = (MovingTileObject)tile;
            _direction = direction;
        }

        public void Execute()
        {
            Console.WriteLine("executed");
            _tile.Pushed(_direction);         
        }
    }
}
