using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollisionHandler : MonoBehaviour
{

    public BossController bc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bc.player)
        {
            bc.currState = BossController.boss_state.CHASING_PLAYER;
        }

        if (other.gameObject.name == "icecream" || other.gameObject.name == "icecream(Clone)")
        {
            bc.bait = other.gameObject;
            bc.currState = BossController.boss_state.CHASING_BAIT;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bc.currState = BossController.boss_state.GUARDING;
    }
}
