using Viaduct.Enums;

namespace Viaduct.Services
{
    public interface ICashMachine
    {
        CashState CashMachineState { get; }
        void ChangeCashState(TriggerCashState triggerCashState);
    }
}