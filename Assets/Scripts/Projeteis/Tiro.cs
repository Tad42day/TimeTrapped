﻿using UnityEngine;
using System.Collections;

public class Tiro : Projetil {
	
    void Start()
    {
        Invoke("Destruir", 0.6f);

        if (direcao == Direcoes.Up)         { transform.rotation = Quaternion.Euler(0f, 0f, 0f);    }
        if (direcao == Direcoes.Down)       { transform.rotation = Quaternion.Euler(0f, 0f, 180f);  }
        if (direcao == Direcoes.Right)      { transform.rotation = Quaternion.Euler(0f, 0f, -90f);  }
        if (direcao == Direcoes.Left)       { transform.rotation = Quaternion.Euler(0f, 0f, 90f);   }
        if (direcao == Direcoes.UpRight)    { transform.rotation = Quaternion.Euler(0f, 0f, 325f);  }
        if (direcao == Direcoes.UpLeft)     { transform.rotation = Quaternion.Euler(0f, 0f, -325f); }
        if (direcao == Direcoes.DownRight)  { transform.rotation = Quaternion.Euler(0f, 0f, -135f); }
        if (direcao == Direcoes.DownLeft)   { transform.rotation = Quaternion.Euler(0f, 0f, 135f);  }
    }

	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
    }

    public override void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Inimigo" && collider.GetComponent<Humanoid>().nivelTerreno == nivelTerreno)
        {
            collider.SendMessageUpwards("AplicarDano", dano);
            Instantiate(explosao, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Limite")
        {
            Debug.Log("Colidiu com limites da fase");
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Obstaculo" && nivelTerreno == NiveisTerrenos.Chao)
        {
            Debug.Log("Colidiu com algum obstaculo");
            Destroy(gameObject);
        }

    }

}
