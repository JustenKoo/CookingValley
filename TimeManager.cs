using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public GameObject SkyContainer;

    public List<TimedResourceController>  trc;

    public enum time_block
    {
        MIDNIGHT,       // 00:00, moon at peak, sun at lowest
        EARLY_MORNING,  // 06:00, sunrise begins, moon is at lowest
        NOON,           // 12:00, sun at peak
        EVENING,        // 18:00, sunset + moonrise begins
    }

    public int gameDay = 0;
    public float gameTime;
    public time_block gameTimeCategory = time_block.NOON;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = 600;
        InvokeRepeating("RotateSky", 0, 1);
        InvokeRepeating("ChangeToMorning", 900, 1200);
        InvokeRepeating("ChangeToNoon", 0, 1200);
        InvokeRepeating("ChangeToEvening", 60, 1200);
        /*InvokeRepeating("ChangeToEvening", 300, 1200);*/
        InvokeRepeating("ChangeToMidnight", 600, 1200);
    }

    // Each in game Day/Night cycle takes 20 min
    // 20 min = 20 * 60s -> 1,200 sec
    // each second advances .02 hours meaning 1 in game hour takes 50 sec
    // a time_block change occurs every 50 X 6 = 300 sec
    void Update()
    {
        gameTime += Time.deltaTime;
    }

    public void RotateSky()
    {
        SkyContainer.transform.Rotate(0.3f, 0, 0, Space.Self);
        //SkyContainer.transform.Rotate(0.3f, 0, 0, Space.Self);
    }

    // Changes the skybox to morning
    public void ChangeToMorning()
    {
        gameTimeCategory = time_block.EARLY_MORNING;
        foreach (TimedResourceController i in trc)
        {
            i.ReplenishResource(gameTimeCategory);
        }
    }

    // Changes the skybox to noon
    public void ChangeToNoon()
    {
        gameTimeCategory = time_block.NOON;
        foreach (TimedResourceController i in trc)
        {
            i.ReplenishResource(gameTimeCategory);
        }
    }

    // Changes the skybox to evening
    public void ChangeToEvening()
    {
        gameTimeCategory = time_block.EVENING;
        foreach (TimedResourceController i in trc)
        {
            i.ReplenishResource(gameTimeCategory);
        }
    }

    // Changes the skybox to midnight
    public void ChangeToMidnight()
    {
        gameDay++;
        gameTimeCategory = time_block.MIDNIGHT;
        foreach (TimedResourceController i in trc)
        {
            i.ReplenishResource(gameTimeCategory);
            i.ResetDropBool();
        }
    }
}
