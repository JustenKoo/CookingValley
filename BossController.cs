using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public string BossName;

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    private GameObject currTarget;
    private float waitTime;

    public GameObject triggerSphere;
    public GameObject player;
    public GameObject bait;

    public enum boss_state
    {
        GUARDING,
        CHASING_PLAYER,
        CHASING_BAIT
    }

    public boss_state currState;

    private void Start()
    {
        currState = boss_state.GUARDING;
        waitTime = Random.Range(0f, 10f);
        currTarget = target1;
    }
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (this.transform.position != currTarget.transform.position)
        {
            float speed = 1f;

            if (currState == boss_state.CHASING_BAIT)
            {
                currTarget = bait;
                speed = 3f;
            }
            else if (currState == boss_state.CHASING_PLAYER)
            {
                currTarget = player;
                speed = 6f;
            }
            else if (currState == boss_state.GUARDING)
            {
                currTarget = target1;
                speed = 1f;
            }

            float step = speed * Time.deltaTime;

            this.transform.LookAt(currTarget.transform);
            this.transform.position = Vector3.MoveTowards(this.transform.position, currTarget.transform.position, step);
        }

        if (this.transform.position == currTarget.transform.position || this.transform.position.z > 275 || this.transform.position.z < 225 || this.transform.position.x > 135 || this.transform.position.x < 70)
            changeLocation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "icecream")
        {
            collision.gameObject.SetActive(false);
            currState = boss_state.GUARDING;
        }
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