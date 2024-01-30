using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] public Sprite img;
    public TwinStickMovement script;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (script.ammo)
        {
            case 0:
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                break;
            case 1:
                b1.SetActive(true);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                break;
            case 2:
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                break;
            case 3:
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(true);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                break;
            case 4:
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(true);
                b4.SetActive(true);
                b5.SetActive(false);
                b6.SetActive(false);
                break;
            case 5:
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(true);
                b4.SetActive(true);
                b5.SetActive(true);
                b6.SetActive(false);
                break;
            case 6:
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(true);
                b4.SetActive(true);
                b5.SetActive(true);
                b6.SetActive(true);
                break;
        }
    }
}
