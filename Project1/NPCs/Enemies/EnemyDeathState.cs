using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Interfaces;
using Zelda.NPCs.Bosses;
using Zelda.NPCs;
using System;
using Zelda.Items;
using Zelda.GameState;
using Zelda.Rooms;
using Zelda.General;

namespace Zelda.Enemies
{
    class EnemyDeathState : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly IGameObject _enemy;
        private int _frame;
        private readonly int _initialFrame;
        private readonly int _maxFrame;
        public readonly int _height;
        public readonly int _width;
        private int _timeSinceLastFrame = 600;
        private readonly Texture2D _texture;
        private int _cycles;
        private static GameManager _gameManager = GameManager.GetInstance();

        public EnemyDeathState(Texture2D texture, int height, int width, int frame, IGameObject enemy)
        {
            _enemy = enemy;
            _initialFrame = frame;
            _frame = _initialFrame;
            _maxFrame = _initialFrame + 16 * 3;
            _texture = texture;
            _width = width;
            _height = height;
            _cycles = 0;
        }

        private void SetNextFrame(int frameTime)
        {
            _timeSinceLastFrame -= frameTime;
            _frame += 16;

        }

        private void SetInitialFrame()
        {
            _frame = _initialFrame;

        }

        private void UpdateFrame(int frameTime, GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (_timeSinceLastFrame > frameTime)
            {
                SetNextFrame(frameTime);
            }

            if (_frame > _maxFrame)
            {
                SetInitialFrame();
                _cycles++;
            }
        }

        private void Kill()
        {
            _enemy.Exists = false;
            _gameManager.CurrentRoom.EnemyNumber--;
            if (++_gameManager.Player.PlayerStats.KillStreak > 5)
            {
                _gameManager.Player.PlayerInventory.ActivateKillStreak();
            }

            _gameManager.Player.AchievementsStats.TotalKills++;
            if (_enemy.EnemyProperty.Equals(Enemy.Stalfos))
            {
                _gameManager.Player.AchievementsStats.StalfosKills++;
            } 
            else if (_enemy.EnemyProperty.Equals(Enemy.Goriya))
            {
                _gameManager.Player.AchievementsStats.GoriyaKills++;
            }
            else if (_enemy.EnemyProperty.Equals(Enemy.JellyBig) || _enemy.EnemyProperty.Equals(Enemy.JellySmall))
            {
                _gameManager.Player.AchievementsStats.JellyKills++;
            }
            else if (_enemy.EnemyProperty.Equals(Enemy.Keese))
            {
                _gameManager.Player.AchievementsStats.KeeseKills++;
            }
            else if (_enemy.EnemyProperty.Equals(Enemy.WallMaster))
            {
                _gameManager.Player.AchievementsStats.WallMasterKills++;                
            }

        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            UpdateFrame(100, gameTime);
            SourceRectangle = new Rectangle(_frame, 0, _width, _height);
            sb.Draw(_texture, position, SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, NPCConstants.EnemyLayer);
            Random r = new Random();
            int num = r.Next(0, 100);
            

            if (_cycles > 1)
            {
                Kill();

                if (_gameManager.CurrentRoom.EnemyNumber == 0) {
                    _gameManager.Player.AchievementsStats.RoomsCleared++;
                    if (_gameManager.CurrentRoomID == 1 || _gameManager.CurrentRoomID == 3 || _gameManager.CurrentRoomID == 6 || _gameManager.CurrentRoomID == 13 || _gameManager.CurrentRoomID == 18 || _gameManager.CurrentRoomID == 14)
                    {
                        IGameObject drop = ItemCreator.CreateItem(General.Item.Key, position);
                        _gameManager.ActiveObjects.Add(drop);
                    }
                    if (_gameManager.CurrentRoomID == 11)
                    {
                      IGameObject drop = ItemCreator.CreateItem(General.Item.WoodenBoomerang, position);
                        _gameManager.ActiveObjects.Add(drop);
                    }
                }
                else if (num >= 0 && num <= 15)
                {
                    IGameObject drop = ItemCreator.CreateItem(General.Item.Heart, position);
                    _gameManager.ActiveObjects.Add(drop);
                }
                else if (num >= 16 && num <= 30)
                {
                    IGameObject drop = ItemCreator.CreateItem(General.Item.Rupee, position);
                    _gameManager.ActiveObjects.Add(drop);
                }
                else if (num >= 31 && num <= 33)
                {
                   IGameObject drop = ItemCreator.CreateItem(General.Item.Bomb, position);
                    _gameManager.ActiveObjects.Add(drop);
                }
                else if (num >= 34 && num <= 37)
                {
                   IGameObject drop = ItemCreator.CreateItem(General.Item.Fairy, position);
                    _gameManager.ActiveObjects.Add(drop);
                }
                else if (num == 38)
                {
                    IGameObject drop = ItemCreator.CreateItem(General.Item.Clock, position);
                    _gameManager.ActiveObjects.Add(drop);
                }            
            }
        }
    }
}
