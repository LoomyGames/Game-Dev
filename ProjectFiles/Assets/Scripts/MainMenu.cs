using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject QuitMenu; //reference all of the UI elements
    public GameObject OptionsMenu;
    public Button StartGame;
    public Button Options;
    public Button Quit;

    // Start is called before the first frame update
    public void Start() //disable the options (controls) and quit sub-menus
    {
        QuitMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void StartClick() //start the game by going to the lobby scene if start is pressed
    {
        SceneManager.LoadScene("GameLobby");
    }
    public void OptionsClick() //if the user presses options (now controls) enable that submenu and disable the other buttons
    {
        OptionsMenu.SetActive(true);
        DisableButtons();
    }
    public void QuitClick() //if the user presses quit, enable that submenu for confirmation and disable the other buttons
    {
        QuitMenu.SetActive(true);
        DisableButtons();
    }
    public void YesClick() // quit the game if yes is selected on the submenu
    {
        Application.Quit();
    }
    public void NoClick() // return to the original state if no is slected on the submenu
    {
        QuitMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        EnableButtons();
    }

    public void DisableButtons() // method for disabling all of the buttons
    {
        StartGame.enabled = false;
        Options.enabled = false;
        Quit.enabled = false;
    }
    public void EnableButtons() //method for re-enabling the buttons
    {
        StartGame.enabled = true;
        Options.enabled = true;
        Quit.enabled = true;
    }
}
