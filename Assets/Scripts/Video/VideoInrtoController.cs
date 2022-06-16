using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoInrtoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private string _pathName;
    [SerializeField] private string _nextSceneName;

    private MiniGamesAction _inputActions;
    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.clip = Resources.Load<VideoClip>(_pathName);
        
        _videoPlayer.loopPointReached += EndReached;

        _inputActions = new MiniGamesAction();
        _inputActions.MiniGames.Enable();
        _inputActions.MiniGames.SkipVideo.performed += perf => FinishVideo();
    }
    private void OnEnable()
    {
        _videoPlayer.Play();
    }
    private void FinishVideo()
    {
        _videoPlayer.Stop();
        EndReached(_videoPlayer);
    }
    private void EndReached(VideoPlayer videoPlayer)
    {
        Debug.Log("VideoEnd");
        //LoadNextScene
    }
}
