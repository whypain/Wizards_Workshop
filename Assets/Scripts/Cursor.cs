using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Camera cam;
    private CircleCollider2D radar;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //radar = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 screenPos = cam.ScreenToWorldPoint(mousePos);

        transform.position = new Vector3(screenPos.x, screenPos.y, 0);

    }

    private void FixedUpdate()
    {
        //IncreaseRadius();
    }

    void IncreaseRadius()
    {
        if (radar.radius < 1.5)
        {
            radar.radius += 0.2f;
        }
    }



}
