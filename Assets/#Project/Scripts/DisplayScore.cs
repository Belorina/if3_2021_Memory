using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TextMeshPro tmpText;

    // Start is called before the first frame update
    void Start()
    {
        float time = PlayerPrefs.GetFloat("timer", 0f);
        tmpText.text = "Time:\n" + time.ToString("N2");     // N2 = je veux deux chifre apres la virgule
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
