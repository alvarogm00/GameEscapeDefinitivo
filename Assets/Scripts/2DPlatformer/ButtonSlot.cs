using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] Platform platform;

    public enum ButtonStored
    {
        Left, Right, Jump
    }

    public ButtonStored buttonStored;

    int buttonID;

    Player2DMovement player2DMovement;
    void Start()
    {
        player2DMovement = FindObjectOfType<Player2DMovement>();

        if(buttonStored == ButtonStored.Jump)
        {
            buttonID = 1;
        }
        else if(buttonStored == ButtonStored.Left)
        {
            buttonID = 2;
        }
        else
        {
            buttonID = 3;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (buttonID == eventData.pointerDrag.GetComponent<DragDropButtons>().buttonID)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DragDropButtons>().isAnchored = true;
                eventData.pointerDrag.GetComponent<DragDropButtons>().ActivateUI(true);

                if (buttonStored == ButtonStored.Left)
                {
                    player2DMovement.checkLeftButton(true);
                }
                else if (buttonStored == ButtonStored.Right)
                {
                    player2DMovement.checkRightButton(true);
                }
                else if (buttonStored == ButtonStored.Jump)
                {
                    player2DMovement.checkJumpButton(true);
                }
            }
        }
    }
}
