using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickManuel : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;

    bool touchStart = false;

    Vector2 pointA;
    Vector2 point2;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            //circle.transform.position = pointA * -1;
            //outerCircirle.transform.position = pointA * -1;

            //circle.GetComponent<>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            point2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {

        if (touchStart)
        {

            Vector2 offset = point2 - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            //circle.transform.position = new Vector2(pointA.x * direction.x, pointA.y * direction.y) * -1;
        }
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
