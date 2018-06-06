using UnityEngine;

public class SampleGui : MonoBehaviour
{
    string displayText;

    void Update()
    {
        displayText = NeulogManager.Instance.BreathReading.ToString();
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 6 / 100;
        style.normal.textColor = new Color(0, 0, 0, 1.0f);
        GUI.Label(rect, displayText, style);
    }
}
