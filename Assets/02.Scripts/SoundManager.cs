using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    [Header("사운드 등록")]
    [SerializeField]
    List<Sound> bgmSounds = new List<Sound>();

    [Header("브금 플레이어")]
    [SerializeField]
    AudioSource bgmPlayer;

    public AudioClip awardClip;


    //싱글턴 패턴
    public static SoundManager instance;
    void Awake()
    {
        // instance가 할당되지 않았을 경우
        if (instance == null)
        {
            instance = this;
        }
        // instance에 할당된 클래스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미함
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        // 다른 씬으로 넘어가더라도 삭제하지 않고 유지함
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        PlayRandomBGM();
    }

    public void PlayRandomBGM()
    {
        int random = Random.Range(0, bgmSounds.Count);
        Debug.Log(bgmSounds.Count);
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();
    }

    
    public void SEPlay(string seName, AudioClip clip)
    {
        GameObject se = new GameObject(seName + "Sound");
        AudioSource audiosource = se.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();
        // clip이 모두 재생되고 끝나도록 매개변수 추가
        Destroy(se, clip.length);
    }

}
