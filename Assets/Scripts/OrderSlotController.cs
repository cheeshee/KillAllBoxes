using UnityEngine;
using UnityEngine.UI;

public class OrderSlotController : MonoBehaviour
{
    public Image red;
    public Image white;
    public Image blue;
    public Image bubble;
    public Image selfImage;
    public Sprite normal;
    public Sprite fragile;
    public Sprite heavy;
    BoxController box;

    public void AddOrder(BoxController newOrder)
    {
        box = newOrder;
        //Debug.Log(box.attributes["fragile"]);

        if (box.isFragile == true)
        {
            selfImage.sprite = fragile;
        } else if (box.isHeavy == true)
        {
            selfImage.sprite = heavy;
        } else
        {
            selfImage.sprite = normal;
        }

        selfImage.color = new Color(selfImage.color.r, selfImage.color.g, selfImage.color.b, 1f);

        if (box.attributes["bubbleWrap"] == true)
        {
            bubble.gameObject.SetActive(true);
        }

        if (box.attributes["blueSticker"] == true)
        {
            // Debug.Log("wrap");
            blue.gameObject.SetActive(true);
        }
        if (box.attributes["redSticker"] == true)
        {
            red.gameObject.SetActive(true);
        }
        if (box.attributes["whiteSticker"] == true)
        {
            white.gameObject.SetActive(true);
        }
    }

    public void completeOrder()
    {

    }
}
