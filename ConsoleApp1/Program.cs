using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedisCacheHelper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // RedisCacheHelper.Add("hhhh", "测试", DateTime.Now.AddDays(1));

            //Console.WriteLine("Redis获取缓存：hhhh");
            string str = RedisCacheHelper.RedisCacheHelper.Get<string>("hhhh");
            Console.WriteLine(str);
            string str4 = RedisCacheHelper.RedisCacheHelper.Get<string>("py001");
            Console.WriteLine(str4);


            Console.WriteLine("Redis写入缓存：zhong");

            RedisCacheHelper.RedisCacheHelper.Add("zhong", "测试", DateTime.Now.AddDays(1));

            Console.WriteLine("Redis获取缓存：zhong");

            string str3 = RedisCacheHelper.RedisCacheHelper.Get<string>("zhong");

            Console.WriteLine(str3);

            Console.WriteLine("Redis获取缓存：wei");
            string str1 = RedisCacheHelper.RedisCacheHelper.Get<string>("foo");
            Console.WriteLine(str1);

            Console.ReadKey();
        }
    }
}
