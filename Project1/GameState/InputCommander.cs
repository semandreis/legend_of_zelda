using Microsoft.Xna.Framework;
using Zelda.Commands.MouseCommands;
using Zelda.Commands.PlayerCommands;
using Zelda.Commands.StateCommander;
using Zelda.Records;

namespace Zelda.GameState
{
    public class InputCommander
    {
        private CommandParser Parser;
        private MouseCommander MouseCommand { get; set; }
        public IPlayerCommander PlayerCommand { get; set; }
        private GameManager _gm;

        public InputCommander()
        {
            _gm = GameManager.GetInstance();
            
            MouseCommand = new MouseCommander(_gm);
            UpdatePlayerCommand();
        }

        public void AddCommandParsing()
        {
            Parser = new CommandParser(Globals.RecordFilename);
        }

        public void UpdatePlayerCommand()
        {
            PlayerCommand = new PlayerCommander(ref _gm.Player);
        }

        public void Update(GameTime gameTime)
        {

            if (Globals.IsUserControl)
            {
                _gm.StateCommander.Update();
                if (Globals.IsMouseDebugging)
                    MouseCommand.Update(gameTime);
                if (!Globals.IsChangingRoom)
                    PlayerCommand.Update();
            }
            else
            {
                if (!Globals.IsChangingRoom)
                    Parser.ParseCommand();
            }
        }
    }
}
