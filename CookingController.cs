using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : MonoBehaviour
{
    private bool playerNearFire;
    public GameObject fireSource;
    private GameObject hud;
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
        // todo: make sure the other is actually the player!
        if(other.gameObject.name == "Player")
            playerNearFire = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // todo: make sure the other is actually the player!
        if (other.gameObject.name == "Player")
            playerNearFire = false;
    }

    public bool getPlayerNearFire()
    {
        return playerNearFire;
    }
}
