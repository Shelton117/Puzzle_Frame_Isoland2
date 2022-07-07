using Scripts.MiniGame.Data;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.MiniGame.Logic
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] private UnityEvent OnFinish;
        [Header("Game Data")]
        [SerializeField] private GameH2A_SO gameData;
        [SerializeField] private Transform[] holderTransforms;
        [SerializeField] private GameObject lineParent;
        [SerializeField] private LineRenderer linePrefab;
        [SerializeField] private Ball ballPrefab;

        private void Start()
        {
            DrawLine();
            CreateBall();
        }

        private void OnEnable()
        {
            EventHandler.CheckGameStateEvent += OnCheckGameStateEvent;
        }

        private void OnDisable()
        {
            EventHandler.CheckGameStateEvent -= OnCheckGameStateEvent;
        }

        private void OnCheckGameStateEvent()
        {
            foreach (var ball in FindObjectsOfType<Ball>())
            {
                if (!ball.isMatch)
                {
                    return;
                }
            }

            Debug.Log("game over");

            // 通关后取消碰撞
            foreach (var holder in holderTransforms)
            {
                holder.GetComponent<Collider2D>().enabled = false;
            }

            EventHandler.CallGamePassEvent(gameData.gameName);
            OnFinish?.Invoke();
        }

        public void ResetGame()
        {
            foreach (var holder in holderTransforms)
            {
                if (holder.childCount > 0)
                {
                    Destroy(holder.GetChild(0));
                }
            }

            CreateBall();
        }

        public void DrawLine()
        {
            foreach (var conections in gameData.lineConections)
            {
                var line = Instantiate(linePrefab, lineParent.transform);
                line.SetPosition(0, holderTransforms[conections.from].position);
                line.SetPosition(1, holderTransforms[conections.to].position);

                // 设置每个holder的连接数据
                holderTransforms[conections.from].GetComponent<Holder>().LinkHolders
                    .Add(holderTransforms[conections.to].GetComponent<Holder>());
                holderTransforms[conections.to].GetComponent<Holder>().LinkHolders
                    .Add(holderTransforms[conections.from].GetComponent<Holder>());
            }
        }

        public void CreateBall()
        {
            for (int i = 0; i < gameData.starBallOrder.Count; i++)
            {
                if (gameData.starBallOrder[i] == BallName.None)
                {
                    holderTransforms[i].GetComponent<Holder>().isEmpty = true;
                    continue;
                }

                Ball ball = Instantiate(ballPrefab, holderTransforms[i].transform);
                holderTransforms[i].GetComponent<Holder>().CheckBall(ball);
                holderTransforms[i].GetComponent<Holder>().isEmpty = false;
                ball.SetupBall(gameData.GetBallDetails(gameData.starBallOrder[i]));
            }
        }
    }
}