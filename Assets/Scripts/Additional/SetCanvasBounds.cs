using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SetCanvasBounds : MonoBehaviour
{
    RectTransform _panel;
    Rect _lastSafeArea = new Rect(0, 0, 0, 0);


    private void Awake()
    {
        _panel = GetComponent<RectTransform>();
        var safeArea = Screen.safeArea;
        if (safeArea != _lastSafeArea)
        {
            ApplySafeArea(safeArea);
        }
    }


    private void ApplySafeArea(Rect area)
    {
        var anchorMin = area.position;
        var anchorMax = area.position + area.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        _panel.anchorMin = anchorMin;
        _panel.anchorMax = anchorMax;

        _lastSafeArea = area;
    }


}