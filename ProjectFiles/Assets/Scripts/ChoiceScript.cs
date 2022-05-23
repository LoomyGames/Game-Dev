using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{

    private Button button;
    Player player;
    GameObject NPC;
    private Text thisText;
    private Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SendSignal);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        thisText = GetComponent<Text>();
        dialogueText = GameObject.FindWithTag("DialogueText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendSignal()
    {
        NPC = player.GetInteraction();
        if(NPC!= null)
        {
            Debug.Log("Interacting with" + NPC.name);
        }else
        {
            Debug.Log("No Player");
        }

        switch (thisText.text)
        {
            case "Talk":
                int dialogueSelect = Random.Range(1, NPC.GetComponent<NPCInteract>().Dialogues.Length);
                dialogueText.text = NPC.GetComponent<NPCInteract>().Dialogues[dialogueSelect];
                break;
            case "Leave":
                NPC.GetComponent<NPCInteract>().HideMenu();
                break;
            default:
                Debug.Log("Option not found");
                break;
        }
        
    }
}
