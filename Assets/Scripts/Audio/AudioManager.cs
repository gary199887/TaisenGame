using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//参考
//作って学べるUnity本格入門　2020年版
public class AudioManager : MonoBehaviour
{
    //シングルトン
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
            throw new System.Exception("Sound" + clipName + "は存在しないファイル名です");
        }
        audioSource.clip = clips[clipName];
        audioSource.Play();

    }
}
