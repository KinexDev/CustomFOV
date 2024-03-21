using BepInEx;
using POKModManager;

namespace CustomFOV
{
    [BepInPlugin("Data.CustomFOV", "CustomFOV", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public void Start()
        {
            CustomFOV fovMod = new CustomFOV();
            POKManager.RegisterMod(fovMod, "Custom FOV", "1.0.0", "Mod which allows changing fov over the limit", nameof(fovMod.fov));
        }
    }
}
