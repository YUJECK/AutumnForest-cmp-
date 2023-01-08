using AutumnForest.Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    public class Dialogue : MonoBehaviour, ICreatureComponent
    {
        [field: SerializeField] private new string name { get; private set; } = "Somebody";
        [field: SerializeField, TextArea(2, 20)] private string[] phrases { get; private set; }

        private void StartDialogue()
        {

        }
    }
}