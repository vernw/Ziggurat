using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Pulse : MonoBehaviour
{

    private TextMesh textMesh;
    private TextMesh titleTextMesh;
    public float faded;
    public float solid;

    // Use this for initialization
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
        titleTextMesh = GameObject.FindGameObjectWithTag("Title").GetComponent<TextMesh>();
        faded = 0.15f;
        solid = 1.0f;

        InvokeRepeating("FadeOut", 2.0f, 4.5f);
        InvokeRepeating("FadeIn", 4.0f, 4.5f);
        print(textMesh.color);
    }

    public void FadeOut()
    {
        DOTween.ToAlpha(() => textMesh.color, x => textMesh.color = x, faded, 1);
    }

    public void FadeIn()
    {
        DOTween.ToAlpha(() => textMesh.color, x => textMesh.color = x, solid, 1);
    }

    public void StartGame()
    {
        // Camera pans to character; game begins; disable Title
        CancelInvoke("FadeOut");
        CancelInvoke("FadeIn");
        // Fades text
        DOTween.ToAlpha(() => textMesh.color, x => textMesh.color = x, 0, 2.0f);
        DOTween.ToAlpha(() => titleTextMesh.color, x => titleTextMesh.color = x, 0, 2.0f);
        Invoke("Disable", 2.0f);
    }

    public void Disable()
    {
        GameObject.Find("Title").SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }
}
