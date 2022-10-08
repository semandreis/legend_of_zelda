using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.GameState
{
    class TransitioningState : IGameState
    {
        private static TransitioningState _instance;
        private static GameManager _gameManager;
        private const float _resizeFactor = 3.5f;
        private static int _fadeTimer = 75;

        private TransitioningState() { }

        public static TransitioningState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TransitioningState();
            }
            return _instance;
        }
        
        public void InitializeState()
        {
            _gameManager = GameManager.GetInstance();
            Globals.IsMouseDebugging = false;
            Globals.IsChangingRoom = true;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_gameManager.DungeonTexture, new Rectangle((int)_gameManager.RoomFramePoint.X, (int)_gameManager.RoomFramePoint.Y,
                (int)(_gameManager.CurrentRoom.Frame.Width * _resizeFactor), (int)(_gameManager.CurrentRoom.Frame.Height * _resizeFactor)),
                _gameManager.CurrentRoom.Frame, Color.White * Globals.Opacity);
            foreach (IGameObject element in _gameManager.ActiveObjects)
            {
                element.Draw(gameTime, sb);
            }
        }

        public void Update(GameTime gameTime)
        {

            if (_fadeTimer > 0)
            {
                _fadeTimer--;
                Globals.Opacity -= 0.02f;

            } else if (_fadeTimer == 0)
            {
                _gameManager.CurrentRoomID = _gameManager.NextRoomID;
                _gameManager.CurrentRoom = _gameManager.RoomDict[_gameManager.CurrentRoomID];
                _gameManager.ActiveObjects = _gameManager.CurrentRoom.ActiveObjects;
                _gameManager.ActiveObjects.Add(_gameManager.PlayerObject);
                _gameManager.EnemyNumber = _gameManager.CurrentRoom.EnemyNumber;
                _fadeTimer--;

            } else if (_fadeTimer < 0 && _fadeTimer > -75)
            {
                _fadeTimer--;
                Globals.Opacity += 0.02f;
            } else
            {
                _gameManager.CurrentRoom.InitializeRoom();
                _fadeTimer = 75;
                Globals.Opacity = 1;
                _gameManager.CurrentState = RunningState.GetInstance();
                _gameManager.CurrentState.InitializeState();
            }
        }
    }
}
