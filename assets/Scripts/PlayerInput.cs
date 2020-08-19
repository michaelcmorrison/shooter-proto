using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static float Vertical => Input.GetAxis("Vertical");
    public static float Horizontal => Input.GetAxis("Horizontal");
    public static bool Shoot => Input.GetButton("Fire1");
    
}
