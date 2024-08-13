using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusic : MonoBehaviour
{
    public static KeepMusic instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

}
