using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffect
{
    Click,
    Select,
    Typing,
    PopUp,
    UISelect,
    UIPoint,
    Beep,
    CardPlace,
    Coins,
    Hit,
    Shoot,
    StrongShoot,
    Health,
}
public enum BackgroundMusic
{
    TitleScene,
    IntroScene,
    LevelOneScene,
    LevelTwoScene,
    End,
}
public class AudioManager : SingletonMono<AudioManager>
{
    [Header("Sound Effects")]
    public AudioSource[] sfx;
    [Header("Background Music")]
    public AudioSource[] bgm;
    public void PlaySFX(SoundEffect soundEffectenum)
    {
        if((int)soundEffectenum < sfx.Length)
        {
            sfx[(int)soundEffectenum].Play();
        }
    }
    public void ChangeSFXVolume(float value)
    {
        float changeValue = value;
        foreach (var clip in sfx)
        {
            ChangeAudioValue(changeValue, clip);
        }
    }
    private void ChangeAudioValue(float changeValue,AudioSource clip)
    {
        if (changeValue > 1)
        {
            clip.volume = 1;
        }
        else if (changeValue < 0)
        {
            clip.volume = 0;
        }
        else
        {
            clip.volume = changeValue;
        }
    }
    public void ChangeBGMVolume(float value)
    {
        float changeValue = value;
        foreach (var clip in bgm)
        {
            ChangeAudioValue(changeValue, clip);
        }
    }
    public void StopSFX()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            sfx[i].Stop();
        }
    }
    public void StopBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
    public void PauseBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Pause();
        }
    }
    public void PlayBGM(BackgroundMusic backgroundMusicenum)
    {
        foreach (var single in bgm)
        {
            single.Pause();
        }
        if((int)backgroundMusicenum < bgm.Length)
        {
            bgm[(int)backgroundMusicenum].Play();
        }
    }

}
