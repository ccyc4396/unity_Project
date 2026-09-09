using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager 
{
    public static float xInputRaw;
    public static float yInputRaw;
    public static bool jumpSpace;
    public static bool DashLeftShift;
    public static bool mouse0;

    public static void Update()
    {
        xInputRaw = Input.GetAxisRaw("Horizontal");
        yInputRaw = Input.GetAxisRaw("Vertical");
        jumpSpace = Input.GetKeyDown(KeyCode.Space);
        DashLeftShift = Input.GetKeyDown(KeyCode.LeftShift);
        mouse0 = Input.GetKeyDown(KeyCode.Mouse0);
    }
}
