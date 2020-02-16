using UnityEngine;
using UnityEngine.UI;

public class OrderSlotController : MonoBehaviour
{
    public Image wrapping;
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

        if (box.attributes["fragile"] == true)
        {
            selfImage.sprite = fragile;
        } else if (box.attributes["heavy"] == true)
        {
            selfImage.sprite = heavy;
        } else
        {
            selfImage.sprite = normal;
        }

        selfImage.color = new Color(selfImage.color.r, selfImage.color.g, selfImage.color.b, 1f);

        if (box.attributes["bubble"] == true)
        {
            Debug.Log("bubbe");
            bubble.gameObject.SetActive(true);
            //GetComponentInParent<>("icon1")
        }

        if (box.attributes["wrapping"] == true)
        {
            Debug.Log("wrap");
            wrapping.gameObject.SetActive(true);
        }
    }

    public void completeOrder()
    {

    }
}
