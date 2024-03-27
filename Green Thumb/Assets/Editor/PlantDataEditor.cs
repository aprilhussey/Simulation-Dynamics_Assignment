using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlantData))]
public class PlantDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
		DrawDefaultInspector();

		PlantData plantData = (PlantData)target;

		EditorGUILayout.LabelField("Growth Stages Initialization", EditorStyles.boldLabel);

        if (GUILayout.Button("Initialize Growth Stages"))
        {
            plantData.growthStages = new GrowthStage[4];

			for (int i = 0; i < plantData.growthStages.Length; i++)
			{
				if (plantData.growthStages[i] == null)
				{
					plantData.growthStages[i] = new GrowthStage();
					plantData.growthStages[i].stage = (GrowthStage.Stage)i;
				}
			}
		}
	}
}
