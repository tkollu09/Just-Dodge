using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginScript : MonoBehaviour
{

    // Start is called before the first frame update
    public void startGAME()
    {   
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
}
