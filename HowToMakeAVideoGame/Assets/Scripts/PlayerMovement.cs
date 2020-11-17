using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Leap;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float jumpForce = 10f;
    public HandController controller; //Leap Motion Hand Controller.

    private Transform playerTransform;
    private Rigidbody playerRB;
    Frame currentFrame; //Captured frame from leap motion device.
    Frame previousFrame = null;
    private bool startMovement = false; //True after start gesture is completed.

    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    private bool flag1 = false;
    private bool flag2 = false;
    private bool flag3 = false;
    private bool flag4 = false;
    private bool flag5 = false;
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
        playerTransform = player.GetComponent<Transform>();
        controller.GetLeapController().EnableGesture(Gesture.GestureType.TYPE_SWIPE); //Enable swiping motion.
    }

    void Update()
    {
        this.currentFrame = controller.GetFrame(); //Get the current frame.
        GestureList gestures = this.currentFrame.Gestures(); //Get gestures from current frame.

        //Check if a hand exists.
        if (currentFrame.Hands[0].IsValid) {
            FindObjectOfType<GameManager>().unPauseUI();
            Hand hand = currentFrame.Hands[0]; //Get the hand object.
            float handPosition = normalizeValue(hand.PalmPosition.x); //Get the x position of the hand.

            //If game has started.
            if (startMovement == true)
            {

                if (!completeLevelUI.activeInHierarchy && !gameOverUI.activeInHierarchy)
                {
                    //Moving the player forward.
                    if(player.transform.position.z > 100.0f && flag1 == false ) {
                        flag1 = true;
                        speed++;
                    }
                    //Moving the player forward.
                    if (player.transform.position.z > 200.0f && flag2 == false)
                    {
                        flag2 = true;
                        speed++;
                    }
                    //Moving the player forward.
                    if (player.transform.position.z > 300.0f && flag3 == false)
                    {
                        flag3 = true;
                        speed++;
                    }
                    //Moving the player forward.
                    if (player.transform.position.z > 400.0f && flag4 == false)
                    {
                        flag4 = true;
                        speed++;
                    }
                    //Moving the player forward.
                    if (player.transform.position.z > 500.0f && flag5 == false)
                    {
                        flag5 = true;
                        speed++;
                    }
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }


                //Check each gesture caught in the frame.
                foreach (Gesture g in gestures)
                {
                    //If the gesture is a swiping gesture. 
                    if (g.Type == Gesture.GestureType.TYPE_SWIPE)
                    {
                        SwipeGesture swipeGesture = new SwipeGesture(g); //Construct a SwipGesture object.
                        Vector swipeDirection = swipeGesture.Direction; //Get the swiping direction.
                        bool isHorizontal = Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y); //Check if horizontal or vertical.
                                                                                                       //If the swiping motion is vertical and player is grounded - Jump action.
                        if (!isHorizontal && IsGrounded())
                        {
                            playerRB.AddForce(Vector3.up * jumpForce);
                            FindObjectOfType<AudioManager>().Play("Jump");
                        }
                    }
                }

                //Updates players left and right position based on hand position.
                transform.position = new Vector3(handPosition, playerTransform.position.y, playerTransform.position.z);
            }
            else
            {

                //Normalize it into a number between -6 and 6.
                //Check each gesture caught in the frame.
                foreach (Gesture g in gestures)
                {
                    //If the gesture is a swiping gesture and the palm position is approximately in the center. 
                    if (g.Type == Gesture.GestureType.TYPE_SWIPE && (hand.PalmPosition.x > 1 || hand.PalmPosition.x < 1))
                    {
                        //Enable movement.
                        startMovement = true;
                        //Delete starting text.
                        Text startingText = GameObject.Find("StartingText").GetComponent<Text>();
                        Destroy(startingText);
                        //Add delay.
                        StartCoroutine(WaitSeconds());
                    }
                }
            }
        } else {
            FindObjectOfType<GameManager>().PauseUI();
        }

        previousFrame = currentFrame; //Update the previous frame.
    }

    //Wait a few seconds before the game starts.
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(5);
    }

    float normalizeValue(float value) {
        float oldMin = -120f, oldMax = 120f; //Min max of leap motion.
        float newMin = -6f, newMax = 6f; //Min max of the player movement.
        //Adjust to new range.
        if (value > 120f){
            value = 120f;
        } else if (value < -120f) {
            value = -120f;
        }
        float newValue = Mathf.Lerp(newMin,newMax, Mathf.InverseLerp(oldMin, oldMax, value));
        return newValue;
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float raycastDistance = 1;
        //Raycast to to the floor objects only
        int mask = 1 << LayerMask.NameToLayer("Ground");

        //Raycast downwards
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, mask))
        {
            return true;
        }
        return false;
    }

}