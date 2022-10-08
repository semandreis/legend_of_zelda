using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Commands.StateCommander
{
    public class StateCommander
    {
        private readonly GameManager _gm;
        private readonly Dictionary<Keys, ICommand> _controllerMappings;
        private KeyboardState _prevKey;
        private KeyboardState _currKey;

        public StateCommander(GameManager gm)
        {
            _controllerMappings = new Dictionary<Keys, ICommand>();
            _gm = gm;
            MapStateCommands(gm);
        }

        private void MapStateCommands(GameManager gm)
        {
            _controllerMappings.Add(Keys.P, new PauseCommand(gm));
            _controllerMappings.Add(Keys.O, new RunCommand(gm));
            _controllerMappings.Add(Keys.I, new GameOverCommand(gm));
            _controllerMappings.Add(Keys.U, new ItemSelectCommand(gm));
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

        public void ChangeState(GameStateType gst)
        {
            switch (gst)
            {
                case GameStateType.Completed:
                    _gm.CurrentState = CompletedState.GetInstance();
                    _gm.CurrentState.InitializeState();
                    break;
                case GameStateType.GameOver:
                    _gm.CurrentState = GameOverState.GetInstance();
                    _gm.CurrentState.InitializeState();
                    break;
                case GameStateType.Paused:
                    _gm.CurrentState = PausedState.GetInstance();
                    _gm.CurrentState.InitializeState();
                    break;
                case GameStateType.Running:
                    _gm.CurrentState = RunningState.GetInstance();
                    _gm.CurrentState.InitializeState();
                    break;
                case GameStateType.Selection:
                    _gm.CurrentState = ItemSelectionState.GetInstance();
                    _gm.CurrentState.InitializeState();
                    break;
                case GameStateType.Transitioning:
                    _gm.CurrentState = TransitioningState.GetInstance();
                    _gm.CurrentState.InitializeState();
                    break;
                case GameStateType.Start:
                    _gm.CurrentState = StartState.GetInstance();
                    _gm.InitializeCriticalObjects();
                    _gm.CurrentState.InitializeState();
                    _gm.InitializeCriticalObjects();
                    break;
                case GameStateType.ClockPause:
                    _gm.CurrentState = ClockPausedState.GetInstance();
                    _gm.CurrentState.InitializeState();
                    break;
            }
        }

    }
}
