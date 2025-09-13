#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

public class iOSFrameworkAdder
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        if (target != BuildTarget.iOS)
            return;

        string projPath = PBXProject.GetPBXProjectPath(path);
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(projPath);

#if UNITY_2019_3_OR_NEWER
        string targetGUID = proj.GetUnityMainTargetGuid();
#else
        string targetGUID = proj.TargetGuidByName("Unity-iPhone");
#endif

        // ✅ Add Required Frameworks
        proj.AddFrameworkToProject(targetGUID, "AdSupport.framework", false);
        proj.AddFrameworkToProject(targetGUID, "AppTrackingTransparency.framework", false);
        proj.AddFrameworkToProject(targetGUID, "CoreTelephony.framework", false);
        proj.AddFrameworkToProject(targetGUID, "MessageUI.framework", false);
        proj.AddFrameworkToProject(targetGUID, "StoreKit.framework", false);

        // ✅ Recommended: Enable Objective-C Exceptions
        proj.AddBuildProperty(targetGUID, "GCC_ENABLE_OBJC_EXCEPTIONS", "YES");

        // ✅ Save the changes
        proj.WriteToFile(projPath);
    }
}
#endif
