using LibrePad.Classes;
using UnityEngine;

namespace LibrePad;

public class Handler : MonoBehaviour
{
    public static Handler Instance { get; private set; }
    void Awake() =>
        Instance = this;

    bool initialized;
    void Update()
    {
        if (!initialized && GorillaLocomotion.GTPlayer.Instance != null && VRRig.LocalRig != null && GorillaTagger.Instance != null)
        {
            initialized = true;
            Debug.Log("[LibrePad] Handler initialized, creating Tablet and Notifications...");
            try
            {
                Tablet.InitializeTablet();
                Debug.Log("[LibrePad] Tablet initialized successfully");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LibrePad] Tablet initialization failed: {e}");
            }
            gameObject.AddComponent<Notifications>();
        }
    }
}
