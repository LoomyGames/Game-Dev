using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject QuitMenu;
    public GameObject OptionsMenu;
    public Button StartGame;
    public Button Options;
    public Button Quit;

    // Start is called before the first frame update
    public void Start()
    {
        QuitMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void StartClick()
    {
        SceneManager.LoadScene("GameLobby");
    }
    public void OptionsClick()
    {
        OptionsMenu.SetActive(true);
        DisableButtons();
    }
    public void QuitClick()
    {
        QuitMenu.SetActive(true);
        DisableButtons();
    }
    public void YesClick()
    {
        Application.Quit();
    }
    public void NoClick()
    {
        QuitMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        EnableButtons();
    }

    public void DisableButtons()
    {
        StartGame.enabled = false;
        Options.enabled = false;
        Quit.enabled = false;
    }
    public void EnableButtons()
    {
        StartGame.enabled = true;
        Options.enabled = true;
        Quit.enabled = true;
    }
}
