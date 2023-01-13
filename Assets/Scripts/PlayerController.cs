using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;

	bool touchStart = false;

	Vector2 pointA;
	Vector2 point2;
	//public Transform circle;
	//public Transform outerCircirle;

	private float rotation;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		  rotation = Input.GetAxisRaw("Horizontal");
  //      if (Input.GetMouseButtonDown(0))
  //      {
		//	pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

		//	//circle.transform.position = pointA * -1;
		//	//outerCircirle.transform.position = pointA * -1;

		//	//circle.GetComponent<>().enabled = true;
		//}
  //      if (Input.GetMouseButton(0))
  //      {
		//	touchStart = true;
		//	point2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
  //      }
  //      else
  //      {
		//	touchStart = false;
  //      }
	}

	void FixedUpdate ()
	{

		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

			//Vector2 offset = point2 - pointA;
			//Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
			float xDelta = Input.GetTouch(0).deltaPosition.x;
			transform.Rotate(0, -xDelta * rotationSpeed * Time.deltaTime, 0);

			//circle.transform.position = new Vector2(pointA.x * direction.x, pointA.y * direction.y) * -1;
		}
	}

}
