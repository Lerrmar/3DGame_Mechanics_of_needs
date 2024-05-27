using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NPCMovement : MonoBehaviour
{
    public GameObject[] targetPoints; // Points to move to
    public float stoppingDistance = 0.1f; // Distance threshold to stop at target
    public float moveSpeed = 3f; // Movement speed

    [SerializeField]
    private NavMeshAgent _agent; // Reference to the NavMeshAgent component
    private bool isMoving = false; // Flag to indicate whether NPC is currently moving

    public void MoveToTarget(int index)
    {
        if (index >= 0 && index < targetPoints.Length)
        {
            GameObject _transformPoint = targetPoints[index];
            _agent.SetDestination(_transformPoint.transform.position);

            isMoving = true;
        }
        else
        {
            Debug.LogWarning("Invalid target index provided.");
        }
    }
}