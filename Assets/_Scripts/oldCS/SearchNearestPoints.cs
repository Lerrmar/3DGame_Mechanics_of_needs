using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class SearchNearestPoints : MonoBehaviour
{
    List<GameObject> objs = new List<GameObject>();
    GameObject[] scene_objs;
    void Start()
    {
        ResourceObject texture = (ResourceObject)FindObjectOfType(typeof(ResourceObject));
        if (texture)
            Debug.Log("Water object found: " + texture.name);
        else
            Debug.Log("No Water object could be found");
    }
}
