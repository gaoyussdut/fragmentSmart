using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.Utils
{
    class RedisCacheHelper
    {
        int Default_Timeout = 600;//默认超时时间（单位秒）
        string address = "localhost";
        //JsonSerializerSettings jsonConfig = new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        ConnectionMultiplexer connectionMultiplexer;
        IDatabase database;

        public RedisCacheHelper()
        {
            //this.address = ConfigurationManager.AppSettings["RedisServer"];

            //if (this.address == null || string.IsNullOrWhiteSpace(this.address.ToString()))
            //    throw new ApplicationException("配置文件中未找到RedisServer的有效配置");
            connectionMultiplexer = ConnectionMultiplexer.Connect(address);
            database = connectionMultiplexer.GetDatabase();
        }
        /// <summary>
        /// set添加单个元素   
        /// 具有唯一性   比如在线人数/点赞人数/收藏人数等
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool SetAdd(string key, string value, TimeSpan? span = null, int db = -1)
        {
            try
            {
                return database.SetAdd(key, value);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// set添加多个元素集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public long SetAdd(string key, List<string> arryList, int db = -1)
        {
            try
            {
                RedisValue[] valueList = arryList.Select(u => (RedisValue)u).ToArray();
                return database.SetAdd(key, valueList);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// set添加多个对象集合   序列化
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public long SetAddList<T>(string key, IEnumerable<T> list, int db = -1) where T : class
        {
            try
            {
                List<RedisValue> listRedisValue = new List<RedisValue>();
                foreach (var item in list)
                {
                    string json = JsonConvert.SerializeObject(item);
                    listRedisValue.Add(json);
                }
                return database.SetAdd(key, listRedisValue.ToArray());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取set集合的长度
        /// </summary>
        /// <param name="key"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public long SetLength(string key, int db = -1)
        {
            try
            {
                return database.SetLength(key);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 检查元素是否属于Set集合
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool ExistsInSet(string key, string value, int db = -1)
        {
            try
            {
                return database.SetContains(key, value);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据key获取所有Set元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<string> GetMembers(string redisKey, int db = -1)
        {
            try
            {
                var rValue = database.SetMembers(redisKey);
                return rValue.Select(ob => ob.ToString()).ToList<String>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SetRemove(String key,String value) {
            return database.SetRemove(key, value);
        }

        /// <summary>
        /// 根据key获取所有Set对象集合  反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<T> GetAllMembers<T>(string redisKey, int db = -1) where T : class
        {
            List<T> result = new List<T>();
            try
            {
                var arr = database.SetMembers(redisKey);
                foreach (var item in arr)
                {
                    if (!item.IsNullOrEmpty)
                    {
                        var t = JsonConvert.DeserializeObject<T>(item);
                        if (t != null)
                        {
                            result.Add(t);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return result;
        }


        /// <summary>
        /// 根据key随机获取Set中的1个元素   不删除该元素
        /// 可应用于中奖类的案例
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public string GetRandomMember(string redisKey, int db = -1)
        {
            try
            {
                var rValue = database.SetRandomMember(redisKey);
                return rValue.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据key随机获取Set中的n个元素   不删除该元素
        /// 可应用于中奖类的案例
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="count"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public IEnumerable<string> GetRandomMembers(string redisKey, long count, int db = -1)
        {
            try
            {
                var rValue = database.SetRandomMembers(redisKey, count);
                return rValue.Select(ob => ob.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 随机删除指定key集合中的一个值，并返回这些值  
        /// 可应用于抽奖类的案例
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public string GetRandomRemovePop(string redisKey, int db = -1)
        {
            try
            {
                var rValue = database.SetPop(redisKey);
                return rValue.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 随机删除指定key集合中的n个值，并返回这些值  
        /// 可应用于抽奖类的案例
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="count"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public IEnumerable<string> GetRandomRemovePops(string redisKey, long count, int db = -1)
        {
            try
            {
                var rValue = database.SetPop(redisKey, count);
                return rValue.Select(ob => ob.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 返回指定rediskey集合的交集、差集、并集  
        /// 只能在同一个库内查询，跨库则不行
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="keyList"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public IEnumerable<string> GetCombines(SetOperation operation, List<string> keyList, int db = -1)
        {
            try
            {

                RedisKey[] valueList = keyList.Select(u => (RedisKey)u).ToArray();
                var rValue = database.SetCombine(operation, valueList);
                return rValue.Select(ob => ob.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool StringSet(string key, String value)
        {
            return database.StringSet(key, value);
        }

        public String StringGet(string key)
        {
            return database.StringGet(key);
        }

        public bool KeyDelete(String key) {
            return database.KeyDelete(key);
        }
    }
}
