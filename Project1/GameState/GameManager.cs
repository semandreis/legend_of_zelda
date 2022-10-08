using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Zelda.Link;
using Zelda.HUD;
using Zelda.NPCs;
using Zelda.Interfaces;
using System.Collections.Generic;
using Zelda.Commands.PlayerCommands;
using Zelda.Projectiles;
using Zelda.Collisions;
using Zelda.Environment;
using Zelda.Items;
using Zelda.Rooms;
using Zelda.Commands.StateCommander;
using Zelda.General;
using Zelda.Sound;
using Zelda.Records;

// used https://refactoring.guru/design-patterns/singleton/csharp/example as singleton reference

namespace Zelda.GameState
{
    public sealed class GameManager
    {
        public List<IGameObject> ActiveObjects { get; set; }
        public Dictionary<int, IRoom> RoomDict { get; set; }
        public int EnemyNumber { get; set; }
        public int StartingRoomID { get; set; }
        public int CurrentRoomID { get; set; }
        public int MaxRoomID { get; set; }
        public int NextRoomID { get; set; }
        public IRoom CurrentRoom { get; set; }
        public Vector2 RoomFramePoint { get; set; }
        public Vector2 RoomFloorPoint { get; set; }
        public Texture2D DungeonTexture { get; set; }
        public Texture2D LinkTexture { get; set; }
        public Texture2D TileTexture { get; set; }
        public Texture2D ItemTexture { get; set; }
        public Texture2D DoorTexture { get; set; }
        public Texture2D HUDTexture { get; set; }

        public IPlayer Player;
        public IGameObject PlayerObject;
        public List<IGameObject> ProjectileObjects { get; set; }
        public IProjectileController ProjectileController { get; set; }
        public ICollisionDetector CollisionDetector { get; set; }
        public ICollisionChecker CollisionHandler { get; set; }
        public Item CurrentItem { get; set; }

        public ContentManager Content { get; set; }

        public HUDDisplay HUD { get; set; }
        private static GameManager _instance;
        public IGameState CurrentState { get; set; }
        public StateCommander StateCommander { get; set; }
        public Vector2 StartPosition { get; set; }
        public Game1 Game { get; set; }
        public CommandRecorder Recorder { get; set; }

        public InputCommander InputCommands { get; set; }

        private GameManager() { }

        public static GameManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }

        public void LoadGameContent(ContentManager content)
        {
            Content = content;
            NPCSpriteFactory.Instance.LoadAllTextures(content);
            LinkTexture = content.Load<Texture2D>("link");
            TileTexture = content.Load<Texture2D>("tiles");
            DoorTexture = content.Load<Texture2D>("ZeldaDoors");
            ItemTexture = content.Load<Texture2D>("items");
            DungeonTexture = content.Load<Texture2D>("dungeon1");
            HUDTexture = content.Load<Texture2D>("HUD");
            HUD = new HUDDisplay(HUDTexture);
            StateCommander = new StateCommander(this);
            CurrentItem = Item.Null;

            TileCreator.SetTexture(TileTexture);
            ItemCreator.SetTexture(ItemTexture);
            DoorCreator.SetTexture(DoorTexture);

            Globals.SoundManager = new SoundManager(content);
            Globals.SoundManager.LoadAllSounds();

            Globals.Font = content.Load<SpriteFont>("GameOverFont");

            StateCommander.ChangeState(GameStateType.Start);
        }

        public void InitializeCriticalObjects()
        {
            ProjectileObjects = new List<IGameObject>();
            ProjectileController = new ProjectileController(ProjectileObjects, LinkTexture);
            Player = new Player(LinkTexture, new Vector2(458, 564), ProjectileController);
            PlayerObject = new PlayerObject(Player);
            CollisionDetector = new CollisionDetector();
            CollisionHandler = new AllCollisionChecker();

            CurrentRoomID = StartingRoomID;
            StartPosition = Player.Point.ObjectPoint;

            InputCommands = new InputCommander();
        }

        public void LoadDungeonData()
        {
            LoadRooms Loader = new LoadRooms(FilePathFinder.FindFilePath("Rooms", Globals.DungeonDataFilename), this);
            Loader.Load();
        }

        public void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime);

            if (!Globals.IsStarting)
            {
                InputCommands.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            CurrentState.Draw(gameTime, sb);
        }

    }
}
