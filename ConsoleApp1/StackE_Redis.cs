using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StackE_Redis
    {

        // 配置连接字符串
       static string redisConnectionString = "localhost:6379";


        public  static  void Read() 
        {

            // 创建连接
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);
            
                // 获取数据库
                IDatabase db = redis.GetDatabase(2);//设置索引2为数据库,显示db2

       
                //设置myKey只有300秒有效时间
                TimeSpan timeSpan = TimeSpan.FromSeconds(300);
                // 设置键值对
                db.StringSet("myKey", "myValue89898", timeSpan);
                Console.WriteLine("--------------------------------------------");

                //List  类型
                RedisValue[] arr = new RedisValue[1000];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new RedisValue($"测试Redis{i.ToString()}");
                   
                }
                Console.WriteLine($"测试Redis{arr.Length}");
                db.ListLeftPush("Listtest", arr);
                 
                RedisValue[] list = db.ListRange("Listtest", 0, 5);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("--------------------------------------------list");

                //redis HashSet

                db.KeyDelete("myHashSet");
                db.HashSet("myHashSet", "id", "9527");
                db.HashSet("myHashSet", "userName", "admin");
                db.HashSet("myHashSet", "sex", "男");
                db.HashSet("myHashSet", "age", "22");
                db.HashDelete("myHashSet", "sex");
                HashEntry[] hashEntries = db.HashGetAll("myHashSet");
                foreach (var item in hashEntries)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("--------------------------------------------hashset");
                //set


                db.KeyDelete("mySet");
                db.SetAdd("mySet", "a1");
                db.SetAdd("mySet", "a2");
                db.SetAdd("mySet", "a3");
                db.SetAdd("mySet", "a4");
                db.SetAdd("mySet", "a5");
                RedisValue[] redisValues = db.SetMembers("mySet");
                foreach (var item in redisValues)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("--------------------------------------------set");

                //set 交集
              
                db.SetAdd("mySet4", "a1");
                db.SetAdd("mySet4", "a2");
                db.SetAdd("mySet4", "a6");
                db.SetAdd("mySet4", "a7");
                RedisValue[] redisValue2 = db.SetCombine(SetOperation.Intersect, "mySet", "mySet4");
                foreach (var item in redisValue2)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("--------------------------------------------交集");





                //差集
                RedisValue[] redisValues6 = db.SetCombine(SetOperation.Difference, "mySet", "mySet4");
                foreach (var item in redisValues6)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("--------------------------------------------差集");




                //UNION 并集
                RedisValue[] redisValues5 = db.SetCombine(SetOperation.Union, "mySet", "mySet4");
                foreach (var item in redisValues5)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("--------------------------------------------并集");


                db.KeyDelete("myZset");
                db.SortedSetAdd("myZset", "a1", 69);
                db.SortedSetAdd("myZset", "a2", 79);
                db.SortedSetAdd("myZset", "a3", 85);
                db.SortedSetAdd("myZset", "a4", 82);
                db.SortedSetAdd("myZset", "a5", 92);
                //分数范围
                RedisValue[] redisValues_zset = db.SortedSetRangeByScore("myZset", 70, 90);
                foreach (var item in redisValues_zset)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("--------------------------------------------ZSET");


                //正序
                SortedSetEntry[] sortedSetEntries = db.SortedSetRangeByRankWithScores("myZset", 0, -1, Order.Ascending);
                foreach (var item in sortedSetEntries)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("--------------------------------------------ZSET");



                //倒叙
                SortedSetEntry[] sortedSetEntries_desc = db.SortedSetRangeByRankWithScores("myZset", 0, -1, Order.Descending);
                foreach (var item in sortedSetEntries_desc)
                {
                    Console.WriteLine(item);
                }


                redis.Close();

            

        }

    }
}
