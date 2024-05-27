using Plugins.Audio.Core;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private SourceAudio _sourceAudio;
    public bool _isPlayingMusic = true;
    static private GameObject firstInstance = null;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (firstInstance == null)
            firstInstance = gameObject;
        else if (gameObject != firstInstance)
            Destroy(gameObject);         // самоуничтожение

        if (_isPlayingMusic )
        {
            //_sourceAudio.Play("EnergeticRock");
        }
    }

    public  void MusicOn()
    {
        _isPlayingMusic = true;
        _sourceAudio.Mute = false;
        //_sourceAudio.Play("EnergeticRock");
    }

    public  void MusicOff()
    {
        _isPlayingMusic = false;
        _sourceAudio.Mute = true;
    }
}