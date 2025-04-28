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
    public bool isMouseDown = false;
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
    //OnMouseDownºÍOnMouseUp

    private void OnMouseDown()
    {
        if (state == BirdState.Beforeshoot)
        {
            isMouseDown = true;
        }
    }

    private void OnMouseUp()
    {
        if (state == BirdState.Beforeshoot)
        {
            isMouseDown = false;
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
        Vector3 mp= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        return mp;
    }
}
