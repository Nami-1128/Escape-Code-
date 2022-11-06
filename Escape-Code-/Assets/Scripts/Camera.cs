using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public new Transform camera;
    public Vector2 sensibility;
    bool escape;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
//Movimiento camara vvv        
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");

        if(xMouse != 0 && escape == false)
        {
            transform.Rotate(Vector3.up * xMouse * sensibility.x);
        }

        if(yMouse != 0 && escape == false)
        {
            float angle = (camera.localEulerAngles.x - yMouse * sensibility.y + 360) % 360;
            if(angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -90, 53);
            camera.localEulerAngles = Vector3.right * angle;
        }
//Bloquear y des-bloquear el mouse con escape vvv
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(escape == false)
            {
                Cursor.lockState = CursorLockMode.None;
                escape = true;
            }
            else
            {
                if(escape == true)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    escape = false;
                }
            }
        }

    }
}
