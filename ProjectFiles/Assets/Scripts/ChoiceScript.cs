using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{

    private Button button;
    Player player;
    GameObject NPC;//reference to the NPC the player is interacting with
    private Text thisText;
    private Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //initialize all of the variables
        button.onClick.AddListener(SendSignal);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        thisText = GetComponent<Text>();
        dialogueText = GameObject.FindWithTag("DialogueText").GetComponent<Text>();

    }

    void SendSignal()
    {
        NPC = player.GetInteraction();//whenever we need to send a signal we need to get the proper NPC we are talking to
        if(NPC!= null)//this is just for debugging
        {
            Debug.Log("Interacting with" + NPC.name);
        }else
        {
            Debug.Log("No Player");
        }

        switch (thisText.text)//if we press one of those buttons:
        {
            case "Talk": // if we talk, select a random line the NPC has and display it on the screen
                int dialogueSelect = Random.Range(1, NPC.GetComponent<NPCInteract>().Dialogues.Length);
                dialogueText.text = NPC.GetComponent<NPCInteract>().Dialogues[dialogueSelect];
                break;
            case "Leave"://if we leave then call the Hide Menu method that hides the meny and re-enables the player
                NPC.GetComponent<NPCInteract>().HideMenu();
                break;
            default://otherwise output an error for debugging
                Debug.Log("Option not found");
                break;
        }
        
    }
}
