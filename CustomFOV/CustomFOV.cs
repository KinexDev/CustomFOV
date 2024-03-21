using POKModManager;
using System.Collections;
using UnityEngine;

namespace CustomFOV
{
    class CustomFOV : ModClass
    {
        [POKRange(1, 179)] public int fov { get; set; } = 115;
        public int scene = 0;
        GameObject fovSlider;
        public override void OnEnabled()
        {
            print("Fov mod is enabled.");
            SetupMenu();
        }

        public override void OnDisabled()
        {
            print("Fov mod is disabled.");
            SetupMenu();
        }

        public override void SceneChange(int sceneIndex)
        {
            scene = sceneIndex;
        }

        public void SetupMenu()
        {
            InGameMenu inGameMenu = Object.FindObjectOfType<InGameMenu>();

            if (fovSlider == null)
            {
                fovSlider = inGameMenu.graphicsholder_GO.transform.Find("FOVSlider").gameObject;
            }

            fovSlider.SetActive(!Enabled);
        }

        public override void Start()
        {
            POKManager.instance.StartCoroutine(SetupFOV());
        }

        IEnumerator SetupFOV()
        {
            for (int i = 0; i < 240; i++)
            {
                yield return new WaitForEndOfFrame();
                try
                {
                    if (scene == 1)
                    {
                        GameObject.Find("MainCamera").GetComponent<Camera>().fieldOfView = fov;
                    }
                    else
                    {
                        GameObject.Find("CamY").GetComponent<Camera>().fieldOfView = fov;
                    }
                }
                catch
                {
                    yield break;
                }
            }
        }
    }
}
