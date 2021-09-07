using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverDetection : MonoBehaviour
{
    private Animator animator;

    public bool hover = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hover == true)
        {
            OnMouseOver();
        }
        else
        {
            OnMouseExit();
        }
    }


    void OnMouseOver()
    {
        hover = true;
        animator.SetBool("MouseOver", true);

    }

    void OnMouseExit()
    {
        hover = false;
        animator.SetBool("MouseOver", false);
    }
}
