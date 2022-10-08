using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.GameState
{
    class GameOverState : IGameState
    {
        private static SpriteFont font;
        private static GameOverState _instance;

        private string _drawString;

        private int _playerTimer = 100;
        private int _gameOverTimer = 300;

        private IList<StringButton> _buttonList;
        private StringButton _continueButton;
        private StringButton _saveButton;
        private StringButton _retryButton;
        private const float _resizeFactor = 3.5f;

        private GameManager _gameManager;

        private GameOverState() { }

        public static GameOverState GetInstance()
        {

            _instance = new GameOverState();

            return _instance;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.QuitCommandString);
            Globals.IsRecording = false;
        }

        public void InitializeState()
        {
            _gameManager = GameManager.GetInstance();
            _buttonList = new List<StringButton>();
            font = _gameManager.Content.Load<SpriteFont>("GameOverFont");
            _continueButton = new StringButton("Continue", font, new Vector2(Constants.ScreenWidth / 2, 50));
            _saveButton = new StringButton("Save", font, new Vector2(Constants.ScreenWidth / 2, 125));
            _retryButton = new StringButton("Retry", font, new Vector2(Constants.ScreenWidth / 2, 200));
            _buttonList.Add(_continueButton);
            _buttonList.Add(_saveButton);
            _buttonList.Add(_retryButton);
            Globals.SoundManager.PauseMusic();
            Globals.SoundManager.PlaySound("link_die");
            Globals.IsMouseDebugging = false;
            if (Globals.IsRecording)
            {
                Record();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (_playerTimer > 0)
            {
                if (_playerTimer % 33 < 8)
                {
                    _gameManager.Player.ChangeDirection(Direction.Up);
                }else if (_playerTimer % 33 < 16)
                {
                    _gameManager.Player.ChangeDirection(Direction.Right);
                }
                else if (_playerTimer % 33 < 22)
                {
                    _gameManager.Player.ChangeDirection(Direction.Down);
                }
                else
                {
                    _gameManager.Player.ChangeDirection(Direction.Left);
                }
                _gameManager.ProjectileController.Draw(gameTime, sb);
                foreach (IGameObject element in _gameManager.ActiveObjects)
                {
                    element.Draw(gameTime, sb);
                }
            }
            else
            {
                if (_gameOverTimer > 0)
                {
                    _drawString = "Game Over";
                    Vector2 size = font.MeasureString(_drawString);
                    sb.DrawString(font, _drawString, new Vector2((Constants.ScreenWidth / 2) - (size.X / 2), (Constants.ScreenHeight / 2) - (size.Y / 2)), Color.White);
                    
                }
                else
                {
                    Globals.SoundManager.PlayMusic();
                    foreach (StringButton b in _buttonList)
                    {
                        b.Draw(gameTime, sb);
                    }
                }
            }

        }

        public void Update(GameTime gameTime)
        {
            if (_playerTimer > 0)
            {
                _playerTimer--;
            }
            else
            {
                if (_gameOverTimer > 0)
                {
                    _gameOverTimer--;
                }
                else
                {
                    foreach (StringButton b in _buttonList)
                    {
                        string check = b.ButtonPressed();
                        if (check != null)
                        {
                            switch (check)
                            {
                                case ("Continue"):
                                    _gameManager.StateCommander.ChangeState(GameStateType.Running);
                                    break;
                                case ("Save"):
                                    _gameManager.StateCommander.ChangeState(GameStateType.Running);
                                    break;
                                case ("Retry"):
                                    _gameManager.StateCommander.ChangeState(GameStateType.Start);
                                    break;
                            }
                        }              
                    }
                }
            }

        }
    }
}
