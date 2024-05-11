using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadSegmentPrefab; // This is the prefab for a road segment
    public int numberOfSegments; // The number of road segments you want to spawn
    public float spawnY; // The Z-coordinate where the first segment of the road is spawned
    public float segmentLength; // The length of a road segment

    private List<GameObject> roadSegments = new List<GameObject>(); // This list holds all the road segments

    // This function is called in the Start function and spawns a given number of road segments
    public void Start()
    {
        for (int i = 0; i < numberOfSegments; i++)
        {
            SpawnRoadSegment();
        }
    }

    // This function is used to spawn a road segment
    private void SpawnRoadSegment()
    {
        GameObject segment = Instantiate(roadSegmentPrefab);
        segment.transform.SetParent(transform);
        segment.transform.position = Vector2.up * spawnY;
        spawnY += segmentLength;

        roadSegments.Add(segment);
    }

    // This function is used to despawn a road segment
    private void DespawnRoadSegment()
    {
        Destroy(roadSegments[0]);
        roadSegments.RemoveAt(0);
    }

    // This function is called in the Update function and continuously despawns the first road segment and spawns a new road segment
    // at the end of the road, thus giving the illusion of a continuous road
    public void Update()
    {
        if (roadSegments[0].transform.position.y < Camera.main.transform.position.y - segmentLength)
        {
            DespawnRoadSegment();
            SpawnRoadSegment();
        }
    }
}