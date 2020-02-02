using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine;
using UnityEngine.AI;

enum ActivityState
{
    Working,
    WalkingToWorkSpace,
    PerformingActivity,
    WalkingToActivity,
}

public class NavAgentWorker : MonoBehaviour
{
    private ActivityState _state = ActivityState.WalkingToWorkSpace;
    private int _activityProgress = 0;
    public GameObject workplace;
    public List<Activity> activities = new List<Activity>();

    public int lastGoal = -1;

    public NavMeshAgent agent;

    private List<int> _blockedActivities = new List<int>();
    public ThirdPersonCharacter character { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        MoveToDesk();
        character = GetComponent<ThirdPersonCharacter>();
    }

    private void MoveToDesk()
    {
        agent.destination = workplace.transform.position;
        _state = ActivityState.WalkingToWorkSpace;
    }

    private int GetPrioritisedActivity()
    {
        var prioritisedActivities = new List<int>();
        for (var i = 0; i < activities.Count; i++)
        {
            prioritisedActivities.Add(i);
        }
        prioritisedActivities.AddRange(_blockedActivities);
        
        // Find a new activity, don't do the same activity twice in a row, unless it failed.
        int newActivity;
        do
        {
            newActivity = prioritisedActivities[Random.Range(0, prioritisedActivities.Count)];
        } while (newActivity == lastGoal && !prioritisedActivities.Contains(newActivity));

        // TODO: Move to succesfully finishing task
        // _blockedActivities = _blockedActivities.Where(b => b != newGoal).ToList();

        return newActivity;
    }

    public IEnumerator ProgressActivity(int msTime)
    {
        yield return new WaitForSeconds(msTime/1000f);
        activities[lastGoal].DoneAtPosition(transform.position);
        MoveToDesk();
    }
    
    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
        
        
        if ((_state == ActivityState.Working || _state == ActivityState.WalkingToWorkSpace))
        {
            if (Random.value > 0.9999f)
            {
                var newActivity = GetPrioritisedActivity();

                agent.destination = activities[newActivity].mainTarget.transform.position;
                _state = ActivityState.WalkingToActivity;
                _activityProgress = 0;
                lastGoal = newActivity;
            }
        }
        else if (!agent.pathPending && agent.remainingDistance < 1f && lastGoal >= 0)
        {
            if (_activityProgress == 0)
            {
                var target = activities[lastGoal].GetAvailableTarget();
                if (target == null)
                {
                    Debug.Log($"{transform.name}: My task was blocked, no empty places left");
                    _blockedActivities.Add(lastGoal);
                    MoveToDesk();
                }
                else
                {
                    agent.destination = target.transform.position;
                    _state = ActivityState.WalkingToActivity;
                    _activityProgress++;
                }
            }
            else
            {
                if (_state != ActivityState.Working && _state != ActivityState.WalkingToWorkSpace)
                {
                    _state = ActivityState.PerformingActivity;
                    StartCoroutine(ProgressActivity(activities[lastGoal].GetTimeToPerformTask()));
                }
            }
        }
    }
}
