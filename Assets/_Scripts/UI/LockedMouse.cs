using UnityEngine;
using static YG.ViewingAdsYG;

public class LockedMouse : MonoBehaviour
{
    [SerializeField] private bool _CursorLocked = true;
    private void Awake()
    {
        //Cursor.visible = false;
        CursorLocked();
    }

    public void CursorLocked()
    {
        if (_CursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Мышка залочена");
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Мышка разлочена");
        }
    }
}