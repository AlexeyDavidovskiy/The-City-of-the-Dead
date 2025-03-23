using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text killedZombiesText;
    [SerializeField] private Text killedBadGuysText;
    private int score;
    private int killedZombies;
    private int killedBadGuys;

    private void Start()
    {
        scoreText.text = Convert.ToString(score);
        killedZombiesText.text = Convert.ToString(killedZombies);
        killedBadGuysText.text = Convert.ToString (killedBadGuys);
    }

    private void OnEnable()
    {
        score = GlobalVars.totalScore;
        killedZombies = GlobalVars.zombieKilled;
        killedBadGuys = GlobalVars.badGuyesKilled;
    }
}
