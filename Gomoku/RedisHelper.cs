using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku {

    public class RedisHelper {
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("111.229.219.242:6379");
        private static IDatabase db = redis.GetDatabase();

        private RedisHelper() {}

        public static void addRoomInfo(RoomInfo roomInfo) {
            string roomInfoStr = JsonConvert.SerializeObject(roomInfo);
            db.HashSet(new RedisKey("room"), new RedisValue(roomInfo.RoomID.ToString()), new RedisValue(roomInfoStr));
        }

        public static void updateRoomInfo(int roomID, int PlayerColor, int state) {
            RedisValue roomInfoValue = db.HashGet(new RedisKey("room"), new RedisValue(roomID.ToString()));
            RoomInfo roomInfo = (RoomInfo)JsonConvert.DeserializeObject(roomInfoValue.ToString(), typeof(RoomInfo));
            //玩家加入房间
            if (state == 0) {
                switch (PlayerColor) {
                    case 1:
                        roomInfo.BlackPlayerNum++;
                        roomInfo.TotalNum++;
                        break;
                    case 2:
                        roomInfo.WhitePlayerNum++;
                        roomInfo.TotalNum++;
                        break;
                    case 3:
                        roomInfo.AudienceNum++;
                        roomInfo.TotalNum++;
                        break;
                    default:
                        break;
                }
                addRoomInfo(roomInfo);
            //玩家离开房间
            } else if (state == 1) {
                //仅剩一个人，离开后删除房间
                if (roomInfo.TotalNum == 1) {
                    db.HashDelete(new RedisKey("room"), new RedisValue(roomID.ToString()));
                } else {
                    switch (PlayerColor) {
                        case 1:
                            roomInfo.BlackPlayerNum--;
                            roomInfo.TotalNum--;
                            break;
                        case 2:
                            roomInfo.WhitePlayerNum--;
                            roomInfo.TotalNum--;
                            break;
                        case 3:
                            roomInfo.AudienceNum--;
                            roomInfo.TotalNum--;
                            break;
                        default:
                            break;
                    }
                    addRoomInfo(roomInfo);
                }
            }
        }

        public static bool judgeCurPlayer(int roomID, int playerColor) {
            RedisValue roomInfoValue = db.HashGet(new RedisKey("room"), new RedisValue(roomID.ToString()));
            RoomInfo roomInfo = (RoomInfo)JsonConvert.DeserializeObject(roomInfoValue.ToString(), typeof(RoomInfo));
            switch (playerColor) {
                case 1:
                    return roomInfo.BlackPlayerNum == 0;
                case 2:
                    return roomInfo.WhitePlayerNum == 0;
                default:
                    return true;
            }
        }

        public static bool judgeRoomID(int roomID) {
            return db.HashExists(new RedisKey("room"), new RedisValue(roomID.ToString()));
        }

        public static List<RoomInfo> getRoomList() {
            List<RoomInfo> roomInfoList = new List<RoomInfo>();
            HashEntry[] entryList = db.HashGetAll(new RedisKey("room"));
            foreach (HashEntry entry in entryList) {
                RoomInfo roomInfo = (RoomInfo)JsonConvert.DeserializeObject(entry.Value.ToString(), typeof(RoomInfo));
                roomInfoList.Add(roomInfo);
            }
            return roomInfoList;
        }
    }
}