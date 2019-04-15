/*
 * @Author: zhen wang 
 * @Date: 2017-12-14 16:06:15 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-05-23 17:44:26
 */


using System;

namespace tiger
{
    public class TimeHelper
	{
		/// <summary>
		/// Gets the unix time. 将参数datetime转换为Unix时间戳
		/// </summary>
		/// <returns>The unix time.</returns>
		/// <param name="dateTime">Date time. If want get current time, then could use `DateTime.Now`</param>
		public static long GetUnixTime(DateTime dateTime)
		{
			return (dateTime.ToUniversalTime().Ticks / 10000000 - 62135596800);
		}

		/// <summary>
		/// Gets the date time. 将参数unixtime转换为DateTime类型
		/// </summary>
		/// <returns>The date time.</returns>
		/// <param name="unixTime">Unix time.</param>
		public static DateTime GetDateTime(uint unixTime)
		{
			return (new DateTime(1970, 1, 1)).AddSeconds(unixTime).ToLocalTime();
		}
	}

}