using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{

    AudioSource[] _audioSource = new AudioSource[(int)Define.Sound.Count];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundName = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < soundName.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundName[i] };
                _audioSource[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSource[(int)Define.Sound.Bgm].loop = true;
        }
    }

    public void Play(Define.Sound type, string path)
    {
        if (type == Define.Sound.Bgm)
        {
            AudioClip audioClip = Managers.Instance.Resource.Load<AudioClip>($"Sounds/PlayerSound/{path}");
            AudioSource audioSource = _audioSource[(int)Define.Sound.Bgm];

            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = _audioSource[(int)Define.Sound.Effect];
            AudioClip audioClip = null;

            if (_audioClips.TryGetValue(path, out AudioClip clip))
            {
                audioSource.clip = clip;
            }
            else
            {
                audioClip = Managers.Instance.Resource.Load<AudioClip>($"Sounds/PlayerSound/{path}");
                _audioClips.Add(path, audioClip);
                audioSource.clip = audioClip;
            }
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSource)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }


}
