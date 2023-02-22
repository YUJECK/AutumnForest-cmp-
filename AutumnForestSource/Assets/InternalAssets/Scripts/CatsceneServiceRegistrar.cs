using AutumnForest.DialogueSystem;
using UnityEngine;

namespace AutumnForest.Catscenes
{
    public sealed class CatsceneServiceRegistrar : MonoBehaviour
    {
        private void Awake()
        {
            GlobalServiceLocator.RegisterService(new DialogueManager());
            GlobalServiceLocator.RegisterService(new PlayerInput());

            GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dialogue.Enable();
        }
    }
}