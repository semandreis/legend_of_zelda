using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Zelda.Interfaces;
using Zelda.Link;

namespace Zelda.Commands.PlayerCommands
{
    public class PlayerCommander : IPlayerCommander
    {
        private readonly Dictionary<Keys, ICommand> _movementMappings;
        private readonly Dictionary<Keys, ICommand> _itemMappings;
        private KeyboardState _prevKey;
        private KeyboardState _currKey;
        private bool _moved;
        private IPlayer _player;

        private void MapPlayerMovementControllers(ref IPlayer player)
        {
            _movementMappings.Add(Keys.W, new PlayerUpCommand(player));
            _movementMappings.Add(Keys.Up, new PlayerUpCommand(player));
            _movementMappings.Add(Keys.A, new PlayerLeftCommand(player));
            _movementMappings.Add(Keys.Left, new PlayerLeftCommand(player));
            _movementMappings.Add(Keys.S, new PlayerDownCommand(player));
            _movementMappings.Add(Keys.Down, new PlayerDownCommand(player));
            _movementMappings.Add(Keys.D, new PlayerRightCommand(player));
            _movementMappings.Add(Keys.Right, new PlayerRightCommand(player));
        }

        private void MapPlayerItemControllers(ref IPlayer player)
        {
            _itemMappings.Add(Keys.NumPad0, new Proj0Command(player));
            _itemMappings.Add(Keys.NumPad1, new Proj1Command(player));
            _itemMappings.Add(Keys.D0, new Proj0Command(player));
            _itemMappings.Add(Keys.D1, new Proj1Command(player));
        }

        public PlayerCommander(ref IPlayer player)
        {
            _movementMappings = new Dictionary<Keys, ICommand>();
            _itemMappings = new Dictionary<Keys, ICommand>();
            _player = player;

            MapPlayerMovementControllers(ref player);
            MapPlayerItemControllers(ref player);
        }

        private void HandleMovement(Keys key)
        {
            if (_movementMappings.ContainsKey(key) && !_moved)
            {
                _movementMappings[key].Execute();
                _moved = true;
            }
        }

        private void HandleItem(Keys key)
        {
            if (_itemMappings.ContainsKey(key) && !_prevKey.IsKeyDown(key))
            {
                _itemMappings[key].Execute();
            }
        }

        public void Update()
        {
            _currKey = Keyboard.GetState();
            Keys[] pressedKeys = _currKey.GetPressedKeys();
            _moved = false;                       

            foreach (Keys key in pressedKeys)
            {
                HandleMovement(key);
                HandleItem(key);
            }

            _player.Animate(_moved);
            _prevKey = _currKey;

        }
    }
}
