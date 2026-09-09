using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCtor : MonoBehaviour
{
    public float xinput;
    public bool Space;
    
    private void Update()
    {
        InputManager.Update();
        xinput = InputManager.xInputRaw;
        Space = InputManager.jumpSpace;
       
    }
}
