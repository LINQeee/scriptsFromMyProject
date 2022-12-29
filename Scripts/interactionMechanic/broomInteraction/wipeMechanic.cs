using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class wipeMechanic : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && other.CompareTag("Player") && !player.GetComponentInParent<Animation>().isPlaying && broomPickDrop.isBroomPickedUp && GetComponent<cleaningProgress>().cleaningPoints != 0)
        {
            player.GetComponentInParent<Animation>().PlayQueued("wipeBroom");
            GetComponent<cleaningProgress>().wipe();
        }
    }

}
