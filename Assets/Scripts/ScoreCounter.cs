using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text scoreCounter;
    [SerializeField] private int enemyValue;
    private int currentScore;
    private int currentZombieScore;
    private int currentBadGueScore;

    public void EnemyIsDead() 
    {
        currentScore += enemyValue;
    }

    public void ZombieIsDead() 
    {
        currentZombieScore += 1;
    }

    public void BadGueIsDead() 
    {
        currentBadGueScore += 1;
    }

    public void ShowCurrentScore() 
    {
        scoreCounter.text = Convert.ToString(currentScore); 
    }

    private void OnDestroy()
    {
        GlobalVars.totalScore = currentScore;
        GlobalVars.zombieKilled = currentZombieScore;
        GlobalVars.badGuyesKilled = currentBadGueScore;
    }
}
