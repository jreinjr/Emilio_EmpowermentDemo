using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class VideoEventTimeline : MonoBehaviour {

    public GameObject coverHoverPrefab;
    public bool coverHoverActive;

    public void SpawnCoverHover()
    {
        
    }

    private void Start()
    {
        Debug.Log(GetComponent<PlayableDirector>().playableAsset.outputs);
    }
}
