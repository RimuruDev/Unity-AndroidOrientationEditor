# Android Orientation Editor

This Unity editor script automatically sets the default screen orientation for Android builds based on whether the "Development Build" checkbox is selected in the build settings.

## Overview

The script ensures that when a developer is working with an Android project in Unity:

- **If "Development Build" is enabled**: the orientation is set to `LandscapeRight`.
- **If "Development Build" is disabled**: the orientation is set to `LandscapeLeft`.

This helps streamline testing workflows by providing an automatic change in orientation based on the build type.

## How It Works

1. The script listens to the Unity Editor's update event using `EditorApplication.update`.
2. It checks the current state of the "Development Build" checkbox using `EditorUserBuildSettings.development`.
3. Based on the state of the checkbox:
    - If **enabled**, the default orientation is set to `LandscapeRight`.
    - If **disabled**, the default orientation is set to `LandscapeLeft`.

### Code Example

```csharp
#if UNITY_EDITOR && UNITY_ANDROID
using UnityEditor;

namespace AbyssMoth
{
    [InitializeOnLoad]
    [HelpURL("https://github.com/RimuruDev/Unity-AndroidOrientationEditor")]
    public sealed class AndroidOrientationEditor
    {
        static AndroidOrientationEditor() =>
            EditorApplication.update += UpdateOrientation;

        private static void UpdateOrientation()
        {
            if (EditorUserBuildSettings.development)
            {
                if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.LandscapeRight)
                    PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeRight;
            }
            else
            {
                if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.LandscapeLeft)
                    PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
            }
        }
    }
}
#endif
```

## Installation

You can install the Android Orientation Editor package via Unity Package Manager using a Git URL or by downloading the package from the releases.

### Option 1: Installing via Git URL

1. Open **Unity** and go to **Window** -> **Package Manager**.
2. Click the **+** button in the top left corner and select **Add package from git URL...**.
3. Enter the following URL:``` https://github.com/RimuruDev/Unity-AndroidOrientationEditor.git ```
4. Unity will download and install the package automatically.

### Option 2: Installing from Release

1. Go to the [Releases](https://github.com/RimuruDev/Unity-AndroidOrientationEditor/releases) section of this repository.
2. Download the latest `.unitypackage` file.
3. In Unity, go to **Assets** -> **Import Package** -> **Custom Package...** and select the downloaded `.unitypackage`.
4. Click **Import** to install the package.

## Requirements

- Unity 2020.1 or higher.
- The project must target the **Android** platform.
- The script only works inside the Unity Editor and does not affect the final build process.

## Use Case

This script is ideal for developers who need to test their Android game in a different orientation during development but prefer a different default orientation for the release build. By automating the orientation switch, the workflow becomes more efficient and reduces the need for manual changes in Player Settings.

## License

This script is provided under the MIT License. Feel free to modify and distribute it as needed.