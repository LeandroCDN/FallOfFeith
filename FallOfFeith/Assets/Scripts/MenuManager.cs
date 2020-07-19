using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;

    public Canvas menuCanvas;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;
    public Canvas winCanvas;


    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }


    public void ShowMainMenu()
    {
        menuCanvas.enabled = true;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        winCanvas.enabled = false;


    }

    public void HideMainMenu()
    {
        menuCanvas.enabled = false;
        gameCanvas.enabled = true;
        gameOverCanvas.enabled = false;
        winCanvas.enabled = false;
    }

    public void ShowGameOverMenu()
    {
        menuCanvas.enabled = false;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        winCanvas.enabled = false;
    }

    public void ShowWinMenu()
    {
        menuCanvas.enabled = false;
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        winCanvas.enabled = true;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
