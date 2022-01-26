using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject cameraGoal;
    public float snapiness;
    private GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        cameraGoal = GameObject.Find("Player");
        player = GameObject.Find("Player");
        offset = new Vector3(transform.position.x, 2f, transform.position.z) - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 computedGoal = player.transform.position;
        Quaternion playerYRotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
        computedGoal = computedGoal + (playerYRotation * Vector3.forward * offset.z);
        computedGoal = computedGoal + Vector3.up * offset.y;
        this.transform.position = Vector3.Lerp(this.transform.position, computedGoal, snapiness);
        this.transform.LookAt(player.transform.position + player.transform.forward * 2);
    }
}
