using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnAI : MonoBehaviour
{
    public List<GameObject> desks = new List<GameObject>();
    public List<Activity> activities = new List<Activity>();
    
    public List<GameObject> baseAiObjects = new List<GameObject>();

    [Range(0, 100)]
    public int spawnPercentage = 50;
    // Start is called before the first frame update
    void Start()
    {
        if (baseAiObjects.Count == 0)
        {
            throw new Exception("Specify an AI prefab on the spawner ("+ transform.name +")");
        }

        var maxToSpawn = desks.Count / 100f * spawnPercentage;
        var usedDesks = new List<int>();
        for (var i = 0; i < maxToSpawn; i++)
        {
            var deskId = -1;
            do
            {
                deskId = Random.Range(0, desks.Count);
            } while (usedDesks.Contains(deskId));

            var desk = desks[deskId];
            usedDesks.Add(deskId);
            
            var obj = baseAiObjects[Random.Range(0, baseAiObjects.Count)];
            var go = Instantiate(obj, desk.transform.position, Quaternion.identity);
            go.transform.name = $"Agent {i++}";
            var navAgent = go.GetComponent<NavAgentWorker>();
            navAgent.activities = activities;
            navAgent.workplace = desk;
            navAgent.agent = go.GetComponent<NavMeshAgent>();
            RandomizeNavAgent(navAgent.agent);
        }
    }

    void RandomizeNavAgent(NavMeshAgent navAgent)
    {
        navAgent.speed = Random.Range(0.2f, 1f);
        navAgent.angularSpeed = Random.Range(80, 130);
        navAgent.acceleration = Random.Range(7f, 10f);
        navAgent.stoppingDistance = Random.Range(0.1f, 0.3f);
    }

}
