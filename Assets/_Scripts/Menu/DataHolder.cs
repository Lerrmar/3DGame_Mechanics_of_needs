using UnityEngine;

public static class DataHolder
{
    private static bool _isPlayingMusic;

    public static bool PlayingMusic
    {
        get
        {
            return _isPlayingMusic;
        }
        set
        {
            PlayingMusic = value;
        }
    }
}