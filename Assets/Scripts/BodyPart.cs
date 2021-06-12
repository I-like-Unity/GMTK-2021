using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

public class BodyPart : MonoBehaviour
{
    public SnakeMovement SM;

    public facing Facing;

    bool canTurn;

    private void Start()
    {
        Facing = SM.Facing;
    }

    void Update()
    {
        if (SM.turnPoints.Contains(transform.position))
        {
            canTurn = true;
        }
        else
        {
            canTurn = false;
        }
    }

    void Turn()
    {
        if (canTurn)
        {
            int i = SM.bodyParts.IndexOf(gameObject) + 1;

            Facing = SM.bodyParts[i].GetComponent<BodyPart>().Facing;
        }

        Vector2 mov = new Vector2();

        if (Facing == facing.up)
        {
            mov = new Vector2(0, 1);
        }
        else if (Facing == facing.down)
        {
            mov = new Vector2(x, -1 + Mathf.Abs(x));
        }
        else if (Facing == facing.right)
        {
            mov = new Vector2(1 - Mathf.Abs(y), y);
        }
        else if (Facing == facing.left)
        {
            mov = new Vector2(-1 + Mathf.Abs(y), -1);
        }
    }
}
