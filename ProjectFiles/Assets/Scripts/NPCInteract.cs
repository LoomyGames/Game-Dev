using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    private Image Crosshair;//reference the UI elements involved, as well as the player controller
    private Image DialogueBox;
    private Image ChoiceBox;
    private Text interactText;
    private Text dialogueText;
    private Player player;
    bool inDialogue = false;
    GameObject ChoiceText;

    public string[] Dialogues;
    public string[] Choices;

    // Start is called before the first frame update
    void Awake() //find all of the elements based on tags and deactivate them 
    {
        Crosshair = GameObject.FindWithTag("Crosshair").GetComponent<Image>();
        DialogueBox = GameObject.FindWithTag("DialogueBox").GetComponent<Image>();
        dialogueText = GameObject.FindWithTag("DialogueText").GetComponent<Text>();
        DialogueBox.enabled = false;
        ChoiceBox = GameObject.FindWithTag("ChoiceBox").GetComponent<Image>();
        ChoiceBox.enabled = false;
        interactText = GameObject.FindWithTag("InteractText").GetComponent<Text>();
        interactText.enabled = false;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        ChoiceText = (GameObject)Resources.Load("Prefabs/ChoiceText");

    }

    private void OnTriggerStay(Collider other) //while the player is in the NPC's trigger
    {
        if(other.tag == "Player")
        {
            if (!inDialogue) // if the player is not already engaged in dialogue, show the "Press E" prompt
            {
                interactText.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.E)) // if the player interacts
            {
                //Debug.Log("Pressed E");
                if (!inDialogue) //if not in the dialogue already
                {
                    player.SetInteraction(gameObject); // send a signal that the player is interacting with this specific NPC
                    for (int i = 0; i < Choices.Length; i++) // enable all of the selected options (Talk, Leave for this demo, but it's scalable)
                    {
                        GameObject choiceInstance = Instantiate(ChoiceText, ChoiceBox.transform);
                        choiceInstance.GetComponent<Text>().text = Choices[i];
                    }
                    DialogueBox.enabled = true; //enable the UI elements and disable the player controller
                    Crosshair.enabled = false;
                    player.enabled = false;
                    interactText.enabled = false;
                    ShowDialogue(0); //show the "I am NPC name" option which is always the first one, and can't be repeated in the random selections below
                    ChoiceBox.enabled = true;
                   
                    foreach (Transform child in ChoiceBox.transform) //enable the choices (options)
                    {
                        child.GetComponent<Text>().enabled = true;
                    }
                    UnlockMouse(); //unlock the mouse to be able to click
                    inDialogue = true;
                }else // otherwise do the exact opposite of all that and disable the UI elements
                {
                    HideMenu(); 
                }
                
            }

        }
    }

    private void OnTriggerExit(Collider other) //if the player leaves the trigger, the prompt disappears
    {
        if(other.tag == "Player")
        {
            interactText.enabled = false;
        }
    }

    void ShowDialogue(int i) //show the selected dialogue option
    {
        dialogueText.text = Dialogues[i];
        dialogueText.enabled = true;
    }

    void HideDialogue() //hide the dialogue
    {
        dialogueText.text = "";
        dialogueText.enabled = false;
    }

    void LockMouse() //lock the cursor
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockMouse()//unlock the cursor
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideMenu() // hide the UI elements adn destroy the options (because the UI is reused by the other NPCs) 
    {
        DialogueBox.enabled = false;
        Crosshair.enabled = true;
        player.enabled = true;
        interactText.enabled = true;
        HideDialogue();
        ChoiceBox.enabled = false;
        foreach (Transform child in ChoiceBox.transform)
        {
            Destroy(child.gameObject);
        }
        LockMouse();
        inDialogue = false;
    }
}
