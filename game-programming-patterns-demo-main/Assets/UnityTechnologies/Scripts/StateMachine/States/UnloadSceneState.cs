using DesignPatterns.StateMachines;
using DesignPatterns.Utilities;
using System.Collections;


namespace DesignPatterns
{
    public class UnloadLastSceneState : AbstractState
    {
        readonly SceneLoader m_SceneLoader;

        public UnloadLastSceneState(SceneLoader sceneLoader)
        {
            m_SceneLoader = sceneLoader;
        }

        public override IEnumerator Execute()
        {
            yield return m_SceneLoader.UnloadLastScene();
        }
    }
}
