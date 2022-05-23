using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float forwardSpeed = 25f; // the variables necessary for the plane physics
    public float strafeSpeed = 7.5f;
    public float hoverSpeed = 5f;
    private float activeForwardSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f;
    private float hoverAcceleration = 2f;

    public float lookRateSpeed = 90f; //mouse turning speed
    private Vector2 lookInput, screenCenter, mouseDistance; // screen to 3d variables

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;//get the center of the screen position coordinates
        screenCenter.y = Screen.height * 0.5f;

        Cursor.lockState = CursorLockMode.Confined; //lock the mouse to the game window
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x; // get the input values of the mouse from it's position on the screen
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;//the distance from the center of the screen to the mouse position
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);//clamp the speed at which the plane follows the mouse 

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Horizontal"), rollAcceleration * Time.deltaTime); //smoothly rotate around the horizontal axis when using the roll

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed //rotation calculations
            * Time.deltaTime, -rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, //the speed at which the plane is going forward based on input
            forwardAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, // the speed at which the plane is going up or down based on input
            hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime; //update the horizontal position of the plane
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime; //update the y positions (descending or ascending) 
    }
}
