using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 input;
    public float speed;

    public bool leftB;
    public bool rightB;
    public Vector2 realSpeed;
    public float maxSpeed;
    public float plusSpeed;

    public bool JoyOn;

    public Joystick joystick;
    public GameObject JoystickGameObject;
    public GameObject NormalController;
    void FixedUpdate()
    {
        transform.Translate(input * Time.deltaTime * speed);
        realSpeed.x = input.x * Time.deltaTime * speed;
    }

    void Update()
    {
        if (JoyOn)
        {
            JoystickGameObject.SetActive(true);
            NormalController.SetActive(false);
            input = new Vector2(joystick.Horizontal, 0);
        }
        else
        {
            JoystickGameObject.SetActive(false);
            NormalController.SetActive(true);
            if (leftB)
            {
                if (realSpeed.x > -maxSpeed)
                {
                    input.x -= plusSpeed;
                }
            }
            else if (rightB)
            {
                if (realSpeed.x < maxSpeed)
                {
                    input.x += plusSpeed;
                }
            }
            else if (!leftB && !rightB)
            {
                input.x = 0;
            }
        }
    }

    public void LeftButton(bool L)
    {
        leftB = L;
    }
    public void RightButton(bool R)
    {
        rightB = R;
    }
}
