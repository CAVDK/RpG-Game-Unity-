using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : mover
{
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }

}
