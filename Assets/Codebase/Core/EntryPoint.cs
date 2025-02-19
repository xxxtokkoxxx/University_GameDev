using System.Collections.Generic;
using Codebase.Core.StateMachine;
using Codebase.UI;
using UnityEngine;
using VContainer;

namespace Codebase.Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private List<BaseViw> _views;
        private IGameStateMachine _gameStateMachine;
        private IUiService _uiService;

        [Inject]
        public void Inject(IGameStateMachine gameStateMachine, IUiService uiService)
        {
            _uiService = uiService;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            Debug.Log("Start " + _gameStateMachine);
            _gameStateMachine.Initialize();
            List<IView> views = new List<IView>();

            foreach (BaseViw view in _views)
            {
                views.Add(view);
            }

            _uiService.SetViews(views);
            _gameStateMachine.ChangeState<InitialState>();
            _gameStateMachine.ChangeState<MainMenuState>();
        }
    }
}