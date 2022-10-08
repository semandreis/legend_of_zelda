using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Zelda.Commands.StateCommander;
using Zelda.Interfaces;

namespace Zelda.Commands.GameCommands
{
    public class GameCommander : IGameController
    {
        private readonly Dictionary<Keys, ICommand> _controllerMappings;
        private KeyboardState _currKey;
        private KeyboardState _prevKey;


        private void MapGameStatusControllers(Game1 game)
        {
            _controllerMappings.Add(Keys.Q, new QuitCommand(game));
            _controllerMappings.Add(Keys.R, new ResetCommand(game.Manager));
            _controllerMappings.Add(Keys.M, new MuteCommand());
        }
        public GameCommander(Game1 game)
        {
            _controllerMappings = new Dictionary<Keys, ICommand>();
            MapGameStatusControllers(game);
        }

        public void Update()
        {
            _currKey = Keyboard.GetState();
            Keys[] pressedKeys = _currKey.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (_controllerMappings.ContainsKey(key) && !_prevKey.IsKeyDown(key))
                {
                    _controllerMappings[key].Execute();
                }
            }
            _prevKey = _currKey;

        }
    }
}
