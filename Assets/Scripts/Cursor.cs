using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Camera cam;

    public static Vector2 worldMousePos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        worldMousePos = cam.ScreenToWorldPoint(mousePos);

        transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0);

    }




}
