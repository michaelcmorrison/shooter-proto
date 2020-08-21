using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quit Game", menuName = "Scriptable Objects/Button Behaviours/Quit Game")]
public class QuitGame : ScriptableObject
{
    public void Quit()
    {
        Application.Quit();
    }
}
