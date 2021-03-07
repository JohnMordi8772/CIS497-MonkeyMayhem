using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    private float mouseX, mouseY, mouseZ, mouseSensitivity = 55;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");
        text.text = "Mouse Y: " + mouseY + " Mouse X: " + mouseX;
        //if (Input.GetAxisRaw("Mouse X") != 0 && Input.GetAxisRaw("Mouse Y") != 0)
        //{

        float yRot = 0;
        if (mouseY == 0)
        {
            yRot = 0;
        }
        else
        {
            yRot = Mathf.Atan(-mouseY / mouseX);
        }

        if (mouseX > 0)
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, yRot * (180f / Mathf.PI), 0));
        else
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, yRot * (180f / Mathf.PI) + 180f, 0));
            //} 



    }
}
