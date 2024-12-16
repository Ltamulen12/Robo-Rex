using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leaveGame()
    {
        if (quitButton != null)
        {
            Application.Quit();
            Debug.Log("Quitting Game");
        }
    }
}
