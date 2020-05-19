using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface OrderSubmitted
    {
        public Guid OrderId { get; }
        public DateTime TimeStamp { get; }
        public string Name { get; }
    }
}
