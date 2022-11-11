using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateButton : Interactable
{
    Animator animator;
    private string startPrompt;
    void Start()
    {
        animator = GetComponent<Animator>();
        startPrompt = promptMesasge;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            promptMesasge = startPrompt;
        }
        else
        {
            promptMesasge = "Animating";
        }
    }
    protected override void Interact()
    {
        animator.Play("Button_Press");
    }
}
