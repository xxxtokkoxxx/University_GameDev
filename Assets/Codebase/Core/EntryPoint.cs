using System.Collections.Generic;
using Codebase.UI;
using UnityEngine;

namespace Codebase.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private List<BaseViw> _viws;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
        }
    }
}