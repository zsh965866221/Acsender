using System;
using UnityEngine;
using System.Collections;
using UnitySampleAssets.Characters.ThirdPerson;
using UnitySampleAssets.CrossPlatformInput;

public class MyUserControll : MonoBehaviour {

    public bool walkByDefault = false; // toggle for walking state

    public bool lookInCameraDirection = false;// should the character be looking in the same direction that the camera is facing

    private Vector3 lookPos; // The position that the character should be looking towards
    private ThirdPersonCharacter character; // A reference to the ThirdPersonCharacter on the object
    private Transform cam; // A reference to the main camera in the scenes transform
    private Vector3 camForward; // The current forward direction of the camera

    private Vector3 move;
    private bool jump;// the world-relative desired move direction, calculated from the camForward and user input.

    private MyUserPostionControll myUserPostionControll;

    //joystick
    private float x;
    private float y;
    private bool movejoystick = false;
    private bool jumpjoystick = false;
    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += On_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
        EasyButton.On_ButtonPress += On_ButtonPress;
        EasyButton.On_ButtonUp += On_ButtonUp;
    }

    void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= On_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
        EasyButton.On_ButtonPress -= On_ButtonPress;
        EasyButton.On_ButtonUp -= On_ButtonUp;
    }

    void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= On_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
        EasyButton.On_ButtonPress -= On_ButtonPress;
        EasyButton.On_ButtonUp -= On_ButtonUp;
    }


    void On_JoystickMoveEnd(MovingJoystick move)
    {
        if (move.joystickName == "MoveJoystick")
        {
            movejoystick = false;
            //            GetComponent<Animation>().CrossFade("idle");
        }
    }
    void On_JoystickMove(MovingJoystick move)
    {
        if (move.joystickName == "MoveJoystick")
        {
            movejoystick = true;
            x = move.joystickAxis.x;
            y = move.joystickAxis.y;
            //            print(move.joystickAxis.x);
            //            //
            //            if (Mathf.Abs(move.joystickAxis.y) > 0 && Mathf.Abs(move.joystickAxis.y) < 0.5)
            //            {
            //                GetComponent<Animation>().CrossFade("walk");
            //
            //            }
            //            else if (Mathf.Abs(move.joystickAxis.y) >= 0.5)
            //            {
            //                GetComponent<Animation>().CrossFade("run");
            //            }
        }
    }

    void On_JoystickTouchStart(MovingJoystick move)
    {
        //        print(move.joystickName);
    }
    void On_ButtonPress(string buttonName)
    {
        if (buttonName == "Jump")
        {
            jump = true;
        }
    }

    void On_ButtonUp(string buttonName)
    {
        if (buttonName == "Exit")
        {

        }
    }
    // Use this for initialization
    private void Start()
    {
        myUserPostionControll = GetComponent<MyUserPostionControll>();

        // get the transform of the main camera
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        character = GetComponent<ThirdPersonCharacter>();
    }

    void Update()
    {
        if (!jump&&!myUserPostionControll.turn)
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
        //根据Camera调整固定轴
        
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        // read inputs
        bool crouch = false;
        float h, v;
        if (myUserPostionControll.turn)
        {
            h = 0;
            v = 0;
        }
        else
        {
            if (movejoystick)
            {
                h = x;
                v = y;
            }
            else
            {
                // read inputs
                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
            }
        }

        
//        float v = CrossPlatformInputManager.GetAxis("Vertical");
//        crouch = Input.GetKey(KeyCode.C);

        // calculate move direction to pass to character
        if (cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
//            move = v * camForward + h * cam.right;
            move = h*cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
//            move = v * Vector3.forward + h * Vector3.right;
            move = h*Vector3.right;
        }

        if (move.magnitude > 1) move.Normalize();

#if !MOBILE_INPUT
        // On non-mobile builds, walk/run speed is modified by a key press.
        bool walkToggle = Input.GetKey(KeyCode.LeftShift);
        // We select appropriate speed based on whether we're walking by default, and whether the walk/run toggle button is pressed:
        float walkMultiplier = (walkByDefault ? walkToggle ? 1 : 0.5f : walkToggle ? 0.5f : 1);
        move *= walkMultiplier;
#endif

        // calculate the head look target position
        lookPos = lookInCameraDirection && cam != null
                      ? transform.position + cam.forward * 100
                      : transform.position + transform.forward * 100;

        // pass all parameters to the character control script
        character.Move(move, crouch, jump, lookPos);
        jump = false;
    }
}
