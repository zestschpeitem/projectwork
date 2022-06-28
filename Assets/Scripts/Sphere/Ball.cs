using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public int speed; // скорость передвижения
    public float health;
    public float numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Vector3 _startPosition;
    private AudioSource source;
    public TextMeshProUGUI resultText;

    void Start()
    {
        // Получить доступ к компоненту Rigidbody
        rb = GetComponent<Rigidbody>();
    _startPosition = transform.position;
        source = GetComponent<AudioSource>();
        source.Play();
    }
    void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void Update()
    {
        if (transform.position.y < -300f)
        {
            numOfHearts--;
            transform.position = _startPosition;
            rb.velocity = Vector3.zero;
        }
        if (numOfHearts == 0)
        {
            Application.LoadLevel(0);
        }
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Нажатие стрелочки вперёд или назад
        float moveVertical = Input.GetAxis("Vertical");

        // Перемещение шара
        Vector3 movement = new Vector3(moveHorizontal * speed, 0, moveVertical * speed);
        rb.AddForce(movement);
      
    }
    private void OnTriggerEnter(Collider other)
    {
        resultText.color = Color.blue;
        resultText.text = "WIN!";
    }


}