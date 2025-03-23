using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class FinalCutSceneController : MonoBehaviour
{
    private PlayableDirector finalCutScene;

    private void Awake()
    {
        finalCutScene = GetComponent<PlayableDirector>();
    }

    public void PlayCutScene() 
    {
        StartCoroutine(TimerForCutScene(finalCutScene));
    }

    private IEnumerator TimerForCutScene(PlayableDirector finalCutScene) 
    {
        yield return new WaitForSeconds(75f);
        finalCutScene.Play();
    }
}
