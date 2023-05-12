using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFixed : MonoBehaviour
{
    private void Awake()
    {
        ScreenFix();
    }

    public void ScreenFix()
    {
        float width = 720;
        float height = 1280;

        float dWidth = Screen.width;
        float dHeight = Screen.height;

        Screen.SetResolution((int)width, (int)(dHeight / dWidth * width), false);
    }
}
