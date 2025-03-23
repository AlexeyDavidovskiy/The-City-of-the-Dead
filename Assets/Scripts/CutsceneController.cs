using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private float timeToSkip;
    private PlayableDirector cutscene;

    private void Awake()
    {
        cutscene = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            ScipCutScene();
        }
    }

    private void ScipCutScene()
    {
        cutscene.time = timeToSkip;
    }
}
