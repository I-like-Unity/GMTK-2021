using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public enum facing { right, left, up, down };

    public class SnakeMovement : MonoBehaviour
    {
        public float speed;

        public GameObject body;

        public List<Vector2> turnPoints = new List<Vector2>();
        public List<GameObject> bodyParts = new List<GameObject>();

        public Transform snakeHead;

        public GameObject lastBody;

        float time = 0;

        public facing Facing = facing.up;

        private void Start()
        {
            bodyParts.Add(snakeHead.gameObject);
        }

        private void Update()
        {
            if (time > 1) Move((int)Input.GetAxisRaw("Horizontal"), (int)Input.GetAxisRaw("Vertical"));

            time += Time.deltaTime;
        }

        void AddBodyPart()
        {
            Vector2 pos = (Vector2)lastBody.transform.position + (Vector2)lastBody.transform.TransformDirection(Vector2.down);
            Quaternion rot = lastBody.transform.localRotation;

            lastBody = Instantiate(body, pos, rot, snakeHead);

            bodyParts.Add(lastBody);
        }

        void Move(int x, int y)
        {
            time = 0;

            Vector2 mov = new Vector2();

            if (Facing == facing.up)
            {
                mov = new Vector2(x, 1 - Mathf.Abs(x));
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

            if (mov.x == 1)
            {
                Facing = facing.right;
            }
            else if (mov.x == -1)
            {
                Facing = facing.left;
            }
            else if (mov.y == 1)
            {
                Facing = facing.up;
            }
            else if (mov.y == -1)
            {
                Facing = facing.down;
            }

            if (x + y != 0)
            {
                turnPoints.Add(snakeHead.position);
            }

            snakeHead.position += (Vector3)mov;
        }
    }

}
