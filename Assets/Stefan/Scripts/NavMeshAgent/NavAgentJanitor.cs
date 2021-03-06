﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;
using Random = UnityEngine.Random;

public class NavAgentJanitor : MonoBehaviour
{
    public GameObject office;
    public List<GameObject> pointsOfInterest;
    public int minIdleTime = 5000;
    public int maxIdleTime = 20000;
    public int minNumberOfPoints = 5;
    public float chanceToStopCheck = 0.9995f;
    public NavMeshAgent agent;

    public bool isPlayerInside;

    public ThirdPersonCharacter character { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updatePosition = true;
        agent.destination = office.transform.position;
        character = GetComponent<ThirdPersonCharacter>();
        StartCoroutine(DoRegularCheck());
    }
    
    public IEnumerator DoRegularCheck()
    {
        yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime)/1000f);
        int pointsVisited = 0;
        int currentPointId = -1;
        do
        {
            // Find next point
            int newPointId;
            do
            {
                newPointId = Random.Range(0, pointsOfInterest.Count);
            } while (newPointId == currentPointId);

            agent.destination = pointsOfInterest[newPointId].transform.position;
            currentPointId = newPointId;
            pointsVisited++;
            // Wait until POI has been visited
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance < 1f);
        } while (pointsVisited <= minNumberOfPoints || Random.value >= chanceToStopCheck);
        
        // Return back to the office;
        agent.destination = office.transform.position;

        StartCoroutine(DoRegularCheck());
    }

    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
        
 
    }

    void OnTriggerEnter(Collider Other){
        if(Other.gameObject.name == "ThirdPersonController"){
            isPlayerInside= true;
        }
    }

    void OnTriggerExit(Collider Other){
        if(Other.gameObject.name == "ThirdPersonController"){
            isPlayerInside= false;     
        }
    }
}
