﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float timer;
    public Text txtTimer;
    public Text txtCoolDownMissel;
    public Image screenFader;

    public bool gameOver = false;

	// Update is called once per frame
	void Update ()
    {
        if (gameOver)
        {
            ChamaGameOver();
        }

        timer -= Time.deltaTime;

	}

    public void CarregaFase(string fase)
    {
        SceneManager.LoadScene(fase);
    }

    public void ChamaGameOver()
    {
        StartCoroutine(ScreenFade());
        Invoke("CarregaGameOver", 3f);
        
    }

    void CarregaGameOver()
    {
        SceneManager.LoadScene("TelaGameOver");
    }

    IEnumerator ScreenFade()
    {
        while (true)
        {
            Debug.Log("Aplicando alfa");

            Color color = screenFader.color;
            color.a += 0.01f;
            screenFader.color = color;

            yield return new WaitForSeconds(0.01f);
        }

    }

    void ChecaTempo()
    {
        if (timer <= 0f)
        {
            gameOver = true;
        }
    }

    void ChecaInimigos()
    {
        if (FindObjectOfType<EnemyManager>().inimigosCont <= 0)
        {
            gameOver = true;
        }
    }
}
