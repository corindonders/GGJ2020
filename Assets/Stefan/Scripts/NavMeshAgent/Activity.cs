using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Activity : MonoBehaviour
{
    public GameObject mainTarget;
    public List<GameObject> subTargets;
    public int maxNumberOnSubTarget = 1;
    private List<int> _numberOnSubTarget = new List<int>();
    public int maxTimeOnTarget = 10000;
    public int minTimeOnTarget = 1000;

    public List<Activity> alternativeActivities = new List<Activity>();

    private void Start()
    {
        for (var i = 0; i < subTargets.Count; i++)
        {
            _numberOnSubTarget.Add(0);
        }
    }

    public GameObject GetAvailableTarget()
    {
        int maxTries = 12;
        int tries = 0;
        int newGoal;
        do
        {
            newGoal = Random.Range(0, subTargets.Count);
            tries++;
        } while (_numberOnSubTarget[newGoal] >= maxNumberOnSubTarget && tries < maxTries);

        if (tries >= maxTries)
            return null;

        _numberOnSubTarget[newGoal]++;
        return subTargets[newGoal];
    }

    public Activity GetAlternativeActivity()
    {
        if (alternativeActivities.Count == 0)
            return null;

        int maxTries = 12;
        int tries = 0;
        int newGoal = Random.Range(0, alternativeActivities.Count);

        _numberOnSubTarget[newGoal]++;
        
        return alternativeActivities[newGoal];
    }

    public void DoneAtPosition(Vector3 position)
    {
        int closestId = -1;
        float closestDistance = 100f;
        for (var i = 0; i < subTargets.Count; i++)
        {
            var distance = Vector3.Distance(subTargets[i].transform.position, position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestId = i;
            }
        }

        if (closestId != -1)
        {
            StartCoroutine(EmptyPosition(closestId));
        }
    }
    
    public IEnumerator EmptyPosition(int targetId)
    {
        yield return new WaitForSeconds(2f);
        _numberOnSubTarget[targetId]--;
    }

    public int GetTimeToPerformTask()
    {
        return Random.Range(minTimeOnTarget, maxTimeOnTarget);
    }
}
