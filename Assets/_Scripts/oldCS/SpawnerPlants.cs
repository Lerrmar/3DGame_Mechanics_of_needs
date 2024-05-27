using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlants : MonoBehaviour
{
    [SerializeField] private GameObject[] _plants;
    [SerializeField] private List<Transform> _spawnPointsPlants;
    [SerializeField] private float _time = 15;


    private void Start()
    {
        StartCoroutine("DoCheckPlants");
    }
    public void SpawnPlants()
    {
        int spawnQuantity = Random.Range(1, 4);
        for (int i = 0; i < spawnQuantity; i++)
        {
            var spawn = Random.Range(0, _spawnPointsPlants.Count);
            Instantiate(_plants[i], _spawnPointsPlants[spawn].transform.position, Quaternion.identity);
            //_spawnPoints.RemoveAt(spawn);
        }
    }

    IEnumerator DoCheckPlants()
    {
        for (; ; )
        {
            //что-то сделать каждые  time секунд
            SpawnPlants();
            yield return new WaitForSeconds(_time);
        }
    }
}
