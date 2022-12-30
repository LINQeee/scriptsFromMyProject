using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IInteractable
    {
        void Interact();
        string GetDescription();
        bool isEnableUI();
        bool isAlwaysEnableOutline();
    }

