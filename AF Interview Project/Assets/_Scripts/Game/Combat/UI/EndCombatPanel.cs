using UnityEngine;
using Zenject;
using TMPro;
using AFSInterview.Game.Combat.Enums;
using AFSInterview.Game.Combat.Logic;
using AFSInterview.Global.UI;
using UnityEngine.UI;

namespace AFSInterview.Game.Combat.UI
{
    public class EndCombatPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _endTmp;
        [SerializeField] private Button _restartBtn;
        
        private CombatManager _combatManager;
        
        [Inject]
        private void Construct(CombatManager combatManager)
        {
            _combatManager = combatManager;
            
            _combatManager.OnCombatEnd += ShowEndPanel;
            _restartBtn.onClick.AddListener(_combatManager.RestartCombat);
            _restartBtn.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            _combatManager.OnCombatEnd -= ShowEndPanel;
            _restartBtn.onClick.RemoveAllListeners();
        }

        private void ShowEndPanel(ArmySymbol armySymbol)
        {
            _endTmp.text = $"The army with emblem {armySymbol} won!!";
            
            Show();
        }
    }
}