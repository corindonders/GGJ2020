using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnJanitor : MonoBehaviour
{
    public List<GameObject> spawnNodes = new List<GameObject>();
    public List<GameObject> pointsOfInterest = new List<GameObject>();
    
    public GameObject baseAiObject;
    
    void Start()
    {
        var i = 0;
        foreach (var spawn in spawnNodes)
        {
            var go = Instantiate(baseAiObject, spawn.transform.position, Quaternion.identity);
            go.name = $"Janitor {i}";

            var ai = go.GetComponent<NavAgentJanitor>();
            ai.office = spawn;
            ai.pointsOfInterest = pointsOfInterest;
            ai.agent = go.GetComponent<NavMeshAgent>();
        }
    }

}
