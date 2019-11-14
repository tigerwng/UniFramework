/*
 * @Author: zhen wang 
 * @Date: 2018-12-14 14:05:32 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2019-01-26 17:23:54
 */

using System;
using System.Collections;
using UnityEngine;



namespace zw.uniframework
{
    public class AudioHelper : MonoBehaviour
    {
        

        public static AudioHelper GetInstance()
        {
            if(m_instance == null)
            {
                var obj = new GameObject("AudioHelper");
                m_instance = obj.AddComponent<AudioHelper>();
                
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

        private static AudioHelper m_instance = null;



        public float PlayEffectSound(string file)
        {
            var clip = Resources.Load<AudioClip>(file);

            if(clip)
            {
                var audioSource = this.CreateAudioSource(clip, "effect sound", 1.0f, false);
                audioSource.PlayOneShot(clip);
                
                Destroy(audioSource.gameObject, clip.length);

                return clip.length;
            }

            return 0;
        }

        public float PlayEffectSound(AudioClip audioClip)
        {
            var audioSource = this.CreateAudioSource(audioClip, "effect sound", 1.0f, false);
            audioSource.PlayOneShot(audioClip);

            Destroy(audioSource.gameObject, audioClip.length);
            
            return audioClip.length;
        }

        AudioSource CreateAudioSource(AudioClip audioclip, string name, float volume=1.0f, bool loop=true, bool playOnWake=false)
        {
            var objTran = transform.Find(name);

            if(objTran == null)
            {
                objTran = new GameObject(name).transform;
                objTran.parent = transform;
                objTran.gameObject.AddComponent<AudioSource>();
            }

            var audioSource = objTran.GetComponent<AudioSource>();
            audioSource.playOnAwake = playOnWake;
            audioSource.loop = loop;
            audioSource.volume = volume;
            audioSource.clip = audioclip;

            return audioSource;
        }

        public void PlayBGM(AudioClip audioClip, float volume=1.0f)
        {
            var audioSource = this.CreateAudioSource(audioClip, "BGM", volume, true, false);  
            audioSource.Play();
        }

        public void PlayBGM(string file, float volume=1.0f)
        {
            var clip = Resources.Load<AudioClip>(file);

            var audioSource = this.CreateAudioSource(clip, "BGM", volume, true, false);  
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
