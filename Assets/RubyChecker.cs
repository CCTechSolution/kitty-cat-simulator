using UnityEngine;
using System.Diagnostics;
using System.IO;

public class RubyChecker : MonoBehaviour
{
    void Start()
    {
        UnityEngine.Debug.Log("Running RubyChecker...");

        try
        {
            var process = new Process();
            process.StartInfo.FileName = "ruby";
            process.StartInfo.Arguments = "-v";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrEmpty(output))
                UnityEngine.Debug.Log("Ruby version from Unity: " + output.Trim());
            else if (!string.IsNullOrEmpty(error))
                UnityEngine.Debug.LogError("Error getting Ruby version: " + error.Trim());
            else
                UnityEngine.Debug.LogWarning("No output from Ruby command.");
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError("Exception running RubyChecker: " + ex.Message);
        }
    }
}
