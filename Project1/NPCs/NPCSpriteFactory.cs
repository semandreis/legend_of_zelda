using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Zelda.Interfaces;
using Zelda.NPCs.Bosses;
using Zelda.NPCs.Enemies;
using Zelda.NPCs.Neutrals;
using Zelda.Enemies;

namespace Zelda.NPCs
{
    class NPCSpriteFactory
    {
        private Texture2D _enemySpriteSheet;
        private Texture2D _npcSpriteSheet;
        private Texture2D _bossSpriteSheet;
        private Texture2D _fullEnemySpriteSheet;
        private Texture2D _enemyDeathSpriteSheet;

        private readonly static NPCSpriteFactory instance = new NPCSpriteFactory();
        public static NPCSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private NPCSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            _enemySpriteSheet = content.Load<Texture2D>("enemies");
            _npcSpriteSheet = content.Load<Texture2D>("NPC");
            _bossSpriteSheet = content.Load<Texture2D>("bosses");
            _fullEnemySpriteSheet = content.Load<Texture2D>("all_enemies");
            _enemyDeathSpriteSheet = content.Load<Texture2D>("death_sheet");
        }

        public IDrawable CreateKeeseSprite() => new KeeseSprite(_enemySpriteSheet, 16, 16, 194);
        public IDrawable CreateStalfosSprite() => new StalfosSprite(_enemySpriteSheet, 16, 16, 65);
        public IDrawable CreateWallMasterSprite() =>new WallMasterSprite(_enemySpriteSheet, 16, 16, 162);
        public IDrawable CreateTrapSprite() => new TrapSprite(_enemySpriteSheet, 16, 16, 82);
        public IDrawable CreateJellySmallSprite() => new JellySmallSprite(_enemySpriteSheet, 16, 16, 0);
        public IDrawable CreateJellyBigSprite() => new JellyBigSprite(_enemySpriteSheet, 16, 16, 33);
        public IDrawable CreateGoriyaDownSprite() => new GoriyaSpriteUpDown(_enemySpriteSheet, 16, 13, 100);
        public IDrawable CreateGoriyaUpSprite() => new GoriyaSpriteUpDown(_enemySpriteSheet, 16, 13, 116);
        public IDrawable CreateGoriyaRightSprite() => new GoriyaSpriteRight(_enemySpriteSheet, 16, 16, 130);
        public IDrawable CreateGoriyaLeftSprite() => new GoriyaSpriteLeft(_enemySpriteSheet, 16, 16, 130);
        public IDrawable CreateOldManSprite() => new OldManSprite(_npcSpriteSheet, 16, 16, 1);
        public IDrawable CreateStaticFireSprite() => new StaticFireSprite(_npcSpriteSheet, 16, 16, 52);
        public IDrawable CreateAquamentusSprite() => new AquamentusSprite(_bossSpriteSheet, 32, 25, 1);
        public IDrawable CreateAquamentusDeath() => new AquamentusSprite(_bossSpriteSheet, 35, 25, 261);
        public IDrawable CreateDodongoSprite() => new DodongoSprite(_bossSpriteSheet, 33, 33, 68);
        public IDrawable CreateRopeSprite() => new RopeSprite(_fullEnemySpriteSheet, 21, 15, 129);
        public IDrawable CreateBossDeathState(IGameObject boss) =>new BossDeathState(_enemyDeathSpriteSheet, 18, 16, 0, boss);
        public IDrawable CreateEnemyDeathState(IGameObject enemy) =>new EnemyDeathState(_enemyDeathSpriteSheet, 18, 16, 0, enemy);
        public IDrawable CreateGibdoSprite() => new GibdoSprite(_fullEnemySpriteSheet, 16, 16, 90);
        public IDrawable CreateDarknutLeftSprite() => new DarknutLeftSprite(_fullEnemySpriteSheet, 16, 16, 52);
        public IDrawable CreateDarknutRightSprite() => new DarknutRightSprite(_fullEnemySpriteSheet, 16, 16, 52);

    }
}

