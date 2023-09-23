using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CerenityStudio
{
    public class csLicense : EditorWindow
    {
        GUISkin skin;
        Vector2 rect = new Vector2(390, 300);
        Texture2D m_Logo;

        [MenuItem("Cerenity Studio/About Framework %F1", false, 9010)]
        public static void CreateNewCharacter()
        {
            GetWindow<csLicense>();
        }

        void OnEnable()
        {
            m_Logo = Resources.Load("Icons/csIcon") as Texture2D;
        }

        void OnGUI()
        {
            if (!skin) skin = Resources.Load("Skin/csSkin") as GUISkin;
            GUI.skin = skin;

            this.maxSize = rect;
            this.minSize = rect;
            this.titleContent = new GUIContent("About", null, "Cerenity Studio Framework");
            GUILayout.BeginVertical(" Cerenity Studio Framework", "window");
            GUILayout.FlexibleSpace();

            GUILayout.Label(m_Logo, GUILayout.MaxHeight(25));

            GUILayout.Space(10);

            GUILayout.Label("Cerenity Studio Framework is a C# library to speed up Unity-based\n" +
                            "application/game development. This framework is developed \n" +
                            "by Cerenity Studio, for support please contact: \n"+
                            "support@cerenitystudio.com");

            GUILayout.Space(5);

            GUILayout.Label("Special Thanks: Claytoo, SilverFlush, Warnee\n" +
                            "You guys are rocks!");

            GUILayout.Space(5);

            GUILayout.Label("Cerenity Studio Framework ver 2.0 (c) 2020-2023 \n");
        }

    }
}
