using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.SceneManagement;

public class ButtonDetector : MonoBehaviour
{

    Frame currentFrame; //Captured frame from leap motion device.
    public HandController controller; //Leap Motion Hand Controller.
    Animator anim;
    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        controller.GetLeapController().EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
        controller.GetLeapController().EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        anim = startButton.GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentFrame = controller.GetFrame(); //Get the current frame.
        GestureList gestures = this.currentFrame.Gestures(); //Get gestures from current frame.
        Finger finger = currentFrame.Hands[0].Fingers[1]; //Get the index finger.

        Vector3 position2 = (finger.TipPosition).ToUnityScaled(false);
        Vector3 position = controller.transform.TransformPoint(position2);

        Vector3 fwd = (Vector3.forward);

        foreach (Gesture g in gestures)
        {
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            RaycastHit hit;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(position, fwd, out hit, Mathf.Infinity, layerMask) && (g.Type == Gesture.GestureType.TYPE_KEY_TAP || g.Type == Gesture.GestureType.TYPE_SCREEN_TAP) && hit.transform.tag == "Start")
            {
               
                Debug.DrawRay(position, fwd * hit.distance, Color.yellow);
                FindObjectOfType<TutAudioManager>().Play("ButtonPress");
                anim.enabled = true;
                SceneManager.LoadScene("Level1Auto");
                Debug.Log("Did Hit");
            }
            if(Physics.Raycast(position, fwd, out hit, Mathf.Infinity, layerMask) && (g.Type == Gesture.GestureType.TYPE_KEY_TAP || g.Type == Gesture.GestureType.TYPE_SCREEN_TAP) && hit.transform.tag == "Tutorial")
            {
                Debug.DrawRay(position, fwd * hit.distance, Color.yellow);
                FindObjectOfType<TutAudioManager>().Play("ButtonPress");
                SceneManager.LoadScene("IntroducePlayer");
            }
        }
    }

}
