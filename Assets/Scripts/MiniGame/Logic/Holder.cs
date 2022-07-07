using System.Collections.Generic;
using Scripts.Utilities;

namespace Scripts.MiniGame.Logic
{
    public class Holder : Interactive.Interactive
    {
        public BallName matchBall;
        public Ball currentBall;
        public HashSet<Holder> LinkHolders = new HashSet<Holder>();
        public bool isEmpty;

        public override void EmptyClicked()
        {
            foreach (var holder in LinkHolders)
            {
                if (holder.isEmpty)
                {
                    // �ƶ�
                    currentBall.transform.position = holder.transform.position;
                    currentBall.transform.SetParent(holder.transform);

                    // ����
                    holder.CheckBall(currentBall);
                    this.currentBall = null;

                    // �ı�״̬
                    this.isEmpty = true;
                    holder.isEmpty = false;

                    // ����Ƿ�ɹ�
                    EventHandler.CallCheckGameStateEvent();
                }
            }
        }

        public void CheckBall(Ball ball)
        {
            currentBall = ball;
            if (ball.ballDetails.ballName == matchBall)
            {
                currentBall.isMatch = true;
                currentBall.SetRight();
            }
            else
            {
                currentBall.isMatch = false;
                currentBall.SetWrong();
            }
        }
    }
}