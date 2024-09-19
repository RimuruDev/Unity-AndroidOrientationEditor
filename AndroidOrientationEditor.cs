#if UNITY_EDITOR && UNITY_ANDROID
using UnityEditor;

namespace AbyssMoth
{
    [InitializeOnLoad]
    public sealed class AndroidOrientationEditor
    {
        static AndroidOrientationEditor() =>
            EditorApplication.update += UpdateOrientation;

        private static void UpdateOrientation()
        {
            if (EditorUserBuildSettings.development)
            {
                if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.LandscapeRight)
                    PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeRight;
            }
            else
            {
                if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.LandscapeLeft)
                    PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
            }
        }
    }
}
#endif
