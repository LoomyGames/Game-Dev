using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    private Image Crosshair;
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
    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!inDialogue)
            {
                interactText.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Pressed E");
                if (!inDialogue)
                {
                    player.SetInteraction(gameObject);
                    for (int i = 0; i < Choices.Length; i++)
                    {
                        GameObject choiceInstance = Instantiate(ChoiceText, ChoiceBox.transform);
                        choiceInstance.GetComponent<Text>().text = Choices[i];
                    }
                    DialogueBox.enabled = true;
                    Crosshair.enabled = false;
                    player.enabled = false;
                    interactText.enabled = false;
                    ShowDialogue(0);
                    ChoiceBox.enabled = true;
                   
                    foreach (Transform child in ChoiceBox.transform)
                    {
                        child.GetComponent<Text>().enabled = true;
                    }
                    UnlockMouse();
                    inDialogue = true;
                }else
                {
                    HideMenu();
                }
                
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            interactText.enabled = false;
        }
    }

    void ShowDialogue(int i)
    {
        dialogueText.text = Dialogues[i];
        dialogueText.enabled = true;
    }

    void HideDialogue()
    {
        dialogueText.text = "";
        dialogueText.enabled = false;
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideMenu()
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
