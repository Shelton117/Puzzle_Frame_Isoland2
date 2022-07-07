using UnityEngine;

namespace Scripts.Transition
{
    /// <summary>
    /// 切换场景的按钮
    /// 传送至XXX
    /// </summary>
    public class Teleport : MonoBehaviour
    {
        [SceneName]
        public string sceneFrom;
        [SceneName]
        public string scene2Move;

        public void Teleport_2_Scene()
        {
            TransitionManager.Instance.Transition(sceneFrom, scene2Move);
        }
    }
}