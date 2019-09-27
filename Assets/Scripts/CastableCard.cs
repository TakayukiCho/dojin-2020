using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Imageコンポーネントを必要とする
[RequireComponent(typeof(Image))]

public class CastableCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Image image;
    private Vector2 prevPos;
    private CardImpl cardImpl;
    public GameController gameController;


    void Start()
    {
        this.gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        this.cardImpl = new LightningBolt();
        this.image = this.GetComponent<Image>();
        var sprite = Resources.Load<Sprite>(this.cardImpl.ImagePath());
        this.image.sprite = sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        prevPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        foreach (var hit in raycastResults)
        {
            if (hit.gameObject.CompareTag("CastArea"))
            {
                gameController.CastCard(this.cardImpl);
                Destroy(this.image);
                Destroy(this);
            }
            else
            {
                transform.position = prevPos;
            }
        }
    }
}