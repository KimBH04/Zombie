using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFixed : MonoBehaviour
{
    private CanvasScaler cs;
    private void Awake()
    {
        cs = GetComponent<CanvasScaler>();
        CanvasFix();
    }
    public void CanvasFix()
    {
        float width = 720.0f;
        float height = 1280.0f;

        float dWidth = Screen.width;
        float dHeidth = Screen.height;

        if (dWidth / dHeidth > width / height)      //������� ����̽� ������ ������ �������� ū ���
        {
            cs.matchWidthOrHeight = 1;
        }
        else if (dWidth / dHeidth < width / height)     //������� ����̽� ������ ������ �������� ���� ���
        {
            cs.matchWidthOrHeight = 0;
        }
    }
}
