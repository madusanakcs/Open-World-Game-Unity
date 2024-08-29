using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject mainPanel;

    private float videoDuration = 155f;
    private float elapsedTime = 0f;
    private bool videoPlayed = false;

    public void Start()
    {
        introPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void closeIntro()
    {
        introPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void Update()
    {
        // After video play (1.55 seconds), if the intro panel is still active, close it
        if (introPanel.activeSelf && !videoPlayed)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= videoDuration)
            {
                closeIntro();
                videoPlayed = true;
            }
        }

        // If press escape key, close the gameintro
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeIntro();
        }
    }
}
