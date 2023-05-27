using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    bool interact;

    public GameObject door;
    public Camera cam;
    public Text txt;
    int angle;
    Quaternion rot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5);
        
        if (interact == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (angle == 90)
                {
                    angle = 0;
                }
                else
                {
                    angle = 90;
                }
            }
        }
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 15))
        {
            if (hit.distance <= 2)
            {
                txt.text = "Pressione [E] para abrir";
                interact = true;
            }
            else
            {
                txt.text = "";
                interact = false;
            }
        }
        else
        {
            txt.text = "";
            interact = false;
        }
        
    }
}
