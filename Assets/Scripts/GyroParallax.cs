using UnityEngine;
using System.Collections;

public class GyroParallax : MonoBehaviour
{



    public float speed = 1f;
    Vector3 acceleration;

    Vector3 basicPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.gyro.enabled)
        {
            float initialOrientationX = Input.gyro.rotationRateUnbiased.x;
            float initialOrientationY = Input.gyro.rotationRateUnbiased.y;

            acceleration = new Vector3(-initialOrientationY, initialOrientationX);
        }
        else
        {
            //basicPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition) - new Vector3(0.5f, 0.5f);

           // acceleration = Vector3.Lerp(basicPosition, acceleration , Time.deltaTime);
        }

        transform.Translate(acceleration * speed);
    }
}
