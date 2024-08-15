using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBehavior : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private LayerMask interactableFilter;
    private IInteractable selectedInteraction;
    public void Interact(PlayerController playerController)
    {
        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, interactableFilter))
        {
            if (selectedInteraction == null)
            {
                selectedInteraction = hit.collider.gameObject.GetComponent<IInteractable>();
                selectedInteraction.OnHoverEnter();
            }

                selectedInteraction.Interact(playerController);

        }
        else if (selectedInteraction != null)
        {
            selectedInteraction.OnHoverExit();
            selectedInteraction = null;
        }

    }
}
