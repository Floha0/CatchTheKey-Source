using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private KeyManager keyManagercs;

    [System.NonSerialized]
    public int score;
    private TMP_Text scoreText;
    
    private AudioSource scoreUpSound;
    private AudioSource scoreDownSound;

    private void Start() {
        keyManagercs = GetComponent<KeyManager>();

        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        scoreUpSound = GameObject.Find("ScoreUp").GetComponent<AudioSource>();
        scoreDownSound = GameObject.Find("ScoreDown").GetComponent<AudioSource>();

        scoreText.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 255, 255, 100));
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (keyManagercs.keyStatus[0])
            {
                keyManagercs.ResetKey();
                score++;
                SetScore(true);
            }
            else
            {
                score--;
                SetScore(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (keyManagercs.keyStatus[1])
            {
                keyManagercs.ResetKey();
                score++;
                SetScore(true);
            }
            else
            {
                score--;
                SetScore(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (keyManagercs.keyStatus[2])
            {
                keyManagercs.ResetKey();
                score++;
                SetScore(true);
            }
            else
            {
                score--;
                SetScore(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (keyManagercs.keyStatus[3])
            {
                keyManagercs.ResetKey();
                score++;
                SetScore(true);
            }
            else
            {
                score--;
                SetScore(false);
            }
        }
    }

    public void SetScore(bool i)
    {
        scoreText.text = "Score: " + score.ToString();

        Color32 scoreColor;

        if (score < 0)
        {
            scoreColor = new Color32(255, 0, 0, 200);
        }
        else if (score == 0)
        {
            scoreColor = new Color32(255, 255, 255, 100);
        }
        else
        {
            scoreColor = new Color32(50, 255, 0, 200);

        }

        scoreText.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, scoreColor);
        if (i)
        {
            scoreUpSound.Play();
        }
        else
        {
            scoreDownSound.Play();
        }
    }
}
