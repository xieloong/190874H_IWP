using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    private static DontDestroyAudio Audio_instance;
    void Awake()
    {
        if (!Audio_instance)
            Audio_instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
