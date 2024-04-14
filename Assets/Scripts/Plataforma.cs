using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    
    [SerializeField] private float velocidadMovimiento;

    private int siguientePlataforma = 1;

    private bool ordenPlataformas = true;

    private void Update()
    {
        if(ordenPlataformas && siguientePlataforma + 1 >= puntosMovimiento.Length)
        {
            ordenPlataformas = false;
        }

        if (!ordenPlataformas && siguientePlataforma <= 0)
        {
            ordenPlataformas = true;
        }

        if(Vector2.Distance(transform.position, puntosMovimiento[siguientePlataforma].position) < 0.1f)
        {
            if (ordenPlataformas)
            {
                siguientePlataforma += 1;
            } else
            {
                siguientePlataforma -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePlataforma].position, velocidadMovimiento * Time.deltaTime);
    }

    private void OnColissionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnColissionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.transform.SetParent(null);
        }
    }

}
