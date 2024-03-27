using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject _snapPreviewObject;

    private SpriteRenderer snapPreviewSpriteRenderer;
    private TetrisBlock tetris;
    private SpriteRenderer tetrisSpriteRenderer;


    private void Start()
    {
        snapPreviewSpriteRenderer = _snapPreviewObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        tetris = collision.GetComponent<TetrisBlock>();
        tetrisSpriteRenderer = collision.GetComponent<SpriteRenderer>();

        snapPreviewSpriteRenderer.sprite = tetrisSpriteRenderer.sprite;

    }

    private void Update()
    {
        if (tetris == null) { return; }

        if (tetris.IsFollowingTheMouse()) 
        {
           
            if (Vector2.Distance(transform.position, tetris.transform.position) < 0.5)
            {
                tetris.snapPos = transform.position;
                _snapPreviewObject.SetActive(true);

            }
            else
            {
                _snapPreviewObject.SetActive(false);
            }

 
        }
        else
        {
            if (!tetris.snap)
            {
                tetris.setPos();
 
            }

        }

        

    }

    


}
