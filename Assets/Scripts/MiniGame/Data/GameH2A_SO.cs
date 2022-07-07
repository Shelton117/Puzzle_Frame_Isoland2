using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;

namespace Scripts.MiniGame.Data
{
    /// <summary>
    /// CreateAssetMenu 在菜单栏中开启数据主题实例化功能：新建数据表（SO-.asset文件）
    /// 里面的公开变量为表的字段
    /// 方法为处理函数，一般为查找
    /// </summary>
    [CreateAssetMenu(fileName = "GameH2A_SO", menuName = "Mini Game Data/GameH2A_SO")]
    public class GameH2A_SO : ScriptableObject
    {
        [SceneName] public string gameName;
        [Header("球的名称和对应的名字")] public List<BallDetails> ballDataList;
        [Header("小游戏逻辑：线")] public List<Conections> lineConections;
        [Header("小游戏逻辑：球")] public List<BallName> starBallOrder;

        public BallDetails GetBallDetails(BallName ballName)
        {
            return ballDataList.Find(b => b.ballName == ballName);
        }
    }

    [System.Serializable]
    public class BallDetails
    {
        public BallName ballName;
        public Sprite wrongSprite;
        public Sprite rightSprite;
    }

    [System.Serializable]
    public class Conections
    {
        public int from;
        public int to;
    }
}
