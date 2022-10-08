using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Zelda.GameState;
namespace Zelda.Sound
{
    public class SoundManager
    {
        private readonly ContentManager _content;
        private readonly SoundItem backgroundMusic;
        private readonly float _masterVolume = .25f;
        private readonly float _mute = 0;
        private readonly List<SoundItem> soundEffects = new List<SoundItem>();

        public SoundManager(ContentManager content)
        {
            _content = content;
            backgroundMusic = new SoundItem("background", "04-Labyrinth", content);
            backgroundMusic.CreateInstance();
            backgroundMusic.instance.IsLooped = true;
            backgroundMusic.instance.Play();
            backgroundMusic.instance.Volume = _masterVolume;
        }
        public void LoadAllSounds()
        {
            soundEffects.Add(new SoundItem("arrow_boomerang", "LOZ_Arrow_Boomerang", _content));
            soundEffects.Add(new SoundItem("bomb_blow", "LOZ_Bomb_Blow", _content));
            soundEffects.Add(new SoundItem("bomb_drop", "LOZ_Bomb_Drop", _content));
            soundEffects.Add(new SoundItem("boss1", "LOZ_Boss_Scream1", _content));
            soundEffects.Add(new SoundItem("boss2", "LOZ_Boss_Scream2", _content));
            soundEffects.Add(new SoundItem("candle", "LOZ_Candle", _content));
            soundEffects.Add(new SoundItem("door", "LOZ_Door_Unlock", _content));
            soundEffects.Add(new SoundItem("enemy_die", "LOZ_Enemy_Die", _content));
            soundEffects.Add(new SoundItem("enemy_hit", "LOZ_Enemy_Hit", _content));
            soundEffects.Add(new SoundItem("fanfare", "LOZ_Fanfare", _content));
            soundEffects.Add(new SoundItem("heart", "LOZ_Get_Heart", _content));
            soundEffects.Add(new SoundItem("item", "LOZ_Get_Item", _content));
            soundEffects.Add(new SoundItem("rupee", "LOZ_get_Rupee", _content));
            soundEffects.Add(new SoundItem("link_die", "LOZ_Link_Die", _content));
            soundEffects.Add(new SoundItem("link_hurt", "LOZ_Link_Hurt", _content));
            soundEffects.Add(new SoundItem("lowhealth", "LOZ_LowHealth", _content));
            soundEffects.Add(new SoundItem("magicalrod", "LOZ_MagicalRod", _content));
            soundEffects.Add(new SoundItem("refill", "LOZ_Refill_Loop", _content));
            soundEffects.Add(new SoundItem("shield", "LOZ_Shield", _content));
            soundEffects.Add(new SoundItem("stairs", "LOZ_Stairs", _content));
            soundEffects.Add(new SoundItem("sword_combined", "LOZ_Sword_Combined", _content));
            soundEffects.Add(new SoundItem("sword_shoot", "LOZ_Sword_Shoot", _content));
            soundEffects.Add(new SoundItem("sword_slash", "LOZ_Sword_Slash", _content));
            soundEffects.Add(new SoundItem("text", "LOZ_Text", _content));

        }
        public virtual void PlaySound(string name)
        {
            for(int i = 0; i < soundEffects.Count; i++)
            {
                if (soundEffects[i]._name == name)
                {
                    RunSound(soundEffects[i].instance);
                }
            }
        }

        public void RunSound(SoundEffectInstance instance)
        {
            instance.Volume = _masterVolume;
            instance.Play();
        }

        public void MuteAllSounds()
        {
            if (backgroundMusic.instance.Volume != _mute)
            {
                backgroundMusic.instance.Volume = _mute;

                for (int i = 0; i < soundEffects.Count; i++)
                {
                    soundEffects[i].instance.Volume = _mute;
                }
            } 
            else
            {
                backgroundMusic.instance.Volume = _masterVolume;

                for (int i = 0; i < soundEffects.Count; i++)
                {
                    soundEffects[i].instance.Volume = _masterVolume;
                }
            }
        }
        public void PauseMusic()
        {
            if (backgroundMusic.instance.State == SoundState.Playing)
            {
                backgroundMusic.instance.Pause();
            }
        }

        public void PlayMusic()
        {
            if (backgroundMusic.instance.State == SoundState.Paused)
            {
                backgroundMusic.instance.Resume();
            }
        }
    }
}
