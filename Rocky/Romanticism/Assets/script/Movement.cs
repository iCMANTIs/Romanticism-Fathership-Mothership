using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed=0.1f;
    public float a;

    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        a = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = this.transform.position + new Vector3(joystick.Horizontal*speed*Time.deltaTime, 0,0);
        if ( joystick.Horizontal < 0) 
        {
            this.transform.localScale=new Vector3(a, this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (joystick.Horizontal > 0)
        {
            this.transform.localScale = new Vector3(-a, this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
