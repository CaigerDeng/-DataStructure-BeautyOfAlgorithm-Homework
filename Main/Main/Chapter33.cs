using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter33
{
    class TestChapter33
    {
        static public void Run()
        {
            // https://leetcode-cn.com/problems/implement-strstr/


        }

        // 暴力
        public int BF(string haystack, string needle)
        {
            // 考虑haystack = needle，i + needle.Length <= haystack.Length 可以写等于号
            for (int i = 0; i + needle.Length <= haystack.Length; i++)
            {
                bool flag = true;
                for (var j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return i;
                }
            }
            return -1;

        }




    }


}
