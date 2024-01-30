using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
