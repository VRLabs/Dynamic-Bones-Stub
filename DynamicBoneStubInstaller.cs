using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class DynamicBoneStubInstaller
{
	static DynamicBoneStubInstaller()
	{
		bool dbStubPresent = AppDomain.CurrentDomain.GetAssemblies()
			.Any(x => x.GetTypes().Any(x => x.FullName == "DynamicBone"));
		bool anythingInLocation = Directory.Exists( "Assets/DynamicBone/Scripts/");
		if (dbStubPresent && !anythingInLocation)
		{
			EditorUtility.DisplayDialog("Bad Dynamic Bones Install", "Dynamic Bones Found in wrong folder. Please move your Dynamic Bones/Dynamics Bone Stub over to Assets/DynamicBone/Scripts", "Ok");
		}

		if (!dbStubPresent && !anythingInLocation)
		{
			Debug.Log("Importing Dynamic Bones 1.3.2 Stub");
			string[] fikStubLocations = AssetDatabase.FindAssets("Dynamic_Bones_v1.3.2_Stub");
			if (fikStubLocations.Length == 0)
			{
				throw new Exception("Dynamic Bones Stub Package not found");
			}
			AssetDatabase.ImportPackage(AssetDatabase.GUIDToAssetPath(fikStubLocations[0]), false);
		}
	}
}