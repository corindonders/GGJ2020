using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class SpawnAI : MonoBehaviour
{
    public List<GameObject> desks = new List<GameObject>();
    public List<Activity> activities = new List<Activity>();
    
    public GameObject baseAiObject;
    // Start is called before the first frame update
    void Start()
    {
        if (baseAiObject == null)
        {
            throw new Exception("Specify the AI prefab on the spawner ("+ transform.name +")");
        }

        int i = 0;
        foreach (var desk in desks)
        {
            var go = Instantiate(baseAiObject, desk.transform.position, Quaternion.identity);
            go.transform.name = $"Agent {i++}";
            var navAgent = go.GetComponent<NavAgentWorker>();
            navAgent.activities = activities;
            navAgent.workplace = desk;
            navAgent.agent = go.GetComponent<NavMeshAgent>();
        }
    }

}
