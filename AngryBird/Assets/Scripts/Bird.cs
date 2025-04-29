using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BirdState
{
    Waiting,
    Beforeshoot,
    AfterShoot
}
public class Bird : MonoBehaviour
{
    public BirdState state = BirdState.Beforeshoot;
    // Start is called before the first frame update
    private bool isMouseDown = false;

    public float maxDistance = 3.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {   
            
            case BirdState.Waiting:
                break;
            case BirdState.Beforeshoot:
                MoveControl();
                break;
            case BirdState.AfterShoot:
                break;
            default:
                break;
        }
  
    }
    //OnMouseDown和OnMouseUp

    private void OnMouseDown()
    {
        if (state == BirdState.Beforeshoot)
        {
            isMouseDown = true;
            Slingshot.Instance.StartDraw(transform);
        }
    }

    private void OnMouseUp()
    {
        if (state == BirdState.Beforeshoot)
        {
            isMouseDown = false;
            Slingshot.Instance.EndDraw();
        }
    }

    private void MoveControl()
    {
        if (isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 centerPosition = Slingshot.Instance.getCenterPositon();
        Vector3 mp= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = mp - centerPosition;
        mp.z = 0;

        float distance = mouseDir.magnitude;//鼠标点与中心点的距离

        if (distance > maxDistance)
        {
            mp =mouseDir.normalized * maxDistance + centerPosition;//将鼠标位置限定在范围内
        }
        return mp;
    }
}
