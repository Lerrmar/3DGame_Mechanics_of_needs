using UnityEngine;
using UnityEngine.UI;

public class ObjectPickup : MonoBehaviour
{
    [SerializeField] private Rigidbody selectedRigidbody;
    [SerializeField] Camera targetCamera;
    private float _rayDistance = 3;
    [SerializeField] private GameObject JointHand;
    [SerializeField] private LayerMask ToolsMask;
    int layerMask = 1 << 7;
    public Joint Joint;

    [SerializeField] private GameObject _spriteHand;

    private RaycastHit _raisedItem;
    [SerializeField] private float _throwStrength = 1000;

    void Update()
    {
        if (!targetCamera)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            //ѕровер€ем, наводим ли мы курсор на Rigidbody, если да, то выбираем его
            selectedRigidbody = GetRigidbodyFromMouseClick();
            
            if (_raisedItem.rigidbody != null)
            {
                _spriteHand.SetActive(true);
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedRigidbody != null)
        {
            //ќсвободим выбранное Rigidbody, если оно есть
            _spriteHand.SetActive(false);
            selectedRigidbody = null;
            Joint.connectedBody = null;
            //Joint.connectedAnchor = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.F) && selectedRigidbody)
        {
            if (_raisedItem.rigidbody != null)
            {
                _spriteHand.SetActive(false);
                selectedRigidbody = null;
                Joint.connectedBody = null;
                //Joint.connectedAnchor = new Vector3(0, 0, 0);
                Ray rayRaise = targetCamera.ScreenPointToRay(Input.mousePosition);
                _raisedItem.rigidbody.AddForce(rayRaise.direction.normalized * _throwStrength);
            }
        }
    }

    Rigidbody GetRigidbodyFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo, _rayDistance, layerMask);
        _raisedItem = hitInfo;

        if (hit)
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            {
                JointHand.transform.position = hitInfo.point;
                Joint.connectedBody = hitInfo.rigidbody;
                return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
            }
        }
        return null;
    }
}

