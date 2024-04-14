using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Go to next level
            GameController.instance.NextLevel();
        }
    }
}
