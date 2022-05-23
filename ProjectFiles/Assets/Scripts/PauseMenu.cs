using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuObj;
    bool isPaused = false;
    public Player player;
    public GameObject plane;
    PlaneController planeC;
    PlaneShooting planeS;
    EnterPlane planeE;
    // Start is called before the first frame update
    void Start()
    {
        menuObj.SetActive(false);
        planeC = plane.GetComponent<PlaneController>();
        planeS = plane.GetComponent<PlaneShooting>();
        planeE = plane.GetComponent<EnterPlane>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                if (planeE.inPlane)
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    menuObj.SetActive(true);
                    isPaused = true;
                    planeC.enabled = false;
                    planeS.enabled = false;
                }
                else
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    menuObj.SetActive(true);
                    isPaused = true;
                    player.enabled = false;
                }
                
            } else
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

    public void PressResume()
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

    public void PressMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
