/*
 * @Author: zhen wang 
 * @Date: 2019-01-16 11:50:30 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2019-01-26 19:49:14
 */

using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using tiger.Core;



public class NativeShare : SingletonAssetMonoBehaviour<NativeShare> 
{
    public string Subject {private set; get;}
    public string ShareMessage {private set; get;}
    public string URL {private set; get;}
    public string Folder {private set; get;}
    public string ImageName {private set; get;}

    public static readonly string DEFAULT_IMAGE_NAME = "screenshot.png";

    private bool isProcessing = false;







    public void Init(string subject, string message, string url, string folder, string imagename=null)
    {
        this.Subject = subject;
        this.ShareMessage = message;
        this.URL = url;
        this.Folder = folder;
        this.ImageName = imagename==null ? DEFAULT_IMAGE_NAME:imagename;
    }

    public void ShareScreenshotWithText()
    {
        Share();
    }
    
    public void Share()
    {
        Debug.LogFormat("Share: subject[{0}], sendermessage[{1}], url[{2}], screenshotname[{3}]", Subject, ShareMessage, URL, ImageName);
        
#if UNITY_ANDROID
        if(!isProcessing)
            StartCoroutine(ShareScreenshot());
#elif UNITY_IOS
        if(!isProcessing)
            StartCoroutine(CallSocialShareRoutine());
#else
        Debug.Log("No sharing set up for this platform.");
#endif

        
    }

#if UNITY_ANDROID
    public IEnumerator ShareScreenshot()
    {
        isProcessing = true;

        // wait for graphics to render
        yield return new WaitForEndOfFrame();

        string screenShotPath = Path.Combine(Folder, ImageName);

        Debug.Log("NativeShare::ShareSceneshot - [" + screenShotPath + "]");

        yield return new WaitForSeconds(1f);

        if(!Application.isEditor)
        {
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject unityContext = currentActivity.Call<AndroidJavaObject>("getApplicationContext");

            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

            // AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            // AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + screenShotPath);

            // use FileProvider to get uri
            string packageName = unityContext.Call<string>("getPackageName");
            string authority = packageName + ".provider";
            AndroidJavaObject fileObj = new AndroidJavaObject("java.io.File", screenShotPath);
            AndroidJavaClass fileProvider = new AndroidJavaClass("android.support.v4.content.FileProvider");
            AndroidJavaObject uriObject = fileProvider.CallStatic<AndroidJavaObject>("getUriForFile", unityContext, authority, fileObj);
            
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
            intentObject.Call<AndroidJavaObject>("setType", "image/png");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), ShareMessage);

            AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Power By tigerWng");
            currentActivity.Call("startActivity", jChooser);
        }

        isProcessing = false;
    }
#endif
    
#if UNITY_IOS
    public struct ConfigStruct
    {
        public string title;
        public string message;
    }

    [DllImport ("__Internal")] private static extern void showAlertMessage(ref ConfigStruct conf);
    public struct SocialSharingStruct
    {
        public string text;
        public string url;
        public string image;
        public string subject;
    }

    [DllImport ("__Internal")] private static extern void showSocialSharing(ref SocialSharingStruct conf);
    public void CallSocialShare(string title, string message)
    {
        ConfigStruct conf = new ConfigStruct();
        conf.title = title;
        conf.message = message;
        showAlertMessage(ref conf);
        isProcessing = false;
    }

    public static void CallSocialShareAdvanced(string defaultTxt, string subject, string url, string img)
    {
        SocialSharingStruct conf = new SocialSharingStruct();
        conf.text = defaultTxt; 
        conf.url = url;
        conf.image = img;
        conf.subject = subject;

        #if !UNITY_EDITOR
        showSocialSharing(ref conf);
        #endif
    }

    IEnumerator CallSocialShareRoutine()
    {
        isProcessing = true;
        string file = Path.Combine(Folder, ImageName);

        yield return new WaitForSeconds(1f);
        
        NativeShare.CallSocialShareAdvanced(ShareMessage, Subject, URL, file);

        isProcessing = false;
    }

    void OnApplicationFocus(bool focusStatus)
    {
        isProcessing = false;
    }
#endif
}