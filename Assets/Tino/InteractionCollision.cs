using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCollision : MonoBehaviour
{
	private GameObject destroyTarget;
	private GameObject carryTarget;

	private Hashtable destroyTargets = new Hashtable();
	private Hashtable carryTargets = new Hashtable();

	private void OnTriggerEnter(Collider other)
	{
		if (isCarry(other.GetComponent<CarryInfo>()))
			carryTarget.Add(other.name, other);

		if (isBreak(other.GetComponent<BreakInfo>()))
			destroyTargets.Add(other.name, other);

		Debug.Log("enter");
	}

	private void OnTriggerExit(Collider other)
	{
		if (isCarry(other.GetComponent<CarryInfo>()))
			carryTarget.Remove(other.name);

		if (isBreak(other.GetComponent<BreakInfo>()))
			destroyTargets.Remove(other.name);

		Debug.Log("exit");
	}

	private bool isCarry(CarryInfo carryInfo)
	{
		return carryInfo != null;
	}

	private bool isBreak(BreakInfo breakInfo)
	{
		return breakInfo != null;
	}
}
