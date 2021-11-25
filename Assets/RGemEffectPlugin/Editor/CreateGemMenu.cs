#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System;

namespace RGemEffectPlugin
{
    [CustomEditor(typeof(GemParameters))]
    public class GemParametersInspector : Editor
    {
        public override bool HasPreviewGUI()
        {
            return false;
        }

        public override void OnInspectorGUI()
        {
            var gemParameter = target as GemParameters;

            string GemName = ((GemBinaries.GemType)gemParameter.GemType()).ToString() + " Cut";

            EditorGUILayout.LabelField("Gem Type", GemName);

            base.OnInspectorGUI();
        }
    }

    // Create gem objects command.
    // GameObject->3D Object->RGemEffect->GEM
    public class CustomMenu
    {
        // Create RoundCut
        [MenuItem("GameObject/3D Object/RGemEffect/Round", false, 10)]
        public static void CreateRoundCut(MenuCommand menuCommand)
        {
            CreateGem(GemBinaries.GemType.Round, "RoundCut", menuCommand);
        }



        // Create a gem object.
        private static void CreateGem(GemBinaries.GemType type, string objName, MenuCommand menuCommand)
        {
            var result = GemManager.GetMeshData(type);
            if (result == null)
            {
                Debug.Log("ERROR:Failed to load gem data." + result);
                return;
            }

            GameObject go = new GameObject(objName);

            // add mesh components.
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();

            // add gem parameter class.
            var gem = go.AddComponent<GemParameters>();
            gem.SetGemType((uint)type);
            Debug.Log(GemManager.IsInitialized());
            gem.Setup();

            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}

#endif

