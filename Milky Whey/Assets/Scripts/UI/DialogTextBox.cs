using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTextBox : MonoBehaviour {
    public TextAsset textFile;
    public float setDelayTimer;
    public bool startDialog = true;

    private Text dialogBox;
    private string[] fileLines;
    private int currentLine;
    private float delayTimer;
    private bool dialogCoroutineStarted = true;
    private Coroutine textTyping;

    private void Awake()
    {
        delayTimer = setDelayTimer;
        dialogBox = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        if (textFile != null)
        {
            fileLines = (textFile.text.Split('\n'));
        }
        dialogBox.text = "";

        dialogCoroutineStarted = true;
        textTyping = StartCoroutine(TextTyping());
	}
	
	// Update is called once per frame
	void Update () {
        if (startDialog)
        {
            if (!dialogCoroutineStarted && currentLine < fileLines.Length && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            {
                textTyping = StartCoroutine(TextTyping());
                dialogCoroutineStarted = true;
            } else if (dialogCoroutineStarted)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    StopCoroutine(textTyping);
                    dialogBox.text = fileLines[currentLine];
                    if (currentLine < fileLines.Length)
                    {
                        currentLine++;
                    }
                    dialogCoroutineStarted = false;
                }
            }
        }
        
	}

    IEnumerator TextTyping()
    {
        dialogBox.text = "";
        for (int i = 0; i < fileLines[currentLine].Length; i++)
        {
            dialogBox.text += fileLines[currentLine][i];
            yield return new WaitForSeconds(delayTimer);
        }
    }
}
