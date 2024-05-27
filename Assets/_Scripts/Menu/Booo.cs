using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booo : MonoBehaviour
{
    [SerializeField] private GameObject _booo;
    [SerializeField] private Joint _boooJoint;
    [SerializeField] private GameObject _boooPosition;
    [SerializeField] private string _hitTeg = "GarbageObject";


    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag(_hitTeg))
        {
            //_boooJoint.en = false;
            _booo.transform.position = _boooPosition.transform.position;
            Invoke("DestroyObject", 3);
        }
    }

    private void DestroyObject()
    {
        Destroy(_booo);

    }
}
