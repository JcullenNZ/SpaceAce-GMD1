
using UnityEditor;
using UnityEngine;

public class ResetMetadata
{
    [MenuItem("Tools/Reimport All Assets")]
    private static void ReimportAll()
    {
        string[] assetPaths = AssetDatabase.GetAllAssetPaths();
        for (int i = 0; i < assetPaths.Length; i++)
        {
            if (i % 50 == 0)
                EditorUtility.DisplayProgressBar("Reimporting Assets", $"Reimporting asset {i}/{assetPaths.Length}", (float)i / assetPaths.Length);
            
            AssetDatabase.ImportAsset(assetPaths[i], ImportAssetOptions.ForceUpdate);
        }
        EditorUtility.ClearProgressBar();
    }
}

