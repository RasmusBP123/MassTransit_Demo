using Automatonymous;
using Contracts;
using MassTransit.RedisIntegration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Components.StateMachines
{
    //This is the behavior
    public class OrderStateMachine : MassTransitStateMachine<OrderState>
    {
        public OrderStateMachine()
        {
            //So when you use a sage, you need to tell the saga, which id should correlate to the actual message.
            Event(() => OrderSubmitted, x => x.CorrelateById(x => x.Message.OrderId));

            InstanceState(x => x.CurrentState);

            Initially(
                When(OrderSubmitted).TransitionTo(Submitted)
                );
        }

        //This will be the state of the state machine after the OrderSubmitted event fired.
        public State Submitted { get; private set;}

        //Here we are listining to the Publishing of the event in SubmitOrderConsumer
        public Event<OrderSubmitted> OrderSubmitted { get; private set;}
    }

    //This is what gets persisted
    public class OrderState : SagaStateMachineInstance, IVersionedSaga
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public int Version { get; set; }
    }
}
