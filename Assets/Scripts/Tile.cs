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

    public bool isCovered;

    private void Start()
    {
        if (gameObject.tag == "gridBorder") { return; }

        snapPreviewSpriteRenderer = _snapPreviewObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag == "gridBorder") { return; }

        tetris = collision.GetComponent<TetrisBlock>();
        tetrisSpriteRenderer = collision.GetComponent<SpriteRenderer>();

        // set snap preview sprite to the same as the tetris thats hovering over it
        snapPreviewSpriteRenderer.sprite = tetrisSpriteRenderer.sprite; 

        // set rotation to be the same as the tetris hovering over it
        _snapPreviewObject.transform.rotation = tetris.transform.rotation;

    }

    private void Update()
    {
        if (gameObject.tag == "gridBorder") { return; }
        if (tetris == null) { return; }

        if (tetris.IsFollowingTheMouse()) 
        {
            if (Vector2.Distance(tetris.transform.position, tetris.snapPos) > 2)
            {
                tetris.fade();
            }


            if (Vector2.Distance(transform.position, tetris.transform.position) < 0.5)
            {
                tetris.snapPos = transform.position;
                _snapPreviewObject.SetActive(true);
                tetris.unFade();
            }
            else
            {
                _snapPreviewObject.SetActive(false);
            }

 
        }

        // if tetris stop following the mouse
        else
        {
            _snapPreviewObject.SetActive(false);

            if (!tetris.snap) // if tetris hasn't snapped
            {
                if (tetris.isFading)
                {
                    tetris.selfDestruct();
                }

                tetris.setPos();
            }

        }

        

    }

    


}
