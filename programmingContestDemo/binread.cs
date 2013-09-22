using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace programmingContestDemo
{
    class binread
    {
        byte[] buf;

        /// <summary>
        /// string型から読み出す。int型には0を入れる
        /// </summary>
        /// <param name="text"></param>
        public binread(string text, int i)
        {
            //buf[]に格納
            buf =  System.Text.Encoding.ASCII.GetBytes(text);           

        }

        /// <summary>
        /// ファイルから読み出すときに使用する
        /// </summary>
        /// <param name="filename"></param>
        public binread(string filename)
        {
            //ファイルからバイナリ読み出し
            using (FileStream bread = new FileStream(filename, FileMode.Open,FileAccess.Read))
            {
                int fileSize = (int)bread.Length;
                buf = new byte[fileSize];
                //buf[]に格納
                bread.Read(buf, 0, buf.Length);               
            }
        }

        /// <summary>
        /// bufに格納されたバイナリ値をstringに変換
        /// </summary>
        /// <returns></returns>
        public string bindisplay()
        {
            string st = "";
            foreach (int n in buf)
            {
                string sixTeen = Convert.ToString(n, 16); 
                st = String.Format(st+"{0}", sixTeen);
            }

            return st;

        }


    }
}
