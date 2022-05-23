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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetWriting()
    {
        StartCoroutine(showTime());
    }

    IEnumerator showTime()
    {
        yield return new WaitForSeconds(4);
        text.text = "";
    }
}
