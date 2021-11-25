using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;


namespace RGemEffectPlugin
{

    public class CameraController : MonoBehaviour
    {
        [Range(1.0f, 100.0f)]
        private float rotYawRatio = 12.0f;
        [Range(1.0f, 100.0f)]
        private float rotPitchRatio = 12.0f;
        [Range(0.1f, 10.0f)]
        private float moveDistRatio = 0.5f;

        [SerializeField]
        public bool autoMove = false;
        [Range(-20.0f, 20.0f)]
        public float autoRotSpeed = -6.0f;

        public float limitUpPitch = 60.0f;
        public float limitDownPitch = -50.0f;

        public float dist = 2.3f;
        public float yaw = 180.0f;
        public float pitch = 20.0f;

        private Vector3 prevMousePos;
        private bool isDragging = false;


        private float restoreFocusDist = 5.0f;

        public int autoFocusMode = 1;

        public void ChangeAutoFocusMode(int mode)
        {
            autoFocusMode = mode;

    //        Debug.Log("autofocus mode = " + mode);
        }

        public void EnableAutoMove(bool enable)
        {
            this.autoMove = enable;
        }

        void Awake()
        {
            autoFocusMode = 1;
            prevMousePos = Vector3.zero;

 //           DontDestroyOnLoad(gameObject);

            var ppb = Camera.main.GetComponent<PostProcessingBehaviour>();
            if (ppb)
            {
                restoreFocusDist = ppb.profile.depthOfField.settings.focusDistance;
            }
        }

        // Use this for initialization
        void Start()
        {
            onChangeCamera();
        }

        void OnApplicationQuit()
        {
            var ppb = Camera.main.GetComponent<PostProcessingBehaviour>();
            if (ppb)
            {
                var settings = ppb.profile.depthOfField.settings;
                settings.focusDistance = restoreFocusDist;
                ppb.profile.depthOfField.settings = settings;
            }
        }

        void Update()
        {
            bool isLeftDown = Input.GetMouseButton(0);
            bool isRightDown = Input.GetMouseButton(1);

            bool isMouseButtonDown = Input.GetMouseButtonDown(0);

            if (isMouseButtonDown)
            {
                onCheckGemSelectMode();
            }

//            bool isMoveGemMode = Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift);
 //           bool isMoveGemMode = gemControlMode;

            // !!!!!!!!宝石移動を無効
            //           isMoveGemMode = false;
            // !!!!!!!!宝石移動を無効

            Vector3 mousePosition = Input.mousePosition;

            bool changeCamera = true;

            // カメラ距離の変更
            if (isRightDown && !gemControlMode)
            {
                dist -= (mousePosition.y - prevMousePos.y) * Time.deltaTime * moveDistRatio;

                const float limitNearDist = 0.25f;
                const float limitFarDist = 20.0f;
                if (dist < limitNearDist)
                {
                    dist = limitNearDist;
                }
                if(dist > limitFarDist)
                {
                    dist = limitFarDist;
                }

                changeCamera = true;
            }

            // カメラの回転
            if (isLeftDown && !gemControlMode)
            {
                if (!this.isDragging)
                {
                    // set previous mouse position to current position.
                    prevMousePos.x = mousePosition.x;
                    prevMousePos.y = mousePosition.y;
                }

                float mouseX = mousePosition.x - prevMousePos.x;
                float mouseY = mousePosition.y - prevMousePos.y;

                pitch -= mouseY * Time.deltaTime * rotPitchRatio;
                yaw += mouseX * Time.deltaTime * rotYawRatio;

                if (pitch >= limitUpPitch)
                {
                    pitch = limitUpPitch;
                }
                else if (pitch < limitDownPitch)
                {
                    pitch = limitDownPitch;
                }

                if (yaw >= 360.0f)
                {
                    yaw -= 360.0f;
                }
                else if (yaw < 0.0f)
                {
                    yaw += 360.0f;
                }

                changeCamera = true;
            }

            // 自動回転
            if(autoMove && !gemControlMode)
            {
                yaw += Time.deltaTime * autoRotSpeed;
                if (yaw >= 360.0f)
                {
                    yaw -= 360.0f;
                }
                else if (yaw < 0.0f)
                {
                    yaw += 360.0f;
                }

                changeCamera = true;
            }

            // 剛体処理
            if(gemControlMode)
            {
                onControlGem();
            }

            if (changeCamera)
            {
                onChangeCamera();
            }

            this.isDragging = isLeftDown;
            this.prevMousePos = mousePosition;
        }

        private Rigidbody moveTargetGem = null;
        private Vector3 controlGemPosition = Vector3.zero;
 //       private Vector3 dragBeginMousePos = Vector3.zero;
        private bool gemControlMode = false;
        private bool storeGravityState = false;

        private void onCheckGemSelectMode()
        {
            bool isBegin = Input.GetMouseButtonDown(0);
            if (!isBegin)
                return;

            bool isToggleGravity = Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift);

            RaycastHit hit;
            Ray ray;


            int gemLayerMask = LayerMask.GetMask("Gem");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 50.0f, gemLayerMask))
            {
                moveTargetGem = hit.rigidbody;

                if (isToggleGravity)
                {
                    moveTargetGem.useGravity = !moveTargetGem.useGravity;
                }

                storeGravityState = moveTargetGem.useGravity;
                moveTargetGem.useGravity = false;

//                dragBeginMousePos = Input.mousePosition;
                controlGemPosition = hit.rigidbody.transform.position;


                gemControlMode = true;
            }
        }

        [Range(0.1f, 10.0f)]
        public float forceRatio = 1.5f;

        private void onControlGem()
        {
            bool isEnd = Input.GetMouseButtonUp(0);
            bool isMoving = Input.GetMouseButton(0);

            /*
            if (Input.GetKeyDown(KeyCode.G))
            {
                storeGravityState = !storeGravityState;
 //               Debug.Log("change gravity state : " + storeGravityState);
            }
            */

            if (isMoving && this.moveTargetGem!=null)
            {
                var mousePos = Input.mousePosition;
//                mousePos.z = this.moveTargetGem.transform.position.z;
              //   mousePos.z = Camera.main.transform.position.z;
                var rayDist = 50.0f;
                mousePos.z = rayDist;

                var wPos = Camera.main.ScreenToWorldPoint(mousePos);
 //               Debug.Log(wPos.ToString()+", "+ Camera.main.transform.position.z);

                //                this.moveTargetGem.AddForce()

                //                this.moveTargetGem.MovePosition(wPos);

                // 位置を移動させてみる
                var cameraUp = Camera.main.transform.up;
                var cameraRight = Camera.main.transform.right;

                var cameraPos = Camera.main.transform.position;


                //                Debug.DrawLine(moveTargetGem.transform.position, wPos, Color.blue);
                Debug.DrawLine(cameraPos, wPos, Color.blue);

                // マウスの移動をラインで表示
  //              Debug.DrawLine(cameraPos, controlGemPosition, Color.blue);


                ///////////////
                // カメラから操作対象のオブジェクトまでの距離を取得

                var distCameraFromGem = Vector3.Distance(controlGemPosition, cameraPos);
                var lerpPos = Vector3.Lerp(cameraPos, wPos, distCameraFromGem / rayDist);
//                vecMouse = vecMouse.normalized * distCameraFromGem;  // 宝石までの距離を乗算

 //               Debug.DrawLine(cameraPos, vecMouse, Color.yellow);
                Debug.DrawLine(cameraPos, lerpPos, Color.yellow);

                // 剛体を使わずに移動
                //                this.moveTargetGem.MovePosition(lerpPos);

                // 剛体を使って力を加える
                Vector3 vDist = lerpPos - moveTargetGem.transform.position;
//                force = force.normalized * forceRatio * (distCameraFromGem*0.5f);
                Vector3 force = vDist * forceRatio * (distCameraFromGem);


         //       this.moveTargetGem.AddForce(force, ForceMode.Impulse);
                this.moveTargetGem.AddForceAtPosition(force, vDist*0.2f);

                //             this.moveTargetGem.rigidbody.

            }

            // ボタンを離した
            if (isEnd)
            {
                moveTargetGem.useGravity = storeGravityState;
                if(!moveTargetGem.useGravity)
                {
                    /*
                    moveTargetGem.velocity *= 0.25f;
                    moveTargetGem.angularVelocity *= 0.25f;
                    */

                }

                this.moveTargetGem = null;
                gemControlMode = false;
            }

        }

        private void onChangeCamera()
        {
            /*
            // 注視点
            var vCenter = new Vector3(3, 0, 0);
            var mCenter = Matrix4x4.identity;
            mCenter.SetTRS(vCenter, Quaternion.identity, Vector3.one);
            */
            transform.rotation = Quaternion.Euler(0f, 0f, 1f);
            transform.position.Set(0.0f, -1.0f, 10f);

            transform.Rotate(pitch, yaw, 0, Space.World);
            transform.position = -transform.forward * dist;
            transform.position -= transform.up * 0.15f;

            var ppb = Camera.main.GetComponent<PostProcessingBehaviour>();
            if (ppb)
            {
                if(autoFocusMode != 2) {
                    RaycastHit hit;
                    Ray ray;

                    var point = Input.mousePosition; // if(autoFocusMode == 1)

                    if (autoFocusMode == 0)
                    {
                        int wCenter = Screen.width / 2;
                        var hCenter = Screen.height / 2;
                        point = new Vector3(wCenter, hCenter, 0.0f);
                    }

                    int gemLayerMask = LayerMask.GetMask("Gem", "Table");
//                    int gemLayerMask = LayerMask.GetMask("Gem");

                    ray = Camera.main.ScreenPointToRay(point);

                    if (Physics.Raycast(ray, out hit, 50.0f, gemLayerMask))
                    {
                        Transform objHit = hit.transform;

                        float dist = Vector3.Distance(objHit.position, transform.position);
                    
                        var settings = ppb.profile.depthOfField.settings;

                        float lerpDist = Mathf.Lerp(settings.focusDistance, dist, 0.05f);

//                        settings.focusDistance = dist;
                        settings.focusDistance = lerpDist;
                        ppb.profile.depthOfField.settings = settings;
                    }
                }



            }

        }
    }
}