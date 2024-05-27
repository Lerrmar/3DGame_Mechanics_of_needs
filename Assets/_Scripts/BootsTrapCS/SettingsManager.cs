using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;

        }

        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public int WaterBarrel;
}
