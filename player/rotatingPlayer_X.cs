using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingPlayer_X : MonoBehaviour
{
    [SerializeField] private float horizontalSens = 3;
    void Update()
    {
        if (playerMovement.isMovementBlocked) return;
        transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalSens, 0);
    }
}
