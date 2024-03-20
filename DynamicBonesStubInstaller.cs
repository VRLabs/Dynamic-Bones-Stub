#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;

[InitializeOnLoad]
public class DynamicBonesStubInstaller
{
    static DynamicBonesStubInstaller()
    {
        bool fikStubPresent = AppDomain.CurrentDomain.GetAssemblies()
            .Any(x => x.GetTypes().Any(y => y.FullName == "DynamicBone"));
        bool anythingInLocation = Directory.Exists("Assets/DynamicBone/Scripts");
        if (fikStubPresent && !anythingInLocation)
        {
            
            EditorUtility.DisplayDialog("Bad Dynamic Bones Install", "Dynamic Bones Found in wrong folder. Please move your Dynamic Bones/Dynamic Bones Stub over to Assets/DynamicBone/Scripts", "Ok");
        } 

        if (!fikStubPresent && !anythingInLocation)
        {
            string file = AssetDatabase.FindAssets("DynamicBonesStubInstaller", new[] { "Packages", "Assets" }).Select(AssetDatabase.GUIDToAssetPath).FirstOrDefault();
            
            if (file == null)
            {
                EditorUtility.DisplayDialog("Bad Dynamic Bones Install", "Dynamic Bones Stub not found. Please install Dynamic Bones Stub from the package manager", "Ok");
                return;
            }
            
            string[] files = Directory.GetFiles(Path.GetDirectoryName(file) + "/Scripts", "*.*", SearchOption.AllDirectories);
            CopyFiles(files, "Assets/DynamicBone/");
        }
    }
    

    private static void CopyFiles(string[] files, string finalPath)
    {
        foreach (var file in files)
        {
            if (file.EndsWith(".cs.no"))
            {
                string partialPath = file.Substring(file.IndexOf("Scripts", StringComparison.Ordinal));
                string directory = Path.GetDirectoryName(partialPath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(finalPath + directory);
                }
                
                File.Copy(file, finalPath + partialPath.Replace(".cs.no", ".cs"));
                File.Copy(file.Replace(".cs.no", ".cs.meta.no"), finalPath + partialPath.Replace(".cs.no",".cs.meta"));
            }
        }
    }
}

#endif