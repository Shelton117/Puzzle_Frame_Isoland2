
namespace Scripts.MiniGame.Logic
{
    public class H2AReset : Interactive.Interactive
    {
        //private Transform gearSprite;

        //private void Awake()
        //{
        //    gearSprite = transform.GetChild(0);
        //}

        public override void EmptyClicked()
        {
            // gearSprite.DP
            GameController.Instance.ResetGame();
        }
    }
}