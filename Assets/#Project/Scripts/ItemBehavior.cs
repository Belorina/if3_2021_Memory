using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public int id = -1;
    public LevelManager manager;

    public bool mouseOver = false;      // devrais etre private a la base

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && mouseOver)        // click gauche = 0 // quand la souris remonte pour avoir qu une fois (a cause de update  sans le UP il y a plusieur message )
        {         
            manager.RevealMaterial(id);
        }

    }

    void OnMouseOver()      // detection du souris sur object
    {
        transform.localScale = new Vector3(1, 2, 1);    // double l'ax des y 
        mouseOver = true;
    }
    void OnMouseExit()
    {
        transform.localScale = Vector3.one;     // = new Vector3(1, 1, 1)
        mouseOver = false;
    }

}
