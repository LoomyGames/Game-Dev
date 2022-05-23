using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetText : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void ResetWriting() //method that calls the reset function
    {
        StartCoroutine(showTime());
    }

    IEnumerator showTime()
    {
        yield return new WaitForSeconds(4); // after showing the text for 4 seconds, resets the text back to empty, therefore hiding it
        text.text = "";
    }
}
