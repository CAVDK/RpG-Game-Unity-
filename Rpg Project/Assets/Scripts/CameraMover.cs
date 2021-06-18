using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Transform player_Position;
    //what the difference should be between player and camers center before moving the camera
    public float boundX = 0.15f;
    public float boundY = 0.05f;



    private void Start()
    {
        player_Position = GameObject.Find("Player").transform;
    }

    /// <summary>
    /// we are using late update because we want the camera to move after the player have been moved
    /// </summary>
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //we check by how much has the player moved wrt to the center of camera
        float deltaX = player_Position.position.x - transform.position.x;

        //if it is more than bounds that we have set in the inspector we move
        if (deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < player_Position.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = player_Position.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < player_Position.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0f);



    }

}
