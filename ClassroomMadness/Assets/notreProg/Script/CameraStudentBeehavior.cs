using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStudentBeehavior : MonoBehaviour
{
    public GameObject Player;
    public float speed = 2;
    private float yaw = 0;
    private float pitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(Player.transform.rotation.eulerAngles.x , Player.transform.rotation.eulerAngles.y + 90, Player.transform.rotation.eulerAngles.z);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        yaw += speed * Input.GetAxis("Mouse X");
        pitch -= speed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3( Player.transform.rotation.eulerAngles.x + pitch, Player.transform.rotation.eulerAngles.y+90 + yaw, Player.transform.rotation.eulerAngles.z);




    }
}
