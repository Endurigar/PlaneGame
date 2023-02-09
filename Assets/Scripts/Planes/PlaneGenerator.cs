using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using OpenCover.Framework.Model;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] titlePrefab;
    [SerializeField] private Transform player;
    private List<GameObject> activeTitles = new List<GameObject>();
    private float spawnPos = 0;
    private readonly float titleLength = 250;
    private readonly int startTitles = 6;
    
    /// <summary>
    /// Generation of planes with their subsequent removal and cleaning of the map.
    /// </summary>
    private void Start()
    {
        AddListeners();
        StarterSpawn();
    }
    private void Update()
    {
        NewPlanesGenerate();
    }
    private void AddListeners()
    {
        ActionContainer.OnRestart += Clean;
    }
    private void SpawnPlane(int planeIndex)
    {
        GameObject nextTile = Instantiate(titlePrefab[planeIndex], transform.forward * spawnPos, transform.rotation);
        activeTitles.Add(nextTile);
        spawnPos += titleLength;
    }
    private void DeletePlane()
    {
        Destroy(activeTitles[0]);
        activeTitles.RemoveAt(0);
    }
    private void Clean()
    {
        for(int i = 0; i < activeTitles.Count; i++)
        {
            Destroy(activeTitles[i]);
        }
        activeTitles.Clear();
        spawnPos = 0;
        StarterSpawn();
    }
    private void StarterSpawn()
    {
        for (int i = 0; i < startTitles; i++)
        {
            SpawnPlane(Random.Range(0, titlePrefab.Length));
        }
    }

    private void NewPlanesGenerate()
    {
        if(player.position.z - titleLength > spawnPos - (startTitles *titleLength))
        {
            SpawnPlane(Random.Range(0, titlePrefab.Length));
            DeletePlane();
        }
    }
}
