using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Se encarga de crear un intervalo para la velocidad de la camara
    [Range(1.0f, 20.0f)]
    public float movement_speed;

    //Se encarga de crear un intervalo para la distacia que movera la camara
    [Range(1.0f, 6.0f)]
    public float distance;

    private float hScreenPercentage = 0.1f;
    private float vScreenPercentage = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        CenterAtPlayer();
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            CenterAtPlayer();
    }

    private void MoveCamera()
    {
        Vector2 mp = Input.mousePosition;
        int w = Screen.currentResolution.width;
        int h = Screen.currentResolution.height;

        // Horizontal
        if (mp.x < w * hScreenPercentage)
        {
            transform.position -= new Vector3(1, 0) * movement_speed * Time.deltaTime;
        }
        else if (mp.x > w - w * hScreenPercentage)
        {
            transform.position += new Vector3(1, 0) * movement_speed * Time.deltaTime;
        }

        // Vertical
        if (mp.y < h * vScreenPercentage)
        {
            transform.position -= new Vector3(0, 1) * movement_speed * Time.deltaTime;
        }
        else if (mp.y > h - h * vScreenPercentage)
        {
            transform.position += new Vector3(0, 1) * movement_speed * Time.deltaTime;
        }
    }

    public void CenterAtPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float y = distance;
        float x = 0;

        transform.position = player.transform.position + new Vector3(x, y, -10);
        transform.LookAt(player.transform);
    }
}
