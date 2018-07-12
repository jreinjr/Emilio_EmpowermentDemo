using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;

[System.Serializable]
[CreateAssetMenu(fileName = "VideoFile", menuName = "LocalAssets/VideoFile")]
public class VideoFile : ScriptableObject {
    public MediaPlayer.FileLocation m_fileLocation;
    public string m_path;
}
