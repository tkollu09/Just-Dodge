using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{   
    public GameObject platform;
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && collision.transform.parent != null)
        {
            if (transform.childCount == 1) 
            {
                collision.transform.parent = null;
            } 
            
        }                   
    }

}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    public GameObject platform;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && collision.transform.parent == null)
        {
            Debug.Log(collision.gameObject.transform.parent != null);
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" &&  collision.transform.parent != null)
        {
            collision.transform.parent = null;
        }
    }
}
*/


