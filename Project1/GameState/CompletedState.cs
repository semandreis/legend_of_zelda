using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Records;

namespace Zelda.GameState
{
    class CompletedState : IGameState
    {
        private static CompletedState _instance;
        private GameManager _gameManager;

        private string _drawString;

        private int _playerTimer = 100;
        private int _fadeTimer = 100;

        private IList<StringButton> _buttonList;
        private StringButton _retryButton;
        private StringButton _quitButton;

        private static SpriteFont font;

        private CompletedState() { }

        public static CompletedState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CompletedState();
            }
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
            _retryButton = new StringButton("Retry", font, new Vector2(Constants.ScreenWidth / 2, Constants.ScreenHeight - 50));
            _quitButton = new StringButton("Quit", font, new Vector2(Constants.ScreenWidth / 2, Constants.ScreenHeight - 125));
            _buttonList.Add(_retryButton);
            _buttonList.Add(_quitButton);
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
                _drawString = "Player Celebrating";
                Vector2 size = font.MeasureString(_drawString);
                sb.DrawString(font, _drawString, new Vector2((Constants.ScreenWidth / 2) - (size.X / 2), (Constants.ScreenHeight / 2) - (size.Y / 2)), Color.White);
            }
            else
            {
                if (_fadeTimer > 0)
                {
                    _drawString = "You Win!";
                    Vector2 size = font.MeasureString(_drawString);
                    sb.DrawString(font, _drawString, new Vector2((Constants.ScreenWidth / 2) - (size.X / 2), (Constants.ScreenHeight / 2) - (size.Y / 2)), Color.White);
                }
                else
                {
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
                if (_fadeTimer > 0)
                {
                    _fadeTimer--;
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
                                case ("Retry"):
                                    _gameManager.StateCommander.ChangeState(GameStateType.Start);
                                    break;
                                case ("Quit"):
                                    _gameManager.StateCommander.ChangeState(GameStateType.Running);
                                    break;
                            }
                        }
                    }
                }
            }

        }
    }
}
