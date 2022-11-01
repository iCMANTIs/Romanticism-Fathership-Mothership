using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed;
    public void Move(Vector2 dir)
    {
        moveDir = dir;

    }
    private void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        if ((pos.x > Screen.width - 20 && moveDir.x > 0) || (pos.x < 20 && moveDir.x < 0))
        {
            moveDir.x = 0;
        }
        if((pos.y > Screen.height - 20 && moveDir.y > 0) || (pos.y < 20 && moveDir.y < 0))
        {
            moveDir.y = 0;
        }
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        //print("×ø±ê£º" + pos);
    }
}

