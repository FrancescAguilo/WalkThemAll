using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    private Vector3 scale;
    bool timeToWork = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 tmpvect = Vector3.zero;
        if (timeToWork)
        {
            
            float t = 2;

            tmpvect.x = Mathf.Lerp(scale.x, 0, t);
            tmpvect.y = Mathf.Lerp(scale.y, 0, t);
            tmpvect.z = Mathf.Lerp(scale.z, 0, t);
        }
        if (tmpvect.z < 0)
        {
            //timeToWork = false;
            tmpvect = new Vector3(0, 0, 0);
        }
        transform.localScale = tmpvect;
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        //timeToWork = true;
        Destroy(this.gameObject, 0.1f);
    }
}
