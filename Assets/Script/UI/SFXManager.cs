using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance { get; private set; }

    private AudioSource _audioSource;
    [SerializeField] private List<SFXClip> _audioClips = new();

    private void Awake()
    {
        instance = this;

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(string name)
    {
        SFXClip clip = _audioClips.Find(x => x.name == name);
        _audioSource.PlayOneShot(clip.audioClip);
    }
}

[System.Serializable]
public struct SFXClip
{
    public string name;
    public AudioClip audioClip;
}
