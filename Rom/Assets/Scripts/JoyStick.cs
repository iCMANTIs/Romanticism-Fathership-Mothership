using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public struct JoyStickData 
{
    public Vector2 dir; 
    public float radius; 
    public JoyStickData(Vector2 d, float r)
    {
        this.dir = d;
        this.radius = r;
    }
    public Vector2 GetPos()
    {
        return dir * radius;
    }

}
public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler    
{
    public RectTransform bound; 
    public RectTransform center; 
    public float radius; 

    private JoyStickData HandleEventData(PointerEventData eventData)
    {
        Vector2 dir;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(bound, eventData.position, eventData.pressEventCamera, out dir);
        float r = dir.magnitude;
        dir = dir.normalized;
        r = Mathf.Clamp(r, 0, radius);

        return new JoyStickData(dir, r);
    }
    public void OnDrag(PointerEventData eventData)
    {
        var data = HandleEventData(eventData);
        center.localPosition = data.GetPos();
        onJoystickMove(data.dir, data.radius);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var data = HandleEventData(eventData);
        center.localPosition = data.GetPos();
        onJoystickDown(data.dir, data.radius);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var data = HandleEventData(eventData);
        center.localPosition = Vector2.zero; //抬起后回到0坐标
        onJoystickUp(data.dir, data.radius);
    }
    public virtual void onJoystickDown(Vector2 V, float R)
    {

    }
    public virtual void onJoystickUp(Vector2 V, float R)
    {

    }
    public virtual void onJoystickMove(Vector2 V, float R)
    {

    }
}

