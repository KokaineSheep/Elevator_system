using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject elevator;
    private bool elevatorUp;

    //interaction design: destroy obj, change color, call animation etc.
    protected override void Interact()
    {
        Debug.Log("Its interactable");

        elevatorUp = !elevatorUp;
        elevator.GetComponent<Animator>().SetBool("isLevitation", elevatorUp);
    }
}
