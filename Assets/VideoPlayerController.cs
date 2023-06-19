using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public RawImage rawImage;
    public RenderTexture renderTexture;
    public string videoFileName = "W1.mp4";

    private VideoPlayer videoPlayer;

    private void Start()
    {
        SetupVideo();
    }

    void SetupVideo()
    {
        // VideoPlayer 컴포넌트 추가
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        // 비디오 파일의 경로 설정
        string videoFilePath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);

        // VideoPlayer 속성 설정
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoFilePath;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;

        // RawImage에 RenderTexture 연결
        rawImage.texture = renderTexture;

        // 비디오 재생 준비 및 재생
        videoPlayer.prepareCompleted += Prepared;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Prepare();
    }

    void Prepared(VideoPlayer vp)
    {
        // 비디오 준비가 완료되면 비디오 재생
        vp.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        Debug.Log("End reached!");
    }
}