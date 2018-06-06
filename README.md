# NeuLog Unity plugin
A lightweight Unity package to interface with the NeuLog USB respiration belt. 

## Instructions
(Check https://neulog.com/software/ if the direct links below don't work.)
1. Download and install the NeuLog API: https://neulog.com/Downloads/neulog_api_ver_002b.exe
2. Skim through the API User Guide: https://neulog.com/wp-content/uploads/2014/06/NeuLog-API-version-7.pdf
3. From this repo, download `Builds/neulog-unity.unitypackage`
4. Import the downloaded package to your Unity project via `Import Package > Custom Package...`
5. With the NeuLog API running and the `NeulogManager` prefab in your scene, access the latest breath reading from any script with `NeulogManager.Instance.BreathReading`
