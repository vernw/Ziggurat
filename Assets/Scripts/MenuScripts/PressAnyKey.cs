using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PressAnyKey : MonoBehaviour
{
    private TextMesh textMesh;
    private TextMesh titleTextMesh;
    public float faded;
    public float solid;

    public Camera menuCamera;

    public Camera gameCamera;
    public Vector3 gameCameraPos;
    public Quaternion gameCameraRot;

    void Awake()
    {
        gameCamera.enabled = false;
    }
    
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
        titleTextMesh = GameObject.FindGameObjectWithTag("Title").GetComponent<TextMesh>();
        faded = 0.15f;
        solid = 1.0f;

        gameCameraPos = gameCamera.transform.position;
        gameCameraRot = gameCamera.transform.rotation;

        InvokeRepeating("FadeOut", 2.0f, 4.5f);
        InvokeRepeating("FadeIn", 4.0f, 4.5f);
        print(textMesh.color);
    }

    // Pulse cycles
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
        // Cancels pulse animations
        CancelInvoke("FadeOut");
        CancelInvoke("FadeIn");

        // Fades text
        DOTween.ToAlpha(() => textMesh.color, x => textMesh.color = x, 0, 2.0f);
        DOTween.ToAlpha(() => titleTextMesh.color, x => titleTextMesh.color = x, 0, 2.0f);

        // Moves and swaps camera
        menuCamera.transform.DOMove(gameCameraPos, 2.0f);
        menuCamera.transform.DORotate(gameCameraRot.eulerAngles, 2.0f);
        Invoke("CameraSwap", 2.5f);

        // Calls Disable() in 2.5 seconds
        Invoke("Disable", 5.0f);
    }

    // Swaps the menu camera to the game camera
    public void CameraSwap()
    {
        Debug.Log("CameraSwap");
        gameCamera.enabled = true;
        menuCamera.enabled = false;
    }

    // Deactivates all menu assets
    public void Disable()
    {
        GameObject.FindGameObjectWithTag("Menu").SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }
}
