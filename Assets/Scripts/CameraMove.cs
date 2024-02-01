using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private Vector2 startPos;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {

            Touch touch = Input.GetTouch(0);

            // Bắt đầu vuốt
            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }

            // Đang vuốt
            else if (touch.phase == TouchPhase.Moved)
            {

                // Tính vector chỉ hướng di chuyển
                direction = touch.position - startPos;

                direction = -direction;

                // Di chuyển camera                 
                transform.position += new Vector3(direction.x/10, 0, direction.y/10);

                startPos = touch.position;
            }
        }
    }
}
