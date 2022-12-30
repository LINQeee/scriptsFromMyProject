using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EPOOutline;

public class playerInteraction : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private float interactionDistance = 4;
    [SerializeField] private LayerMask layerMask;
    GameObject lastObject;
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TextMeshProUGUI interactionText;
    public static GameObject lastSelectedObject;
    public static bool isSomethingInHands = false;
    private GameObject lastHittedInteractionObject;

    void Update()
    {
        InteractionRay();
    }
    private void InteractionRay()
    {//creating ray from camera view
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool isEnableUI = false;
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {//if ray hitted other collider
        
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("interaction"))
            {//if collider's layer is interaction
            if(lastHittedInteractionObject != null && lastHittedInteractionObject != hit.collider.gameObject && !lastHittedInteractionObject.GetComponent<IInteractable>().isAlwaysEnableOutline())
            lastHittedInteractionObject.GetComponent<Outlinable>().enabled = false;

            lastHittedInteractionObject = hit.collider.gameObject;

            if(!lastHittedInteractionObject.GetComponent<IInteractable>().isAlwaysEnableOutline()) lastHittedInteractionObject.GetComponent<Outlinable>().enabled = true;
            
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    isEnableUI = interactable.isEnableUI();
                    interactionText.text = interactable.GetDescription();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.Interact();
                    }
                }
            }else if(lastHittedInteractionObject != null && !lastHittedInteractionObject.GetComponent<IInteractable>().isAlwaysEnableOutline())lastHittedInteractionObject.GetComponent<Outlinable>().enabled = false;
        }else if(lastHittedInteractionObject != null && !lastHittedInteractionObject.GetComponent<IInteractable>().isAlwaysEnableOutline())lastHittedInteractionObject.GetComponent<Outlinable>().enabled = false;
        interactionUI.SetActive(isEnableUI);

    }

}
