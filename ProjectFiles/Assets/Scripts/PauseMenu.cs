using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuObj; //menu objects and controllers required for pause
    bool isPaused = false;
    public Player player;
    public GameObject plane;
    PlaneController planeC;
    PlaneShooting planeS;
    EnterPlane planeE;
    // Start is called before the first frame update
    void Start()
    {
        menuObj.SetActive(false); //find all of the controllers
        planeC = plane.GetComponent<PlaneController>();
        planeS = plane.GetComponent<PlaneShooting>();
        planeE = plane.GetComponent<EnterPlane>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //when pressing Escape
        {
            if (!isPaused) //if the game is not paused yet
            {
                if (planeE.inPlane) //if the player is in the plane, disable the plane controls and freeze the time
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    menuObj.SetActive(true);
                    isPaused = true;
                    planeC.enabled = false;
                    planeS.enabled = false;
                }
                else //otherwise freeze the time and disable the player controller
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    menuObj.SetActive(true);
                    isPaused = true;
                    player.enabled = false;
                }
                
            } else //if already paused
            {
                if (planeE.inPlane) // if the player is in the plane, re-enable the plane controllers and time 
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = false;
                    menuObj.SetActive(false);
                    isPaused = false;
                    planeC.enabled = true;
                    planeS.enabled = true;
                }
                else //otherwise re-enable the player controller and time
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    menuObj.SetActive(false);
                    player.enabled = true;
                    isPaused = false;
                }
            }
        }
    }

    public void PressResume() // if pressing the resume button also re-enables the controllers and time accordingly
    {
        if (planeE.inPlane)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            menuObj.SetActive(false);
            isPaused = false;
            planeC.enabled = true;
            planeS.enabled = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menuObj.SetActive(false);
            Time.timeScale = 1;
            player.enabled = true;
            isPaused = false;
        }
    }

    public void PressMenu() //if pressing the menu button, the game will stop and load the main menu scene (losing all progress)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
