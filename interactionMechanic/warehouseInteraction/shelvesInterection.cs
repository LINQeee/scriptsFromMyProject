using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelvesInterection : warehouseEventData, IInteractable
{   
    [SerializeField] private GameObject player;
    
    public string GetDescription(){
        if(isBoxInHand)
        {
        string colorOfBox = null;
        string colorOfShelf = null;
        switch(currentBox.tag){
        case "blackBox": colorOfBox = "black";
            break;
        case "redBox": colorOfBox = "red";
            break;
        case "greenBox": colorOfBox = "green";
            break;
        case "blueBox": colorOfBox = "blue";
            break;
        case "orangeBox": colorOfBox = "orange";
            break;
        case "pinkBox": colorOfBox = "pink";
            break;
        case "yellowBox": colorOfBox = "yellow";
            break;
        }
        //checking color of box
        switch(transform.GetChild(0).tag){
        case "blackBox": colorOfShelf = "black";
            break;
        case "redBox": colorOfShelf = "red";
            break;
        case "greenBox": colorOfShelf = "green";
            break;
        case "blueBox": colorOfShelf = "blue";
            break;
        case "orangeBox": colorOfShelf = "orange";
            break;
        case "pinkBox": colorOfShelf = "pink";
            break;
        case "yellowBox": colorOfShelf = "yellow";
            break;
        }
        //checking color of shelf
        if(currentBox.tag == transform.GetChild(0).tag) return "drop the box";
        else return $"Your box is {colorOfBox}, not {colorOfShelf}!";
        }
        return null;
    }

    public void Interact(){
        if(currentBox.tag == transform.GetChild(0).tag){
            player.GetComponent<Animation>().PlayQueued("throwBox");
            Invoke("dropBox", 1);
        }
    }

    public bool isEnableUI(){
        return isBoxInHand;
    }

    private void dropBox(){ isBoxInHand  = false; playerInteraction.isSomethingInHands = false;}

}
