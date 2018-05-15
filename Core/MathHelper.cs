/*
 * @Author: zhen wang 
 * @Date: 2018-02-05 11:53:46 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-02-05 11:55:26
 */


using UnityEngine;


namespace tiger
{
    public class MathHelper
    {
        /**
            生产不重复随机数序列算法
            length <= max
        */
        public static int[] GetRandomInt(int min, int max, int length)
        {
            int[] sequence = new int[max];
            int[] output = new int[length];

            for(int i=0; i<max; i++)
            {
                sequence[i] = i;
            }

            int end = max-1;

            for(int j=0; j<length; j++)
            {
                if(end >= 0)
                {
                    int random = UnityEngine.Random.Range(min, end+1);
                    output[j] = sequence[random];

                    sequence[random] = sequence[end];
                    end--;
                    
                    // Debug.Log("random: " + random + " | output: " + output[j]);
                }
            }

            return output;
        }

        /**
            从input数组中随机选取length长度且不重复
        */
        public static int[] GetRandomOrderWithSource(int[] input, int length)
        {
            int end = input.Length-1;

            int[] output = new int[length]; 

            for(int c=0; c<length; c++)
            {
                int randomIdx = UnityEngine.Random.Range(0, end+1);

                output[c] = input[randomIdx];
                    
                input[randomIdx] = input[end];
                end--;
                
                // Debug.Log(String.Format("sort[{0}] : {1}", c, output[c]));
            }

            return output;
        }

    }
}

