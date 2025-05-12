using UnityEngine;

namespace _11
{
    public class SettingsPopup : MonoBehaviour
    {
        [SerializeField] private AudioClip sound;
        
        public void OnSoundToggle()
        {
            ManagersAudio.Audio.soundMute = !ManagersAudio.Audio.soundMute;
            ManagersAudio.Audio.PlaySound(sound);
        }

        public void OnSoundValue(float volume)
        {
            ManagersAudio.Audio.soundVolume = volume;
        }

        public void OnPlayMusic(int selector)
        {
            ManagersAudio.Audio.PlaySound(sound);

            switch (selector)
            {
                case 1:
                    ManagersAudio.Audio.PlayIntroMusic();
                    break;
                case 2:
                    ManagersAudio.Audio.PlayLevelMusic();
                    break;
                case 3:
                    ManagersAudio.Audio.StopMusic();
                    break;
            }
        }

        public void OnMusicToggle()
        {
            ManagersAudio.Audio.musicMute = !ManagersAudio.Audio.musicMute;
            ManagersAudio.Audio.PlaySound(sound);
        }

        public void OnMusicValue(float volume)
        {
            ManagersAudio.Audio.MusicVolume = volume;
        }
    }
}