using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private string introBGMusic;
    [SerializeField] private string levelBGMusic;
    public ManagerStatus status { get; private set; }

    private AudioSource activeMusic;
    private AudioSource inactiveMusic;

    [SerializeField] private float crossFadeRate = 1.5f;
    private bool crossFading;
    
    public float soundVolume
    {
        get => AudioListener.volume;
        set => AudioListener.volume = value;
    }

    public bool soundMute
    {
        get => AudioListener.pause;
        set => AudioListener.pause = value;
    }
    
    private float musicVolume;

    public float MusicVolume
    {
        get => musicVolume;

        set
        {
            musicVolume = value;

            if (musicSource && !crossFading) musicSource.volume = musicVolume;
        }
    }

    public bool musicMute
    {
        get => musicSource && musicSource.mute;

        set
        {
            if (musicSource)
            {
                musicSource.mute = value;
            }
        }
    }
    
    public void Startup()
    {
        Debug.Log("Audio manager starting...");

        musicSource.ignoreListenerVolume = true;
        musicSource.ignoreListenerPause = true;
        
        soundVolume = 1f;
        musicVolume = 1f;
        
        status = ManagerStatus.Started;
    }
    
    public void PlayIntroMusic()
    {
        PlayMusic(Resources.Load($"11/{introBGMusic}") as AudioClip);
    }

    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load($"11/{levelBGMusic}") as AudioClip);
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    private void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();   
    }

    public void StopMusic()
    {
        activeMusic.Stop();
        inactiveMusic.Stop();
    }

    private IEnumerator CrossFadeMusic(AudioClip clip)
    {
        crossFading = true;

        inactiveMusic.clip = clip;
        inactiveMusic.volume = 0;
        inactiveMusic.Play();

        float scaledRate = crossFadeRate * musicVolume;
        while (activeMusic.volume > 0)
        {
            activeMusic.volume -= scaledRate * Time.deltaTime;
            inactiveMusic.volume += scaledRate * Time.deltaTime;
            
            yield return null;
        }
        
        AudioSource temp = activeMusic;
        
        activeMusic = inactiveMusic;
        activeMusic.volume = musicVolume;
        
        inactiveMusic = temp;
        inactiveMusic.Stop();
        
        crossFading = false;
    }
}
