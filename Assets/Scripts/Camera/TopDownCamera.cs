using System;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    // The player
    public GameObject target;

    public Vector3 offset = new Vector3(0, 0, -1);
    // Update is called once per frame
    // transform camera position to player
    private void FixedUpdate()
    {   
        // if player exist adjust camera position
        if (target)
        {
            var position = target.transform.position;
            transform.position = new Vector3(
                position.x + offset.x, 
                position.y + offset.y, 
                position.z + offset.z);
        }
    }
}
