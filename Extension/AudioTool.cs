using UnityEngine;
using System;
using System.Collections;


namespace tiger
{
    public class AudioTool : MonoBehaviour
    {
        

        public static AudioTool GetInstance()
        {
            if(m_instance == null)
            {
                var obj = new GameObject("AudioTool");
                m_instance = obj.AddComponent<AudioTool>();
                
                DontDestroyOnLoad(m_instance.gameObject);
            }

            return m_instance;
        }

        public static void DestoryInstance()
        {
            if(m_instance != null)
            {
                Destroy(m_instance.gameObject);

                m_instance = null;
            }
        }

        private static AudioTool m_instance = null;



        public float PlayEffectSound(string file)
        {
            var obj = new GameObject("effect sound");
            obj.transform.parent = transform;

            var audioSource = obj.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.loop = false;

            var clip = Resources.Load<AudioClip>(file);

            if(clip)
            {
                audioSource.PlayOneShot(clip);
                Destroy(obj, clip.length);

                return clip.length;
            }
            else
            {
                Debug.LogWarningFormat("load clip failed [{0}]", file);
                Destroy(obj);

                return 0;
            }
        }

        public void PlayBGM(string file)
        {
            var objTran = transform.Find("BGM");

            if(objTran == null)
            {
                objTran = new GameObject("BGM").transform;
                objTran.parent = transform;
                objTran.gameObject.AddComponent<AudioSource>();
            }

            var audioSource = objTran.GetComponent<AudioSource>();

            audioSource.playOnAwake = false;
            audioSource.loop = true;

            var clip = Resources.Load<AudioClip>(file);

            audioSource.clip = clip;

            audioSource.Play();    
        }

        public void StopBGM()
        {
            Transform objTran;
            if(objTran = transform.Find("BGM"))
            {
                var audio = objTran.GetComponent<AudioSource>();
                audio.Stop();
            }
        }

        public void PauseBGM()
        {
            var objTran = transform.Find("BGM");

             if(objTran != null)
            {
                objTran.GetComponent<AudioSource>().Pause();
            }
        }

        public void ResumeBGM()
        {
            var objTran = transform.Find("BGM");

            if(objTran != null)
            {
                objTran.GetComponent<AudioSource>().Play();
            }
        }

        public void StopAllEffect()
        {
            var audioSources = transform.GetComponentsInChildren<AudioSource>();

            for(int i=0; i<audioSources.Length; i++)
            {
                if(!audioSources[i].gameObject.name.Equals("BGM"))
                {
                    audioSources[i].Stop();
                    Destroy(audioSources[i].gameObject);
                }
            }
        }


    }
}
