using System;

namespace Contracts
{
    public interface SubmitOrder
    {
        public Guid Id { get; }
        public string Name { get; }
        public DateTime Timestamp { get; set; }
    }

    public interface SubmittedOrderAccecpted
    {
        public Guid Id { get; }
        public string Name { get; }
        public DateTime Timestamp { get; set; }
    }

    public interface OrderRejected
    {
        public string Reason { get; set; }
    }
}
