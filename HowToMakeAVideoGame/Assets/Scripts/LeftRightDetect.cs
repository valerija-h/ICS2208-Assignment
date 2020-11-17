using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class LeftRightDetect : MonoBehaviour
{
    public HandController controller; //Leap Motion Hand Controller.
    Frame currentFrame; //Captured frame from leap motion device.

    // Start is called before the first frame update
    void Start()
    {
        controller.GetLeapController().EnableGesture(Gesture.GestureType.TYPE_SWIPE); //Enable swiping motion.
    }

    // Update is called once per frame
    void Update()
    {
        this.currentFrame = controller.GetFrame(); //Get the current frame.
        GestureList gestures = this.currentFrame.Gestures(); //Get gestures from current frame.

        //Check each gesture caught in the frame.
        foreach (Gesture g in gestures)
        {
            //If the gesture is a swiping gesture. 
            if (g.Type == Gesture.GestureType.TYPE_SWIPE)
            {
                SwipeGesture swipeGesture = new SwipeGesture(g); //Construct a SwipGesture object.
                Vector swipeDirection = swipeGesture.Direction; //Get the swiping direction.
                bool isHorizontal = Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y); //Check if horizontal or vertical.
                //Swipe Horizotal.
                if (isHorizontal)
                {
                    if (swipeDirection.x < 0)
                    {
                        FindObjectOfType<SceneChange>().FadeToScene(); 

                    }
                    /*else if (swipeDirection.x > 0)
                    {
                        //Right Swipe.
                    }*/
                }
            }
        }
    }
}
