using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    // SerializeField variables
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _redTint;
    [SerializeField] private SpriteRenderer _renderer;

    // SpriteRenderer related variables
    private RedTint red;
    private int defaultSortingOrder = 10;
    private Vector2 defaultSize;
    private Color spriteColor;

    // idk
    private GameObject _cursor;
    private float targetRotation = 90;

    // public variables
    public string displayName;
    public bool moveable = false;
    public bool snap = false;
    public Vector2 snapPos;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        defaultSize = transform.localScale;

        _cursor = GameObject.Find("Cursor");

        red = _redTint.GetComponent<RedTint>();

        spriteColor = _renderer.color;

    }

    void Update()
    {
        Drag();
        
        if (IsFollowingTheMouse())
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Rotate(targetRotation);
                if (targetRotation >= 360)
                {
                    targetRotation = 90;
                }
                else
                {
                    targetRotation += 90;
                }
            }
        }

        if (moveable && Input.GetMouseButtonUp(0))
        {
            moveable = false;

            // animations go here
            _renderer.sortingOrder = defaultSortingOrder;
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


    private void Rotate(float targetRotation)
    {
        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
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

    public bool isFading = false;
    public void fade()
    {
        _renderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0.2f);
        isFading = true;
    }

    public void unFade()
    {
        _renderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 1f);
        isFading = false;
    }

    public void selfDestruct()
    {
        Destroy(gameObject);
    }

}
