using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Follow mouse
    private Vector3 mousePosition;
    public float moveSpeed = 1f;

    // Restrict movement
    public float _radius = 8.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // follow mouse
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        // Restrict movement
        var input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        var vectorFromParent = transform.localPosition + new Vector3(input.x, input.y, 0) * moveSpeed * Time.deltaTime;
        transform.localPosition = Vector2.ClampMagnitude(vectorFromParent, _radius);
    }
}
