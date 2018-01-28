using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTextBox : MonoBehaviour {
    public TextAsset textFile;
    public float setDelayTimer;

    private Text dialogBox;
    private string[] fileLines;
    private int currentLine;
    private float delayTimer;
    private bool dialogCoroutineStarted = true;
    private Coroutine textTyping;
    private GameManager gm;

    private void Awake()
    {
        delayTimer = setDelayTimer;
        dialogBox = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

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
        if (dialogCoroutineStarted)
        {
            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space) && Time.deltaTime != 0)
            {
                StopCoroutine(textTyping);
                dialogBox.text = fileLines[currentLine];
                dialogCoroutineStarted = false;
                currentLine++;
            }
        }

        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) && !dialogCoroutineStarted && currentLine < fileLines.Length && Time.deltaTime != 0)
        {
            textTyping = StartCoroutine(TextTyping());
            dialogCoroutineStarted = true;
        }
         

        if (currentLine >= fileLines.Length)
        {
            gm.startLevel();
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
