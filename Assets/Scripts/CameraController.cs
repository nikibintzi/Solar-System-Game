using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraFPS = null;
    public float cameraSensitivity = 80;
    public float cameraPitch = 0.0f;   // used for rotation on y axis - camera looks directly forward
    public GameObject Player;
    public GameObject Meteor;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpadateMouseLookAt();

    }

    void UpadateMouseLookAt()
    {
        Vector2 mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        // y axis
        cameraPitch += mouse.y * cameraSensitivity * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);  // to not flip upside down

        cameraFPS.localEulerAngles = Vector3.right * (-cameraPitch);
        // x axis
        Player.transform.Rotate(Vector3.up * mouse.x * cameraSensitivity * Time.deltaTime); // rotate on x axis
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Player.transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            Player.transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Player.transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            Player.transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else
        {
            Player.transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            Player.transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }


        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            Instantiate(Meteor, transform.position, transform.rotation);
        }




    }
}
