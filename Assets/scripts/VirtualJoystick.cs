using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
public class VirtualJoystick : MonoBehaviour , IDragHandler, IPointerUpHandler , IPointerDownHandler
{
    private Image BgImg;
    private Image JoystickImg;
    public Vector3 InputDirection;
    

    private void Start()
    {
        BgImg = GetComponent<Image>();
        JoystickImg = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;
    }
    public void OnDrag(PointerEventData PED)
    {
        Vector2 position = Vector2.zero;

        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (BgImg.rectTransform,
                PED.position,
                PED.pressEventCamera,
                out position);

        position.x = (position.x / BgImg.rectTransform.sizeDelta.x);
        position.y = (position.y / BgImg.rectTransform.sizeDelta.y);

        float x = (BgImg.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (BgImg.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputDirection = new Vector3(x, y, 0);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        JoystickImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (BgImg.rectTransform.sizeDelta.x / 3)
                                                               , InputDirection.y * (BgImg.rectTransform.sizeDelta.y) / 3);


    }
    public void OnPointerDown(PointerEventData PED)
    {
        OnDrag(PED);
    } 

    public void OnPointerUp(PointerEventData PED)
    {
        InputDirection = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

}
