using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DontDestory : MonoBehaviour {

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        
    }
}
