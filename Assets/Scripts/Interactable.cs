using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // abstract - we can use this for many object type, like button, door etc.

    public string promptMesasge;


    //called by player
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
