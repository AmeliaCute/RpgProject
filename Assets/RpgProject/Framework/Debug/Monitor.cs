using System.IO;
using System;
using UnityEngine;
using System.Collections;

namespace RpgProject.Framework.Debug
{
    public class Monitor : MonoBehaviour
    {
        private const float SpikeThreshold = 30f;
        private const float CheckInterval = 0.05f; // 50ms interval

        private bool isMonitoring = false;

        private void Start()
        {
            StartPerformanceMonitoring();
        }

        private void OnDestroy()
        {
            StopPerformanceMonitoring();
        }

        private void StartPerformanceMonitoring()
        {
            if (!isMonitoring)
            {
                StartCoroutine(MonitorPerformance());
                isMonitoring = true;
            }
        }

        private void StopPerformanceMonitoring()
        {
            if (isMonitoring)
            {
                StopCoroutine(MonitorPerformance());
                isMonitoring = false;
            }
        }

        private IEnumerator MonitorPerformance()
        {
            while (true)
            {
                float currentFrameTime = Time.unscaledDeltaTime * 1000f;

                if (currentFrameTime > SpikeThreshold)
                    RpgClass.RPGLOGGER.Warning("Game has experienced a lag spike, frame time: " + currentFrameTime.ToString("F2") + "ms");
                yield return new WaitForSecondsRealtime(CheckInterval); 
            }
        }
    }
}
