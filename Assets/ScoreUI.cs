using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public float distance = 0.0f;
    public bool is_Trig = false;
    private int score = 0;
    private int bamCount = 0;
    BamsongiGenerator script;
    GUIStyle style = new GUIStyle();
    public Text Text;

    // Start is called before the first frame update
    void Start()
    {
        style.normal.textColor = Color.black;
        style.fontSize = 25;
        Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        script = GameObject.Find("bamsongi_spawn").GetComponent<BamsongiGenerator>();
        bamCount = script.bamCount;

        if(bamCount >= 5 && is_Trig == true) {
            Text.enabled = true;
        }
        if(Input.GetKeyDown("r") && bamCount >= 5) {
            score = 0;
            bamCount = 0;
            script = GameObject.Find("bamsongi_spawn").GetComponent<BamsongiGenerator>();
            script.bamCount = bamCount;
            Text.enabled = false;
        }

        if (is_Trig == true) {
            CalScore();
            is_Trig = false;
        }
    }

    private void CalScore() {
        if (0 <= distance && distance < 0.4)
            score += 100;
        if (0.4 <= distance && distance < 0.8)
            score += 80;
        if (0.8 <= distance && distance < 1.2)
            score += 60;
        if (1.2 <= distance && distance < 1.6)
            score += 40;
        if (1.6 <= distance && distance < 2.0)
            score += 20;
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(41, Screen.height - 80, 128, 32), "Score : " + score.ToString(), style);
        GUI.Label(new Rect(41, Screen.height - 40, 128, 32), "Count : " + bamCount.ToString(), style);
    }
}
