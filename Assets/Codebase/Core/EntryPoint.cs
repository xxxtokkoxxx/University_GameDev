using System;
using UnityEngine;

namespace Codebase.Core
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
        }
    }
}