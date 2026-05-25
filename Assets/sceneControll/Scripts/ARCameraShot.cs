using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ARCameraShot : MonoBehaviour
{
    public Camera cameraToUse;
    public string screenshotName = "Screenshot.png";
    public Button camerashot;
    public Button close;
    public RawImage screenshotPreview;
    public RawImage frame;

    private void Start()
    {
        screenshotPreview.gameObject.SetActive(false);
        frame.gameObject.SetActive(false);
        camerashot.onClick.AddListener(TakeScreenshot);
        close.onClick.AddListener(closepannel);
        if (cameraToUse == null)
        {
            cameraToUse = Camera.main;
        }
    }

    public void TakeScreenshot()
    {
        screenshotPreview.gameObject.SetActive(true);
        frame.gameObject.SetActive(true);
        float screenAspectRatio = (float)Screen.width / (float)Screen.height;
        float captureAspectRatio = cameraToUse.aspect;
        int captureWidth;
        int captureHeight;

        if (captureAspectRatio >= screenAspectRatio)
        {
            captureWidth = Screen.width;
            captureHeight = Mathf.RoundToInt(Screen.width / captureAspectRatio);
        }
        else
        {
            captureHeight = Screen.height;
            captureWidth = Mathf.RoundToInt(Screen.height * captureAspectRatio);
        }

        RenderTexture rt = new RenderTexture(captureWidth, captureHeight, 24);
        cameraToUse.targetTexture = rt;

        cameraToUse.Render();

        Texture2D screenshot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, captureWidth, captureHeight), 0, 0);
        cameraToUse.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        byte[] bytes = screenshot.EncodeToPNG();
        string imagePath = Application.persistentDataPath + "/" + screenshotName;
        System.IO.File.WriteAllBytes(imagePath, bytes);
        Debug.Log("Screenshot saved to: " + imagePath);

        Texture2D savedScreenshot = new Texture2D(2, 2);
        savedScreenshot.LoadImage(System.IO.File.ReadAllBytes(imagePath));
        screenshotPreview.texture = savedScreenshot;
        StartCoroutine(WaitBeforeShow());
    }

    IEnumerator WaitBeforeShow()
    {
        
        yield return new WaitForSeconds(5);
        screenshotPreview.gameObject.SetActive(false);
        frame.gameObject.SetActive(false);
    }
    public void closepannel()
    {
        frame.gameObject.SetActive(false);
    }
}
