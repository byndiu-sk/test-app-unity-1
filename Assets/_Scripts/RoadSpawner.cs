using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject startingSegmentPrefab; // This is the prefab for the starting road segment
    public List<GameObject> roadSegmentPrefabs; // This is the list of prefabs for road segments
    public int numberOfSegments; // The number of road segments you want to spawn
    public float spawnY; // The Y-coordinate where the first segment of the road is spawned
    public float segmentLength; // The length of a road segment

    private List<GameObject> roadSegments = new List<GameObject>(); // This list holds all the road segments

    // This function is called in the Start function and spawns a given number of road segments
    public void Start()
    {
        SpawnStartingSegment(); // spawn starting segment first

        for (int i = 1; i < numberOfSegments; i++)  // i starts from 1 because starting segment is already spawned
        {
            SpawnRoadSegment();
        }
    }

    private void SpawnStartingSegment()
    {
        GameObject segment = Instantiate(startingSegmentPrefab);
        segment.transform.SetParent(transform);
        segment.transform.position = new Vector3(0, spawnY, 0);
        spawnY += segmentLength;

        roadSegments.Add(segment);
    }

    // This function is used to spawn a road segment
    private void SpawnRoadSegment()
    {
        GameObject segment = Instantiate(roadSegmentPrefabs[Random.Range(0, roadSegmentPrefabs.Count)]);
        segment.transform.SetParent(transform);
        segment.transform.position = new Vector3(0, spawnY, 0);
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