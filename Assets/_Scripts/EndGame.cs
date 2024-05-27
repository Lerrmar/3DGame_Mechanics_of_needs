using Plugins.Audio.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private SourceAudio _sourceEND;
    [SerializeField] private GameObject _sourceSTART;
    private String[] soundArr = new String[] { "smeetsaEND", "naniEND"};
    [SerializeField] private GameObject _endWindowON;

    private void Start()
    {
        _sourceSTART = GameObject.FindGameObjectWithTag("Player");
        _sourceEND = _sourceSTART.GetComponent<SourceAudio>();
    }
    public void DeathWindow()
    {
        string rElementSoundEND = soundArr[UnityEngine.Random.Range(0, soundArr.Length)];

        _sourceEND.Play(rElementSoundEND);
        _endWindowON.SetActive(true);
        StopAllCoroutines();
    }
}
