using static System.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindInfo : MonoBehaviour
{
    public float wind_speed_x = 0.0f;
    public float wind_speed_y = 0.0f;
    public bool is_Trig = false;
    BamsongiGenerator script;
    GUIStyle style = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        style.normal.textColor = Color.black;
        style.fontSize = 25;

        CollWindChange();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("a"+is_Trig);
        if (is_Trig == true) {
            CollWindChange();
            is_Trig = false;
        }
    }

    public void CollWindChange()
    {
        wind_speed_x = (float)Round(Random.Range(-10.0f, 10.0f), 3);
        wind_speed_y = (float)Round(Random.Range(-5.0f, 5.0f), 3);
    }

    public void OnGUI()
    {
        script = GameObject.Find("bamsongi_spawn").GetComponent<BamsongiGenerator>();
        int bamCount = script.bamCount;

        if(bamCount < 5) {
            if (wind_speed_x > 0)
                GUI.Label(new Rect(Screen.width - 265, Screen.height - 130, 128, 32), "Wind Speed X-axis : → \n" + wind_speed_x.ToString(), style);
            if (wind_speed_x < 0)
                GUI.Label(new Rect(Screen.width - 265, Screen.height - 130, 128, 32), "Wind Speed X-axis : ← \n" + wind_speed_x.ToString(), style);

            if (wind_speed_y > 0)
                GUI.Label(new Rect(Screen.width - 265, Screen.height - 60, 128, 32), "Wind Speed Y-axis : ↑ \n" + wind_speed_y.ToString(), style);
            if (wind_speed_y < 0)
                GUI.Label(new Rect(Screen.width - 265, Screen.height - 60, 128, 32), "Wind Speed Y-axis : ↓ \n" + wind_speed_y.ToString(), style);
        }
    }
}
