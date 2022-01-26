using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Interface for Listeners
    public interface StateListener
    {
        void OnStateChange(activeScreen newScreen);
    }

    // List of Listeners
    private static List<StateListener> gamestateListeners;
    public static void AddListener(StateListener newListener)
    {
        //gamestateListeners.Add(newListener);
    }
    
    public enum activeScreen
    {
        INVENTORY,
        COOKING,
        IN_GAME,
        DIALOGUE,
        GAME_OVER
    }

    public static activeScreen currScreen;

    public static void ChangeActiveScreen(activeScreen screen)
    {
        currScreen = screen;
        if (currScreen == activeScreen.INVENTORY || currScreen == activeScreen.COOKING || currScreen == activeScreen.DIALOGUE)
            Time.timeScale = 0;
        else if (currScreen == activeScreen.IN_GAME || currScreen == activeScreen.GAME_OVER)
            Time.timeScale = 1;

        if (currScreen == activeScreen.IN_GAME)
        {
            /*foreach (StateListener i in gamestateListeners)
            {
                // Make sure every listener turns off their own canvases
            }*/
        }

        if (currScreen == activeScreen.COOKING)
        {
            /*foreach (StateListener i in gamestateListeners)
            {
                // make sure every listener turns off their own canvases
            }*/
        }
    }
}
