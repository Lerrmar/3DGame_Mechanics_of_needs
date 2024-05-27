using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class SearchPathPoint : MonoBehaviour
{
    private NavMeshAgent agent;

    private GameObject[] targets;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    IEnumerator GetClosestTarget()
    {
        float tmpDist = float.MaxValue;
        GameObject currentTarget = null;
        for (int i = 0; i < targets.Length; i++)
        {
            if (agent.SetDestination(targets[i].transform.position))
            {
                //���� ���� ���������� ���� �� ����
                while (agent.pathPending)
                {
                    yield return null;
                }

                Debug.Log(agent.pathStatus.ToString());

                // ���������, ����� �� ����� �� ����
                if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    float pathDistance = 0;

                    //��������� ����� ����
                    pathDistance += Vector3.Distance(transform.position, agent.path.corners[0]);

                    for (int j = 1; j < agent.path.corners.Length; j++)
                    {
                        pathDistance += Vector3.Distance(agent.path.corners[j - 1], agent.path.corners[j]);
                    }

                    if (tmpDist > pathDistance)
                    {
                        tmpDist = pathDistance;
                        currentTarget = targets[i];
                        agent.ResetPath();
                    }
                }

                else
                {
                    Debug.Log("���������� ����� �� " + targets[i].name);
                }
            }
        }

        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.transform.position);
            //... ������ ���� ������ �������� � ����
        }
    }
}
