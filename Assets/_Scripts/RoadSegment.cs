using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegment : MonoBehaviour
{
    [SerializeField] private float _spawnRange;

    [SerializeField] private List<GameObject> _roadPrefabs;
    [SerializeField] private List<GameObject> _sideWalkPrefabs;
    [SerializeField] private List<Transform> _roadPoints;
    [SerializeField] private List<Transform> _sidewalkPoints;

    private void Start()
    {
        foreach (var roadPoint in _roadPoints)
        {
            int randomIndex = UnityEngine.Random.Range(0, _roadPrefabs.Count);
            Vector3 spawnPosition = new Vector3(roadPoint.position.x, UnityEngine.Random.Range(roadPoint.position.y - _spawnRange, roadPoint.position.y + _spawnRange), roadPoint.position.z);
            Instantiate(_roadPrefabs[randomIndex], spawnPosition, Quaternion.identity, gameObject.transform);
        }

        foreach (var sidewalkPoint in _sidewalkPoints)
        {
            int randomIndex = UnityEngine.Random.Range(0, _sideWalkPrefabs.Count);
            Vector3 spawnPosition = new Vector3(sidewalkPoint.position.x, UnityEngine.Random.Range(sidewalkPoint.position.y - _spawnRange, sidewalkPoint.position.y + _spawnRange), sidewalkPoint.position.z);
            Instantiate(_sideWalkPrefabs[randomIndex], spawnPosition, Quaternion.identity, gameObject.transform);
        }
    }

}