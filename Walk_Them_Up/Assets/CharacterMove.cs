using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update

    protected Joystick joystick;
    protected Rigidbody rb;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * 10f, 0, joystick.Vertical * 10f);
        
    }
}
