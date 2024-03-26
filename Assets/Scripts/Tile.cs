using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private TetrisBlock tetris;
    private SpriteRenderer tetris_sprite;

    private void OnTriggerStay2D(Collider2D collision)
    {
        tetris = collision.GetComponent<TetrisBlock>();
        tetris_sprite = collision.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (tetris == null) { return; }

        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
        

        if (tetris.IsFollowingTheMouse()) 
        {
           
            if (Vector2.Distance(transform.position, tetris.transform.position) < 0.6)
            {
                tetris.snapPos = transform.position;
                tetris.setSnapPreview();

            }

 
        }
        else
        {
            if (!tetris.snap)
            {
                tetris.setPos();
                tetris.delSnapPreview();
 
            }

        }

        

    }

    


}
