using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleanim : MonoBehaviour
{
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("PoleMain");
    }

    void Update()
    {
        
        if(Input.GetMouseButton(0)){
           animator.Play("PoleRight");
           animator.Update(0f);
        }
        else if(Input.GetMouseButtonUp(0)){
            animator.Play("PoleMain");
        }
        if(Input.GetMouseButton(1)){
            animator.Play("PoleAnimation");
            animator.Update(0f);
        }
        else if(Input.GetMouseButtonUp(1)){
            animator.Play("PoleMain");
        }
    }
}
