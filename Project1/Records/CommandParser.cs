using System;
using System.Collections.Generic;
using System.IO;
using Zelda.Commands.GameCommands;
using Zelda.Commands.PlayerCommands;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Records
{
    public class CommandParser
    {
        private readonly string _filename;
        private readonly Dictionary<string, ICommand> _stringMappings;
        private readonly GameManager _gm;
        private readonly StreamReader _reader;

        private void MapStringCommands()
        {
            _stringMappings.Add(RecordConstants.UpCommandString, new PlayerUpCommand(_gm.Player));
            _stringMappings.Add(RecordConstants.LeftCommandString, new PlayerLeftCommand(_gm.Player));
            _stringMappings.Add(RecordConstants.DownCommandString, new PlayerDownCommand(_gm.Player));
            _stringMappings.Add(RecordConstants.RightCommandString, new PlayerRightCommand(_gm.Player));

            _stringMappings.Add(RecordConstants.UseItem0CommandString, new Proj0Command(_gm.Player));
            _stringMappings.Add(RecordConstants.UseItem1CommandString, new Proj1Command(_gm.Player));

            _stringMappings.Add(RecordConstants.QuitCommandString, new QuitCommand(_gm.Game));
            _stringMappings.Add(RecordConstants.ToggleMuteCommandString, new MuteCommand());
        }

        public CommandParser(string filename)
        {
            _gm = GameManager.GetInstance();
            _filename = FilePathFinder.FindFilePath("Records", filename);
            _stringMappings = new Dictionary<string, ICommand>();
            MapStringCommands();
            _reader = new StreamReader(_filename);
        }

        private void HandleCommand(string line)
        {
            //_gm.Player.PlayerStats.SetProj1(check);

            string command = line.Trim();

            if (_stringMappings.ContainsKey(command))
            {
                _stringMappings[command].Execute();
            }
            else if (command.Contains(RecordConstants.SetItemString))
            {
                string item = command.Substring(RecordConstants.SetItemString.Length);
                Enum.TryParse(item, out Projectile itemSet);
                _gm.Player.PlayerStats.SetProj1(itemSet);
            }
            else
            {
                throw new NotImplementedException("Non-Parseable Command");
            }
        }

        public void ParseCommand()
        {
            if (!_reader.EndOfStream)
            {
                HandleCommand(_reader.ReadLine());
            }    
        }
    }
}