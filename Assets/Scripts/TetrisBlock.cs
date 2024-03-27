using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _redTint;
    [SerializeField] private SpriteRenderer _renderer;

    private GameObject _cursor;
    public bool moveable = false;

    private RedTint red;

    private int defaultSortingOrder = 10;
    private Vector2 defaultSize;

    public bool snap = false;
    public Vector2 snapPos;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        defaultSize = transform.localScale;

        _cursor = GameObject.Find("Cursor");

        red = _redTint.GetComponent<RedTint>();

    }

    void Update()
    {
        Drag();
        
        if (moveable && Input.GetMouseButtonUp(0))
        {
            // animations go here
            _renderer.sortingOrder = defaultSortingOrder;
            red.DynamicOrderInLayer();
            transform.localScale = defaultSize;
        }
        
    }

    public void Drag()
    {
        if (!Input.GetMouseButton(0)) { return; }
        if (!moveable) { return; }

        snap = false;
        _renderer.sortingOrder = 20;

        if (_cursor.transform.childCount == 0)
        {
            transform.SetParent(_cursor.transform, true);
            transform.localScale = defaultSize * 1.1f;

        }

    }



    private void OnMouseEnter()
    {

        if (Input.GetMouseButton(0)) { return;  }
        moveable = true;
    }

    private void OnMouseExit()
    {

        if (!Input.GetMouseButton(0))
        {
            moveable = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("TetrisBlock") || collision.CompareTag("gridBorder"))
        {
            if (collision.CompareTag("gridBorder"))
            {
                _redTint.SetActive(true);
                return;
            }
            if (IsFollowingTheMouse() || collision.GetComponent<TetrisBlock>().IsFollowingTheMouse()) { return; }
            _redTint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TetrisBlock") || collision.CompareTag("gridBorder"))
        {
            _redTint.SetActive(false);
        }
    }

    public bool IsFollowingTheMouse()
    {
        return moveable && Input.GetMouseButton(0);
    }

    public void setPos()
    {
        transform.position = snapPos;
        snap = true;

        transform.parent = null;

    }

}
