using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Menu : MonoBehaviour
{

    Button[] buttons;
    bool start;

    void Start()
    {
        // Store button objects in the array
        buttons = FindObjectsOfType<Button>();

        // Highlight first button at the start
        buttons[1].Select();
        start = true;
    }

    void Update()
    {
        // Checks if a menu item has been selected
        MenuSelect();

        // Keeps the right button selected even when clicking away from Canvas
        KeepSelected();

        // Toggle between the highlighted buttons
        ToggleButton(buttons);
    }

    private void KeepSelected()
    {
        if (start == true)
        {
            buttons[1].Select();
        }
        else
        {
            buttons[0].Select();
        }
    }

    private void ToggleButton(Button[] buttons)
    {
        // Toggle between button states
        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            buttons[1].Select();
            start = true;
        }
        else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            buttons[0].Select();
            start = false;
        }
    }

    // Mouse clicks won't work while Graphic Raycaster (Script) is disabled
    public void MouseStart()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void MouseQuit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }

    private void MenuSelect()
    {
        if (Input.GetKeyDown("space") && start == true)
        {
            StartCoroutine("StartGame");
        }
        else if (Input.GetKeyDown("space") && start == false)
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }

    IEnumerator StartGame() {
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene(1);
    }
}
