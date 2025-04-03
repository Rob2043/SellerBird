using System.Collections.Generic;
using UnityEngine;
using CONSTANTS;


public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _ObstaclePrefab;
    [SerializeField] private GameObject _CloudsPrefab;
    private List<GameObject> _ObjectsPool = new List<GameObject>();
    private List<GameObject> _cloudsObjectsPool = new List<GameObject>();
    private Vector2 _spawnPosition;
    private int _distanceToSpawn = 0;
    private int _cloudsDistanceToSpawn = 0;

    public void Init()
    {
        _spawnPosition = transform.position;
        _distanceToSpawn = (int)_spawnPosition.x;
        _cloudsDistanceToSpawn = (int)_spawnPosition.x;


        for (int i = 0; i < SCRIPT_CONSTANS.ObstacleCount; i++)
        {
            if (i != 0)
                _distanceToSpawn += Random.Range(SCRIPT_CONSTANS.MinGapForSpawning, SCRIPT_CONSTANS.MaxGapForSpawning);
            Vector2 position = new Vector2(_distanceToSpawn, _spawnPosition.y);
            GameObject obj = Instantiate(_ObstaclePrefab, new Vector2(position.x, 0), Quaternion.identity);
            _ObjectsPool.Add(obj);
        }

        for (int i = 0; i < SCRIPT_CONSTANS.CloudCount; i++)
        {
            if (i != 0)
                _cloudsDistanceToSpawn += Random.Range(SCRIPT_CONSTANS.MinDistanceForCloudsX, SCRIPT_CONSTANS.MaxDistanceForCloudsX);
            int randomY = Random.Range(SCRIPT_CONSTANS.MinYForCloud, SCRIPT_CONSTANS.MaxYForCloud);
            Vector2 position = new Vector2(_cloudsDistanceToSpawn, randomY);
            GameObject obj = Instantiate(_CloudsPrefab, position, Quaternion.identity);
            _cloudsObjectsPool.Add(obj);
        }
    }

    void Update()
    {
        if (_ObjectsPool[0].transform.position.x < SCRIPT_CONSTANS.PositionForRespawning)
        {
            Respawn(_ObjectsPool[0]);
        }
        if (_cloudsObjectsPool[0].transform.position.x < SCRIPT_CONSTANS.PositionForRespawning)
        {
            Respawn(_cloudsObjectsPool[0]);
        }
    }

    private void Respawn(GameObject firstObject)
    {
        if (firstObject.tag == "Obstacle")
        {
            _ObjectsPool.RemoveAt(0);
            float distanceToSpawn = Random.Range(SCRIPT_CONSTANS.MinGapForSpawning, SCRIPT_CONSTANS.MaxGapForSpawning);
            firstObject.transform.position = new Vector2(_spawnPosition.x + distanceToSpawn, _spawnPosition.y);
            _ObjectsPool.Add(firstObject);
        }
        else if (firstObject.tag == "Cloud")
        {
            _cloudsObjectsPool.RemoveAt(0);
            float cloudsDistanceToSpawn = Random.Range(SCRIPT_CONSTANS.MinDistanceForCloudsX, SCRIPT_CONSTANS.MaxDistanceForCloudsX);
            int randomY = Random.Range(SCRIPT_CONSTANS.MinYForCloud, SCRIPT_CONSTANS.MaxYForCloud);
            firstObject.transform.position = new Vector2(_spawnPosition.x + cloudsDistanceToSpawn, randomY);
            _cloudsObjectsPool.Add(firstObject);
        }
    }
}
