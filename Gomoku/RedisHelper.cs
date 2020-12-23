using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {

    public class RedisHelper {
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("112.125.88.163:6379");

        public static ConnectionMultiplexer getRedis() {
            return redis;
        }

        public static void addRoomID(int roomID) {
            IDatabase db = redis.GetDatabase();
            db.SetAdd("room", roomID);
        }

        public static List<string> getRoomList() {
            List<string> roomIDListStr = new List<string>();
            redis = RedisHelper.getRedis();
            IDatabase db = redis.GetDatabase();
            RedisValue[] roomIDList = db.SetMembers("room");
            foreach (RedisValue roomID in roomIDList) {
                roomIDListStr.Add(roomID.ToString());
            }
            return roomIDListStr;
        }
    }
}