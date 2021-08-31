using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public int id = -1;
    public LevelManager manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()      // detection du souris sur object
    {
        transform.localScale = new Vector3(1, 2, 1);    // double l'ax des y 
    }
    void OnMouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

}
