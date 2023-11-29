using System;
using System.Collections;
using UnityEngine;

namespace RpgProject.Framework.Thread
{
    public class ThreadedRedundantTask
    {
        public int ms;
        public string identifier;
        private bool hasBeenStopped;

        /// <summary>
        /// The Start function starts a new thread.
        /// </summary>
        public void Start()
        {
           // RpgClass.LOGGER.Log($"Attempting to start the thread @{identifier}");
            hasBeenStopped = false;
            RpgClass.instance.StartCoroutine(RunTask());
            RpgClass.LOGGER.Log($"Thread @{identifier} has been started");
        }

        /// <summary>
        /// The function "Stop" attempts to stop a thread and logs the result.
        /// </summary>
        public void Stop()
        {
            RpgClass.LOGGER.Log($"Attempting to stop the thread @{identifier}");
            hasBeenStopped = true;
            RpgClass.instance.StopCoroutine(RunTask());
            RpgClass.LOGGER.Log($"Thread @{identifier} has been stopped");
        }

        public ThreadedRedundantTask(string identifier,int ms)
        {
            this.ms = ms;
            this.identifier = identifier;
        }

        public IEnumerator RunTask()
        {
            while(!hasBeenStopped)
            {
                Update();
                yield return new WaitForSeconds((float) this.ms / 1000);
            }
            yield return null;
        }
        public virtual void Update() {}
    }
}