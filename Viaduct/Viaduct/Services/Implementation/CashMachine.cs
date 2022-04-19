using Stateless;
using Viaduct.Enums;

namespace Viaduct.Services.Implementation
{
    public class CashMachine : ICashMachine
    {
        private static StateMachine<CashState, TriggerCashState> _cashMachine =
            new StateMachine<CashState, TriggerCashState>(CashState.Unchecked);

        private CashState _cashState;
        
        public CashMachine(StateMachine<CashState, TriggerCashState> cashMachine)
        {
            _cashMachine = cashMachine;
            
            _cashMachine.Configure(CashState.Unchecked)
                .Permit(TriggerCashState.CompareWithPreviousDay, CashState.Open);

            _cashMachine.Configure(CashState.Open)
                .Permit(TriggerCashState.CloseDay, CashState.Closed)
                .Ignore(TriggerCashState.NewOperation);

            _cashMachine.Configure(CashState.Closed)
                .Permit(TriggerCashState.OpenDayAgain, CashState.Open);
        }

        public CashState CashMachineState
        {
            get => _cashState;
            private set
            {
                if (value != _cashState)
                {
                    _cashState = value;
                }
            }
        }

        public void ChangeCashState(TriggerCashState triggerCashState)
        {
            _cashMachine.Fire(triggerCashState);
            CashMachineState = _cashMachine.State;
        }
    }
}