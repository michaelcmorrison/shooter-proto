using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] audioClips;
    private AudioSource[] _sources;
    private Dictionary<string, AudioClip> _clipDictionary;

    private bool _alternatedSource;

    private void Awake()
    {
        _sources = GetComponents<AudioSource>();
        _clipDictionary = BuildClipDictionary();
    }

    private Dictionary<string, AudioClip> BuildClipDictionary()
    {
        var dictToReturn = new Dictionary<string, AudioClip>();

        foreach (var audioClip in audioClips)
        {
            dictToReturn.Add(audioClip.name, audioClip);
        }

        return dictToReturn;
    }

    public void PlayClip(string clipName)
    {
        _sources[0].clip = _clipDictionary[clipName];
        _sources[0].Play();
    }

    public void PlayClip(string clipName, bool randomPitch)
    {
        _sources[0].clip = _clipDictionary[clipName];
        if (randomPitch)
        {
            _sources[0].pitch = Random.Range(1, 1.15f);
        }
        _sources[0].Play();
    }

    public void PlayClipAlternatingSources(string clipName, bool randomPitch)
    {
        //If this GameObject only has one source this method will simply
        //play the clip on one source.
        if (_sources.Length == 1)
        {
            PlayClip(clipName, randomPitch);
            return;
        }

        foreach (var source in _sources)
        {
            source.clip = _clipDictionary[clipName];
        }

        if (_alternatedSource)
        {
            if (randomPitch)
            {
                _sources[0].pitch = Random.Range(1, 1.15f);
            }
            _sources[0].Play();
            _alternatedSource = !_alternatedSource;
        }
        else
        {
            if (randomPitch)
            {
                _sources[1].pitch = Random.Range(1, 1.15f);
            }
            _sources[1].Play();
            _alternatedSource = !_alternatedSource;
        }
    }
}
