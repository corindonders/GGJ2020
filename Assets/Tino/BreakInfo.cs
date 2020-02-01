using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakInfo : MonoBehaviour
{
	public bool broken;

	public GameObject replacementPrefab;

	public bool Break()
	{
		if (broken)
			return false;

		broken = true;

		BreakObject();

		return true;
	}

	public bool Repair()
	{
		if (!broken)
			return false;

		broken = false;

		ReplacePrefab();

		return true;
	}

	private void ReplacePrefab()
	{
		GameObject replacement = Instantiate(replacementPrefab, transform.position, Quaternion.identity);

		replacement.transform.parent = gameObject.transform.parent;

		Destroy(gameObject);
	}

	private void BreakObject()
	{
		Rigidbody[] objectChildren = gameObject.GetComponentsInChildren<Rigidbody>();

		foreach (Rigidbody objectChild in objectChildren)
		{
			if (objectChild != null)
			{
				objectChild.isKinematic = false;

				objectChild.AddExplosionForce(300, gameObject.transform.position, 2);
			}
		}
	}
}
