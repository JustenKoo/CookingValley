using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
	public GameObject target1;
	public GameObject target2;
	public GameObject target3;
	private GameObject currTarget;
	private float waitTime;

    private void Start()
    {
		waitTime = Random.Range(0f, 10f);
		currTarget = target1;
    }
    void Update()
	{
		waitTime -= Time.deltaTime;
		if (this.transform.position.x != currTarget.transform.position.x && this.transform.position.z != currTarget.transform.position.z)
		{
			float step = 1f * Time.deltaTime;
			this.transform.LookAt(currTarget.transform);
			this.transform.position = Vector3.MoveTowards(this.transform.position, currTarget.transform.position, step);
		}

		if (waitTime <= 0)
			changeLocation();
	}

	public void changeLocation()
	{
		float tempValue = Random.Range(0f, 3f);
		if (tempValue >= 0f && tempValue < 1f)
		{
			if (currTarget != target1)
			{
				currTarget = target1;
				waitTime = Random.Range(0f, 10f);
			}
			else
				changeLocation();
		}
		else if (tempValue >= 1f && tempValue < 2f)
		{
			if (currTarget != target2)
			{
				currTarget = target2;
				waitTime = Random.Range(0f, 10f);
			}
			else
				changeLocation();
		}
		else if (tempValue >= 2f && tempValue <= 3f)
		{
			if (currTarget != target3)
			{
				currTarget = target3;
				waitTime = Random.Range(0f, 10f);
			}
			else
				changeLocation();
		}
	}
}
