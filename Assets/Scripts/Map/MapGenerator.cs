using System.Collections.Generic;
using UnityEngine;
using CONSTANTS;


public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _ObstaclePrefab;
    private List<GameObject> _ObjectsPool = new List<GameObject>();
    private Vector2 _spawnPosition;
    private int _distanceToSpawn = 0;
    public void Init()
    {
        _spawnPosition = transform.position;
        _distanceToSpawn = (int)_spawnPosition.x;
        for (int i = 0; i < SCRIPT_CONSTANS.ObstacleCount; i++)
        {
            if (i != 0)
                _distanceToSpawn += Random.Range(SCRIPT_CONSTANS.MinGapForSpawning, SCRIPT_CONSTANS.MaxGapForSpawning);
            Vector2 position = new Vector2(_distanceToSpawn, _spawnPosition.y);
            GameObject obj = Instantiate(_ObstaclePrefab, new Vector2(position.x, 0), Quaternion.identity);
            _ObjectsPool.Add(obj);
        }
        _distanceToSpawn = (int)_spawnPosition.x;
    }
    void Update()
    {
        if (_ObjectsPool[0].transform.position.x < SCRIPT_CONSTANS.PositionForRespawning)
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        GameObject firstObject = _ObjectsPool[0];
        _ObjectsPool.RemoveAt(0);
        firstObject.transform.position = new Vector2(_distanceToSpawn, _spawnPosition.y);
        _ObjectsPool.Add(firstObject);
    }
}
