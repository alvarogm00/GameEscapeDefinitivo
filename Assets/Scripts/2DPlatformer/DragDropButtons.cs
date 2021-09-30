using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropButtons : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] Platform platform;

    Animator animator;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Player2DMovement player2DMovement;
    Ray ray;

    public bool isAnchored;
    
    public enum ButtonType
    {
        Left, Right, Jump
    }
    
    public ButtonType buttonType;

    public int buttonID;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        player2DMovement = FindObjectOfType<Player2DMovement>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (buttonType == ButtonType.Jump)
        {
            buttonID = 1;
        }
        else if (buttonType == ButtonType.Left)
        {
            buttonID = 2;
        }
        else
        {
            buttonID = 3;
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        isAnchored = false;

        platform.ActivatePlatform(false);

        if (buttonType == ButtonType.Left)
        {
            player2DMovement.checkLeftButton(false);
        }
        else if (buttonType == ButtonType.Right)
        {
            player2DMovement.checkRightButton(false);
        }
        else if (buttonType == ButtonType.Jump)
        {
            player2DMovement.checkJumpButton(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        CreatePlatform();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    void CreatePlatform()
    {
        if (!isAnchored)
        {
            RaycastHit infoImpacto;
            ray = Camera.main.ScreenPointToRay(canvasGroup.transform.position);

            if (Physics.Raycast(ray, out infoImpacto))
            {
                if (infoImpacto.transform.GetComponent<PlatformsPositionCollider>())
                {
                    platform.transform.position = infoImpacto.point;
                    //Vector3 finalPlatformPosition = platform.transform.position;
                    //finalPlatformPosition.x = player2DMovement.transform.position.x;
                    //platform.transform.position = finalPlatformPosition;

                    platform.ActivatePlatform(true);
                }
                else
                {
                    animator.SetTrigger("CantPutDown");
                }               
            }
        }

    }

    public void ActivateUI(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray.origin, ray.direction * 1000f);
    }

}
