using UnityEngine;
using Zenject;
using TMPro;
using AFSInterview.Game.Combat.Enums;
using AFSInterview.Game.Combat.Logic;
using AFSInterview.Game.Units.Enums;
using AFSInterview.Global.UI;

namespace AFSInterview.Game.Combat.UI
{
    public class HudCombatPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _turnTmp;

        private CombatManager _combatManager;
        
        [Inject]
        private void Construct(CombatManager combatManager)
        {
            _combatManager = combatManager;
            _combatManager.OnMakeTurn += UpdateTurnTmp;
        }

        private void OnDestroy()
        {
            _combatManager.OnMakeTurn -= UpdateTurnTmp;
        }

        private void UpdateTurnTmp(UnitName unitName, ArmySymbol armySymbol)
        {
            _turnTmp.text = $"{unitName} ({armySymbol})";
        }
    }
}