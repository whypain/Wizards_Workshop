using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _redTint;
    [SerializeField] private GameObject _snapPreview;
    [SerializeField] private SpriteRenderer _renderer;

    private GameObject _cursor;
    public bool moveable = false;

    private RedTint red;
    private SpriteRenderer snapSpriteRenderer;

    private int defaultSortingOrder = 10;

    public bool snap = false;
    public Vector2 snapPos;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        snapSpriteRenderer = _snapPreview.GetComponent<SpriteRenderer>();
        snapSpriteRenderer.sprite = _renderer.sprite;

        _cursor = GameObject.Find("Cursor");

        red = _redTint.GetComponent<RedTint>();

    }

    void Update()
    {
        Drag();
        
        if (moveable && Input.GetMouseButtonUp(0))
        {
            // animations go here
 
        }
        _renderer.sortingOrder = defaultSortingOrder;
        red.DynamicOrderInLayer();
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

    public void setSnapPreview()
    {
        _snapPreview.SetActive(true);
        _snapPreview.transform.position = snapPos;
    }

    public void delSnapPreview()
    {
        _snapPreview.SetActive(false);
    }

}
