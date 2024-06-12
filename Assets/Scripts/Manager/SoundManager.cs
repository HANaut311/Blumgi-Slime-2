using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;
    [SerializeField] private Toggle sound;


    public bool playBgm;
    private int bgmIndex;

    private bool canPlaySFX;
    private void Awake()
    {   
        if(instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        

        Invoke("AllowSFX", 0f);   
    }

    private void Start()
    {
        bool isSoundOn = PlayerPrefs.GetInt("SoundOn",1) == 1;

        sound.isOn = isSoundOn;
        SetSoundState(isSoundOn);
    }

    private void Update()
    {
        if(!playBgm)
            StopAllBGM();
        else
        {
            if(!bgm[bgmIndex].isPlaying)
                PlayBGM(bgmIndex);
        }
    }

    public void ToggleSound()
    {
        bool isSoundOn = sound.isOn;
        PlayerPrefs.SetInt("SoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();

        SetSoundState(isSoundOn);
    }

    private void SetSoundState(bool isSoundOn)
    {
        foreach (var bmgSource in bgm)
        {
            bmgSource.volume = isSoundOn ? 1f : 0f;

        }

        foreach(var sfxSource in sfx)
            sfxSource.volume = isSoundOn ? 1f : 0f;




    }



    public void PlaySFX(int _sfxIndex)
    {
        // if(sfx[_sfxIndex].isPlaying)
        //     return;
        if(canPlaySFX == false)
            return;

        if(_sfxIndex < sfx.Length)
        {
            sfx[_sfxIndex].pitch = Random.Range(.85f, 1.1f);
            sfx[_sfxIndex].Play();
        }
    }

    public void StopSFX(int _index) => sfx[_index].Stop();

    public void StopSFXWithTime(int _index)
    {
        StartCoroutine(DecreaseVolume(sfx[_index]));
    }

    private IEnumerator DecreaseVolume(AudioSource _audio)
    {
        float defaultVolume = _audio.volume;

        while(_audio.volume > .1f)
        {
            _audio.volume -= _audio.volume * .2f;
            yield return new WaitForSeconds(0.5f);

            if(_audio.volume <= .1f)
            {
                _audio.Stop();
                _audio.volume = defaultVolume;
                break;
            }
        }
    }

    public void PlayRandomBGM()
    {
        bgmIndex = Random.Range(0, bgm.Length);
        PlayBGM(bgmIndex);
    }

    public void PlayBGM(int _bgmIndex)
    {   
        bgmIndex = _bgmIndex;

        StopAllBGM();

        bgm[bgmIndex].Play();

    }

    public void StopAllBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }    
    
    }

    private void AllowSFX() => canPlaySFX = true;


}
