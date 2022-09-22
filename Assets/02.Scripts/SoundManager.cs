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
    [Header("���� ���")]
    [SerializeField]
    List<Sound> bgmSounds = new List<Sound>();

    [Header("��� �÷��̾�")]
    [SerializeField]
    AudioSource bgmPlayer;

    public AudioClip awardClip;


    //�̱��� ����
    public static SoundManager instance;
    void Awake()
    {
        // instance�� �Ҵ���� �ʾ��� ���
        if (instance == null)
        {
            instance = this;
        }
        // instance�� �Ҵ�� Ŭ������ �ν��Ͻ��� �ٸ� ��� ���� ������ Ŭ������ �ǹ���
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        // �ٸ� ������ �Ѿ���� �������� �ʰ� ������
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
        // clip�� ��� ����ǰ� �������� �Ű����� �߰�
        Destroy(se, clip.length);
    }

}
