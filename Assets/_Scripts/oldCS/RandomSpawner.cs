using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _time = 30;


    private void Start()
    {
        StartCoroutine("DoCheck");
    }
    public void SpawnEnemys()
    {
        int spawnQuantity = Random.Range(1, 2);
        for ( int i = 0; i < spawnQuantity; i++ )
        {
            var spawn = Random.Range(0, _spawnPoints.Count);
            Instantiate(_enemys[0], _spawnPoints[spawn].transform.position, Quaternion.identity);
            //_spawnPoints.RemoveAt(spawn);
        }
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            //что-то сделать каждые  time секунд
            SpawnEnemys();
            yield return new WaitForSeconds(_time);
        }
    }
}
