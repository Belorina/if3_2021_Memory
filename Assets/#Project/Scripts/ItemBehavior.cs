using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public int id = -1;
    public LevelManager manager;

    public bool mouseOver = false;      // devrais etre private a la base

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();        // devoir un animator comme component sur object
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
        mouseOver = true;
        animator.SetBool("MouseOver", true);            // seule moyen de communiquer avec l animator 
    }
    void OnMouseExit()
    {
        mouseOver = false;
        animator.SetBool("MouseOver", false);            // seule moyen de communiquer avec l animator 
    }

    public void HasBeenSelected(bool selected)
    {
        animator.SetBool("ItemSelected", selected);
    }

    public void HasBeenMatched()        // pas de parametre car il est toujours true 
    {
        animator.SetBool("ItemMatch", true);
    }

}
