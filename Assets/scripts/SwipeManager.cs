using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
       private bool tap, swipeLeft , swipeRight, swipeUp, swipeDown;
       private bool isDragging = false;
       private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeDown = swipeUp =    false;

        #region StandAlone Inputs
            if (Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDragging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                isDragging = false;
                Reset();
            }

        #endregion

        #region Mobile Inputs   
             if (Input.touches.Length >0)
             {
                 if (Input.touches[0].phase == TouchPhase.Began)
                 {
                     isDragging = true;
                     tap = true; 
                     startTouch = Input.touches[0].position;
                 }
                 else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled )
                 {
                     isDragging = false;
                     Reset();
                 }
             }


        #endregion
        
        //calculating the distance of swipe

        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length> 0 )
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButtonDown(0))    
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            
        }

        // IF we cross the deadzone this been start working
        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y ;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if(x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;    
            }
            else
            {
                //Up or down
                if(y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();

        }
   
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get  { return swipeDelta; } }
    public bool SwipeLeft { get  { return swipeLeft ; } }
    public bool SwipeRight { get  { return swipeRight; } }
    public bool SwipeUp { get  { return swipeUp; } }
    public bool SwipeDown { get  { return swipeDown; } }

}
