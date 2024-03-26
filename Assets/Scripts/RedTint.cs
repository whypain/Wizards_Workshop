using UnityEngine;

public class RedTint : MonoBehaviour
{
    [SerializeField] SpriteRenderer _parentSprite;
    [SerializeField] TetrisBlock tetris;

    [SerializeField] SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer thisSprite = GetComponent<SpriteRenderer>();
        thisSprite.sprite = _parentSprite.sprite;

    }

    public void DynamicOrderInLayer()
    {
        // 9 is 1 layer below the tetris block so if the player is dragging/moving
        // the block, the red tint wouldn't cover the actual tetris block
        if (tetris.IsFollowingTheMouse())
        {
            myRenderer.sortingOrder = 9;
        }
        else
        {
            myRenderer.sortingOrder = 11;
        }
    }

}
