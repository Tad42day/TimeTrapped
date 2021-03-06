﻿using UnityEngine;
using System.Collections;

public abstract class Projetil : MonoBehaviour {

    public float velocidade;
    public Direcoes direcao;
    public NiveisTerrenos nivelTerreno;
    public float dirX;
    public float dirY;
    public int dano;
    public GameObject explosao;
    public AudioClip hitSound;
    public Rigidbody2D rgbd2D;
    protected Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public abstract void OnTriggerEnter2D (Collider2D collider);

    public void Destruir()
    {
        Destroy(gameObject);
    }

}
