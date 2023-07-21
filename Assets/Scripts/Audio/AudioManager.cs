using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�l
//����Ċw�ׂ�Unity�{�i����@2020�N��
public class AudioManager : MonoBehaviour
{
    //�V���O���g��
    static AudioManager instance;
    [SerializeField]
    AudioSource audioSource;

    readonly Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    public static AudioManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if(null!=instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;

        var audioClips = Resources.LoadAll<AudioClip>("2D_SE");
        foreach(var clip in audioClips)
        {
            clips.Add(clip.name, clip);
        }
    }

    public void Play(string clipName)
    {
        if(!clips.ContainsKey(clipName))
        {
            throw new System.Exception("Sound" + clipName + "�͑��݂��Ȃ��t�@�C�����ł�");
        }
        audioSource.clip = clips[clipName];
        audioSource.Play();

    }
}
