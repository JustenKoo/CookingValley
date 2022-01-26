using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject ProducerCanvas;
    public GameObject CreditsCanvas;
    public GameObject MainMenuCanvas;
    // public GameObject LoadingCanvas;

    private float themeTimer;

    // Start is called before the first frame update
    void Awake()
    {
        ProducerCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        // LoadingCanvas.SetActive(false);
        themeTimer = 9.5f;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        themeTimer -= Time.deltaTime;
        if(themeTimer <= 0)
        {
            startCreditsCanvas();
        }

        if ((CreditsCanvas.activeSelf == true || ProducerCanvas.activeSelf == true) && Input.anyKeyDown == true)
        {
            themeTimer = 0;
            startMenuCanvas();
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void startCreditsCanvas()
    {
        ProducerCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
    }

    private void startMenuCanvas()
    {
        ProducerCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
        // FindObjectOfType<AudioManager>().Play("Wind");
    }

    public void startGame()
    {
        Debug.Log("Help");
        SceneManager.LoadScene("SampleScene");
    }
}
