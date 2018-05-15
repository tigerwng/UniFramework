/*
 * @Author: zhen wang 
 * @Date: 2017-12-11 16:11:41 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2017-12-14 16:08:05
 */


namespace tiger
{
    public delegate void MessageSender<T, C>(T sender, C content);

    public delegate void CallbackFunc_0();

    public delegate void CallbackFunc_1<T>(T t);
}