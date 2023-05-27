using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform tf;
	public Transform camTf;

	Vector2 rotMouse;
	public int sens; 

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 controlMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		rotMouse = new Vector2(rotMouse.x + controlMouse.x * sens * Time.deltaTime,
								rotMouse.y + controlMouse.y * sens * Time.deltaTime);

		tf.eulerAngles = new Vector3(tf.eulerAngles.x, rotMouse.x, tf.eulerAngles.z);

		rotMouse.y = Mathf.Clamp(rotMouse.y, -90, 90);
		
		camTf.localEulerAngles = new Vector3(-rotMouse.y, camTf.localEulerAngles.y, camTf.localEulerAngles.z);
		
    }
}
