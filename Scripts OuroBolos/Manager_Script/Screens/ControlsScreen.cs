using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScreen : MonoBehaviour
{
    public void ControlsMenu()
    {
        gameObject.SetActive(true);
    }

    public void CloseControlsMenu()
    {
        gameObject.SetActive(false);
    }
}
