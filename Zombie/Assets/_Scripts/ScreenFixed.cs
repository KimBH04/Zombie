using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFixed : MonoBehaviour
{
    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        Rect rect = cam.rect;

        float scaleHeghit = (float)Screen.width / Screen.height / (9f / 16f);
        float scaleWidth = 1f / scaleHeghit;

        if (scaleHeghit < 1f)
        {
            rect.height = scaleHeghit;
            rect.y = (1f - scaleHeghit) / 2f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }

        cam.rect = rect;
    }
}
