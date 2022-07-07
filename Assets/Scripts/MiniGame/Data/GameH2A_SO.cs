using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;

namespace Scripts.MiniGame.Data
{
    /// <summary>
    /// CreateAssetMenu �ڲ˵����п�����������ʵ�������ܣ��½����ݱ�SO-.asset�ļ���
    /// ����Ĺ�������Ϊ����ֶ�
    /// ����Ϊ��������һ��Ϊ����
    /// </summary>
    [CreateAssetMenu(fileName = "GameH2A_SO", menuName = "Mini Game Data/GameH2A_SO")]
    public class GameH2A_SO : ScriptableObject
    {
        [SceneName] public string gameName;
        [Header("������ƺͶ�Ӧ������")] public List<BallDetails> ballDataList;
        [Header("С��Ϸ�߼�����")] public List<Conections> lineConections;
        [Header("С��Ϸ�߼�����")] public List<BallName> starBallOrder;

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
