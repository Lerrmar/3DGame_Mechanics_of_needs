using UnityEngine;

public class GarbageCleaning : MonoBehaviour
{
    [SerializeField] private string _objectTeg = "GarbageObject";
    [SerializeField] private string _playerTeg = "Player";
    [SerializeField] private GameObject _enableEvent;
    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag(_objectTeg))
        {
            Destroy(otherObject.gameObject);
        }

        if (otherObject.CompareTag(_playerTeg))
        {
            _enableEvent.SetActive(true);
            Destroy(otherObject.gameObject);
        }
    }
}
