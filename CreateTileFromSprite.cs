using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

    class CreateTileFromSprite
    {
        [MenuItem("Assets/Create Tile From Sprite")]
        static void CreateTile()
        {
            foreach (Object o in Selection.objects)
            {

                if (o.GetType() != typeof(Sprite))
                {
                    Debug.LogError("This isn't a sprite: " + o);
                    continue;
                }

                Debug.Log("Creating tile from: " + o);

                Sprite selected = o as Sprite;

                Tile newTile = ScriptableObject.CreateInstance("Tile") as Tile; 
                newTile.sprite = selected;


                string savePath = AssetDatabase.GetAssetPath(selected);
                savePath = savePath.Substring(0, savePath.LastIndexOf('/') + 1);
                string newAssetName = savePath + "t_" + selected.name + ".asset";
                AssetDatabase.CreateAsset(newTile, newAssetName);
                AssetDatabase.SaveAssets();
                Debug.Log("Done!");
            } 
        }
    }
