using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed;

    public GameObject body;

    public List<Vector2> turnPoints = new List<Vector2>();
    public List<GameObject> bodyParts = new List<GameObject>();

    public Transform snakeHead;

    public GameObject lastBody;

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    void AddBodyPart()
    {
        Vector2 pos = (Vector2)lastBody.transform.position + (Vector2)lastBody.transform.TransformDirection(Vector2.down);
        Quaternion rot = lastBody.transform.localRotation;

        lastBody = Instantiate(body, pos, rot, snakeHead);

        bodyParts.Add(lastBody);
    }

    void Move()
    {
        Vector2 snapPos = new Vector2(Mathf.Ceil(snakeHead.position.x / 1) * 1, Mathf.Ceil(snakeHead.position.y / 1) * 1);

        Vector2 roundedPos = new Vector2(Mathf.Round(snakeHead.position.x), Mathf.Round(snakeHead.position.y));

        if (roundedPos != snapPos)
        {
            snakeHead.position += snakeHead.TransformDirection(Vector2.down) * speed * Time.deltaTime;
        }
    }
}
