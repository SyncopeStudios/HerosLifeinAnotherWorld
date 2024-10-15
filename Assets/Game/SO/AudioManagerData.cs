using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioManagerData", menuName = "audio/AudioManagerData")]
public class AudioManagerData : ScriptableObject
{
    public List<SceneAudioClip> sceneAudioClips;
}
