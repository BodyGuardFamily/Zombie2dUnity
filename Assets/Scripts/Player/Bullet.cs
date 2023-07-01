using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    public void Update()
    {
        DestroyWhenOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPos = camera.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 ||
            screenPos.x > camera.pixelWidth ||
            screenPos.y < 0 ||
            screenPos.y > camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }

}
