using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Chapter32
{
    class TestChapter32
    {
        static public void Run()
        {
           
            bool res = BF("badabc", "abc");
            Console.WriteLine("BF res:{0}", res);

            bool res2 = RK("badabc", "abc");
            Console.WriteLine("RK res:{0}", res2);

        }

        //BruteForce
        static public bool BF(string main, string pattern)
        {
            int mainLen = main.Length;
            int pattLen = pattern.Length;
            if (mainLen < pattLen)
            {
                return false;
            }
            if (IsSameStr(main, pattern))
            {
                return true;
            }
            for (int i = 0; i <= mainLen - pattLen;)
            {
                string con = main.Substring(i, pattLen);
                if (IsSameStr(con, pattern))
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        static public bool RK(string main, string pattern)
        {
            int mainLen = main.Length;
            int pattLen = pattern.Length;
            if (mainLen < pattLen)
            {
                return false;
            }
            if (IsSameStr(main, pattern))
            {
                return true;
            }
            int pattHash = GetSimpleHash(pattern);
            for (int i = 0; i <= mainLen - pattLen;)
            {
                string con = main.Substring(i, pattLen);
                int hash = GetSimpleHash(con);
                if (hash == pattHash)
                {
                    if (IsSameStr(con, pattern)) //哈希冲突
                    {
                        return true;
                    }
                }
                i++;
            }

            return false;
        }

        static private int GetSimpleHash(string str)
        {
            //哈希值算法：对每个字符ascii码求和
            int hash = 0;
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                hash += (int)arr[i];
            }
            return hash;
        }

        static public bool IsSameStr(string a, string b)
        {
            char[] aArr = a.ToCharArray();
            char[] bArr = b.ToCharArray();
            if (aArr.Length != bArr.Length)
            {
                return false;
            }
            //从前往后比较
            for (int i = 0; i < aArr.Length; i++)
            {
                if (aArr[i] != bArr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

}
