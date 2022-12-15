using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerInteraction : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private float interactionDistance = 4;
    [SerializeField] private LayerMask layerMask;
    GameObject lastObject;
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TextMeshProUGUI interactionText;
    public static GameObject lastSelectedObject;


    void Update()
    {
        InteractionRay();
    }
    private void InteractionRay()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool isEnableUI = false;
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("interaction"))
            {
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
            }
        }
        interactionUI.SetActive(isEnableUI);

    }

}
