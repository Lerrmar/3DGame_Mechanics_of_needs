using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject WindowLB;

    public void LoadScenes(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OpenClose()
    {
        if (!WindowLB.activeSelf) WindowLB.SetActive(true);
        else WindowLB.SetActive(false);
    }
}