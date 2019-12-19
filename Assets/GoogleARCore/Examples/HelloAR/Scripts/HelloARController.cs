namespace GoogleARCore.Examples.HelloAR
{
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.EventSystems;

#if UNITY_EDITOR
    using Input = InstantPreviewInput;
#endif

    public class HelloARController : MonoBehaviour
    {

        public Camera FirstPersonCamera;
        public GameObject GameObjectVerticalPlanePrefab;
        public GameObject GameObjectHorizontalPlanePrefab;

        public GameObject GameObjectPointPrefab;
        public ScoreKeeper globalScoreKeeper;
        public GameMode gameMode;
        public GyroController gyroController;

        private int currentAge;
        private const float k_PrefabRotation = 180.0f;


        private bool m_IsQuitting;


        public void Awake()
        {
            Application.targetFrameRate = 60;
            currentAge = 0;
        }

        public void Update()
        {
            _UpdateApplicationLifecycle();

            // If the player has not touched the screen, we are done with this update.
            if (gameMode.CurrentMode == Mode.SetUp)
            {
                Touch touch;
                if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
                {
                    return;
                }

                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return;
                }

                TrackableHit hit;
                TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                    TrackableHitFlags.FeaturePointWithSurfaceNormal;

                if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
                {
                    if ((hit.Trackable is DetectedPlane) && Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position, hit.Pose.rotation * Vector3.up) >= 0)
                    {
                        GameObject prefab;
                        bool vertical = false;
                        if (hit.Trackable is DetectedPlane)
                        {
                            DetectedPlane detectedPlane = hit.Trackable as DetectedPlane;
                            if (detectedPlane.PlaneType == DetectedPlaneType.Vertical)
                            {
                                prefab = GameObjectVerticalPlanePrefab;
                                vertical = true;
                            }
                            else
                            {
                                prefab = GameObjectHorizontalPlanePrefab;
                            }
                        }
                        else
                        {
                            prefab = GameObjectHorizontalPlanePrefab;
                        }

                        if (vertical)
                        {
                            var worldObject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                            worldObject.GetComponent<BasketAge>().Age = currentAge++;
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Make game object a child of the anchor.
                            worldObject.transform.parent = anchor.transform;
                            worldObject.transform.Rotate(0, k_PrefabRotation, 0, Space.Self);
                            ScoreTrigger scoreTrigger = worldObject.GetComponentsInChildren(typeof(ScoreTrigger))[0] as ScoreTrigger;
                            scoreTrigger.scoreKeeper = globalScoreKeeper;

                        }
                        else
                        {
                            var worldObject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                            worldObject.GetComponent<BasketAge>().Age = currentAge++;
                            worldObject.transform.Rotate(0, k_PrefabRotation + 45.0f, 0, Space.Self);
                            worldObject.transform.Translate(0, 1.0f, 0);
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Make game object a child of the anchor.
                            worldObject.transform.parent = anchor.transform;
                            ScoreTrigger scoreTrigger = worldObject.GetComponentsInChildren(typeof(ScoreTrigger))[0] as ScoreTrigger;
                            scoreTrigger.scoreKeeper = globalScoreKeeper;
                        }
                    }
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;
                if (Physics.Raycast(ray, out hit2))
                {
                    GameObject hoop = hit2.collider.gameObject;
                    hoop.transform.Translate(new Vector3(.0f, .3f, .0f));
                }
            }
        }

        private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            if (m_IsQuitting)
            {
                return;
            }

            // Quit if ARCore was unable to connect and give Unity some time for the toast to
            // appear.
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError())
            {
                _ShowAndroidToastMessage(
                    "ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }
        private void _DoQuit()
        {
            Application.Quit();
        }
        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity =
                unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject =
                        toastClass.CallStatic<AndroidJavaObject>(
                            "makeText", unityActivity, message, 0);
                    toastObject.Call("show");
                }));
            }
        }

    }

}
