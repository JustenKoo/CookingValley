using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private bool playerNearNPC;
    private GameObject NPC;
    private GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.FindWithTag("NPC");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
            playerNearNPC = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
            playerNearNPC = false;
    }

    public bool getPlayerNearNPC()
    {
        return playerNearNPC;
    }
}
