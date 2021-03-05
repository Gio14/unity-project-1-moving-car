using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   
    public GameObject player;
    public Vector3 offset = new Vector3(0, -3, 11);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraPosition();
    }


    Vector3 CameraPosition()
    {
        transform.position = player.transform.position + offset;

        return transform.position;

    }
}
