/*
 * @Author: zhen wang 
 * @Date: 2018-05-15 15:04:14 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:41:42
 */

using System;
using System.Text;
using UnityEngine;



namespace zw.UniFramework
{
    public static class UniLog
    {   
        public static void Info(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=lightblue>").Append(msg).Append("</color></size>");

            Debug.Log(sb.ToString());
        #endif
        }

        public static void InfoFromat(string format, params object[] args)
        {
        #if UNILOG_DEBUG
            Info(string.Format(format, args));
        #endif
        }

        public static void Warning(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=orange>").Append(msg).Append("</color></size>");

            Debug.LogWarning(sb.ToString());
        #endif
        }

        public static void WarningFormat(string format, params object[] args)
        {
        #if UNILOG_DEBUG
            Warning(string.Format(format, args));
        #endif
        }

        public static void Error(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=red>").Append(msg).Append("</color></size>");

            Debug.LogError(sb.ToString());     
        #endif       
        }

        public static void Print(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=cyan>").Append(msg).Append("</color></size>");

            MonoBehaviour.print(sb.ToString());
        #endif
        }

        public static void CCAssert(bool cond, string msg)
        {   
        #if UNILOG_DEBUG
            if(!cond)
            {
                Error("CCASSERT: " + msg);
            }
        #endif
        }


    }
}

