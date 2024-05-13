using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    
    [SerializeField] private List<Transform> _spawnPoints;

    private PoliceCarController _policeCar;

    public PoliceCarController ActivePoliceCar => _policeCar;
    public void SpawnCar()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        var go = Instantiate(_prefab, _spawnPoints[randomIndex].position, Quaternion.identity);
        
        _policeCar = go.GetComponent<PoliceCarController>();
    }
    
    
    
    
}