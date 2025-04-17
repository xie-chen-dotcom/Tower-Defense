using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 3;
    public float zoomSpeed = 300;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        transform.Translate(new Vector3(horizontal* speed, scroll*zoomSpeed, vertical*speed) * Time.deltaTime,Space.World);
    }
}
