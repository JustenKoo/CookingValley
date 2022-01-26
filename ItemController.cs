using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private bool playerNearItem;
    private GameObject item;
    private GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.FindWithTag("Food");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // todo: make sure the other is actually the player!
        playerNearItem = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // todo: make sure the other is actually the player!
        playerNearItem = false;
    }

    public bool getPlayerNearFire()
    {
        return playerNearItem;
    }
}
