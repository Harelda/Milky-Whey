using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportDialog : MonoBehaviour
{
    public TextAsset textFile;
    public float setTextDelayTimer;
    public string[] textLines;

    private Text box;
    private float textDelayTimer;
    private int currentLine = 0;

    private void Awake()
    {
        textDelayTimer = setTextDelayTimer;
    }

    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }
        else{ Debug.Log('9'); }

        box = transform.GetComponent<Text>();

        Debug.Log(textFile);
    }

    public void Update()
    {
        if (textDelayTimer > 0)
        {
            textDelayTimer -= Time.deltaTime;
        } else if (textDelayTimer <= 0 && currentLine < textLines.Length)
        {
            box.text = textLines[currentLine];
            currentLine++;
            textDelayTimer = setTextDelayTimer;
        }
    }
}
