/************************************************************************************
Filename    :   Win32_RoomTiny_Main.cpp
Content     :   First-person view test application for Oculus Rift
Created     :   18th Dec 2014
Authors     :   Tom Heath
Copyright   :   Copyright 2012 Oculus, Inc. All Rights reserved.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*************************************************************************************/
/// This demo shows a simple control method where additional yaw is handled
/// automatically by virtue of your head being turned in the direction
/// of the required yaw.  It is proportional from the centre-point (which is 
/// straight at the camera) so that there are no disconnects, and your brain 
/// can absorb the continuous process intuitively and naturally.
/// As an example, try tracking the animating cube.

#define   OVR_D3D_VERSION 11
#include "..\Common\Win32_DirectXAppUtil.h"        // DirectX
#include "..\Common\Win32_BasicVR.h"         // Basic VR
#include "..\Common\Win32_ControlMethods.h"  // Control code

//-------------------------------------------------------------------------------------
int WINAPI WinMain(HINSTANCE hinst, HINSTANCE, LPSTR, int)
{
    BasicVR basicVR(hinst);
    basicVR.Layer[0] = new VRLayer(basicVR.HMD);

    // Main loop
    while (basicVR.HandleMessages())
    {
        basicVR.ActionFromInput(1,false);
        basicVR.Layer[0]->GetEyePoses();

        // Set auto yaw into camera
        basicVR.MainCam->Rot = GetAutoYawRotation(basicVR.Layer[0]);
 
        for (int eye = 0; eye < 2; eye++)
        {
            basicVR.Layer[0]->RenderSceneToEyeBuffer(basicVR.MainCam, basicVR.pRoomScene, eye);
        }

        basicVR.Layer[0]->PrepareLayerHeader();
        basicVR.DistortAndPresent(1);
    }
    return (basicVR.Release(hinst));
}
