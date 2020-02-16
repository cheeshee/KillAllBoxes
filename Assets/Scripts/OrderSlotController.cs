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
        if (newOrder == null)
        {
            selfImage.color = new Color(selfImage.color.r, selfImage.color.g, selfImage.color.b, 0f);
            selfImage.sprite = normal;
            blue.gameObject.SetActive(false);
            red.gameObject.SetActive(false);
            white.gameObject.SetActive(false);
            bubble.gameObject.SetActive(false);
            return;
        }
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
        } else
        {
            bubble.gameObject.SetActive(false);
        }

        if (box.attributes["stickerBlue"] == true)
        {
            // Debug.Log("wrap");
            blue.gameObject.SetActive(true);
        }
        else
        {
            blue.gameObject.SetActive(false);
        }
        if (box.attributes["stickerRed"] == true)
        {
            red.gameObject.SetActive(true);
        }
        else
        {
            red.gameObject.SetActive(false);
        }
        if (box.attributes["stickerWhite"] == true)
        {
            white.gameObject.SetActive(true);
        }
        else
        {
            white.gameObject.SetActive(false);
        }
    }

    public void completeOrder()
    {

    }
}
