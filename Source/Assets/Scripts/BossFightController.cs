using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    abstract public class BossFightController : MonoBehaviour
    {
        //events
        public UnityEvent onBossFightBegins = new UnityEvent();
        public UnityEvent onBossFightEnds = new UnityEvent();
    
        //abstract methods
        abstract public void StartBossFight();
        abstract public void EndBossFight();
    }
}