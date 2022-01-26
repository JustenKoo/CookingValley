using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles when a GameObject replenishes its specific resource
public class TimedResourceController : MonoBehaviour
{
    public GameObject provider;
    public GameObject resource;
    public TimeManager tm;
    public TimeManager.time_block replenishTime;
    public int x_offset;
    public int y_offset;
    public int z_offset;
    public bool hasDroppedForTheDay;


    void Start()
    {
        tm = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    public void ReplenishResource(TimeManager.time_block time)
    {
        if(replenishTime == time && hasDroppedForTheDay == false)
        {
            Instantiate(resource, new Vector3(provider.transform.position.x + x_offset, provider.transform.position.y + y_offset, provider.transform.position.z + z_offset), Quaternion.identity);
            hasDroppedForTheDay = true;
        }
    }

    public void ResetDropBool()
    {
        hasDroppedForTheDay = false;
    }
}
