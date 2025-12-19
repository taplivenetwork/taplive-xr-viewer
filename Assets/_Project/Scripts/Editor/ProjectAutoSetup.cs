using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace TapLive.Editor
{
    #if UNITY_EDITOR
    /// <summary>
    /// Auto-setup script that runs when Unity opens
    /// Configures project settings and creates necessary folders
    /// </summary>
    [InitializeOnLoad]
    public static class ProjectAutoSetup
    {
        private const string SETUP_KEY = "TapLive_AutoSetup_Done";
        
        static ProjectAutoSetup()
        {
            EditorApplication.delayCall += OnEditorLoaded;
        }

        private static void OnEditorLoaded()
        {
            // Only run once per project
            if (SessionState.GetBool(SETUP_KEY, false))
                return;

            Debug.Log("[ProjectAutoSetup] Running first-time setup...");
            
            // Ensure folders exist
            EnsureFolders();
            
            // Set quality settings
            ConfigureQualitySettings();
            
            // Mark as complete
            SessionState.SetBool(SETUP_KEY, true);
            
            Debug.Log("[ProjectAutoSetup] Setup complete! Project is ready.");
            Debug.Log("[ProjectAutoSetup] Next: Install OpenXR plugin via Package Manager");
        }

        private static void EnsureFolders()
        {
            string[] folders = new string[]
            {
                "Assets/_Project/Settings",
                "Assets/_Project/Resources",
                "Assets/_Project/Prefabs/UI",
                "Assets/_Project/Prefabs/XR"
            };

            foreach (var folder in folders)
            {
                if (!AssetDatabase.IsValidFolder(folder))
                {
                    string parent = System.IO.Path.GetDirectoryName(folder).Replace("\\", "/");
                    string name = System.IO.Path.GetFileName(folder);
                    AssetDatabase.CreateFolder(parent, name);
                }
            }
        }

        private static void ConfigureQualitySettings()
        {
            // Set default quality to High for VR
            QualitySettings.SetQualityLevel(2, true);
            
            // VR-optimized settings
            QualitySettings.vSyncCount = 0; // Disable VSync for VR
            QualitySettings.antiAliasing = 0; // Disable MSAA (use single-pass instanced instead)
        }

        [MenuItem("TapLive/Run Auto-Setup")]
        public static void RunSetupManually()
        {
            SessionState.SetBool(SETUP_KEY, false);
            OnEditorLoaded();
        }

        [MenuItem("TapLive/Open Bootstrap Scene")]
        public static void OpenBootstrapScene()
        {
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/Bootstrap.unity");
        }
    }
    #endif
}
