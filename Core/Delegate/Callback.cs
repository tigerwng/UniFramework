/*
 * @Author: zhen wang 
 * @Date: 2017-12-11 16:11:41 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:02:39
 */

using System;

namespace tiger
{
    public delegate void MessageSender<T, C>(T sender, C content);

    public delegate void CallbackFunc_0();

    public delegate void CallbackFunc_1<T>(T t);

    public delegate void CallbackFunc_2<T1, T2>(T1 t1, T2 t2);

    public delegate void CallbackFunc_3<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
}