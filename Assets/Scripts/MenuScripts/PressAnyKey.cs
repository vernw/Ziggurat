using UnityEngine;
using DG.Tweening;
using UnityStandardAssets.ImageEffects;
using System.Collections;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    private TextMesh textMesh;
    private TextMesh titleTextMesh;
    public float faded;
    public float solid;
    
    public Camera mainCamera;
    public Camera target1;
    public Camera target2;
    public Vector3 target1Pos;
    public Vector3 target2Pos;
    public Quaternion target1Rot;
    public Quaternion target2Rot;

    public Light flash;
    public float vignetteIntensity;
    public GameObject fadeBlack;
    public float fullBlack = 1;
    
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
        titleTextMesh = GameObject.FindGameObjectWithTag("Title").GetComponent<TextMesh>();
        faded = 0.15f;
        solid = 1.0f;

        mainCamera = Camera.main;
        target1Pos = target1.transform.position;
        target1Rot = target1.transform.rotation;
        target2Pos = target2.transform.position;
        target2Rot = target2.transform.rotation;

        vignetteIntensity = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VignetteAndChromaticAberration>().intensity;

        InvokeRepeating("FadeOut", 2.0f, 4.5f);
        InvokeRepeating("FadeIn", 4.0f, 4.5f);
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

        Target1();
    }

    public void Target1()
    {
        // Moves camera to target1
        mainCamera.transform.DOMove(target1Pos, 1.0f);
        mainCamera.transform.DORotate(target1Rot.eulerAngles, 1.0f);

        // Flashes light
        Light lightning = Instantiate(flash);

        // Calls target2's movement
        Invoke("Target2", 1.6f);
    }

    public void Target2()
    {
        // Moves camera to target2
        mainCamera.transform.DOMove(target2Pos, 1.0f);
        mainCamera.transform.DORotate(target2Rot.eulerAngles, 1.0f);

        // Flashes light
        Light lightning = Instantiate(flash);

        // Fadeaway
        DOTween.To(() => vignetteIntensity, x => vignetteIntensity = x, 1f, 2);
        Invoke("ToGame", 1.2f);
    }

    public void ToGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }
}
