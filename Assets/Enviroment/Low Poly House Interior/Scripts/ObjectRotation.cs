using UnityEngine;

public class ObjectRotation : MonoBehaviour {

    public float HorizontalSpeed = 1f;
    public float verticalSpeed = .5f;

    public float xAngle = 4f;
    public float zAngle = 4f;

    float maxHeightMovement = .1f;
    private Vector3 start;
    private Vector3 end;

    private void Start() {
        transform.Rotate(xAngle, 0, zAngle);
        start = transform.position;
        end = transform.position + new Vector3(0, maxHeightMovement, 0);
    }

    private void FixedUpdate() {
        transform.Rotate(0, HorizontalSpeed, 0);
        float pingPong = Mathf.PingPong(Time.time * verticalSpeed, 1);
        transform.position = Vector3.Lerp(start, end, pingPong);
    }
}
