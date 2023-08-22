using System.Collections.Generic;
using AFSInterview.Game.Combat.Enums;
using AFSInterview.Game.Units.Logic;

namespace AFSInterview.Game.Combat.Logic
{
    public interface IArmy
    {
        ArmySymbol ArmySymbol { get; }
        List<IUnit> Units { get; }
        bool IsAnyoneAlive { get; }

        void RemoveUnit(IUnit unit);
        void RemoveUnits();
        IUnit GetRandomUnit();
        bool HasUnit(IUnit unit);
    }
}