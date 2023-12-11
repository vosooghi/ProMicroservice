using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySamples.DesignPattarns.Specification
{
    public class FlightBooking
    {
        public int Id { get; private set; }
        public FlightDate FlightDate { get; private set; }
        public bool IsApproved { get; private set; }
        private readonly ResheduleValidationSatisfied spec = new ResheduleValidationSatisfied();
        public FlightBooking(int id, FlightDate flightDate)
        {

            Id = id;
            FlightDate = flightDate;
        }
        public void Approved()
        {
            IsApproved = true;
        }
        public void ReSchedule(FlightDate newFlightDate)
        {
            if (spec.IsSatisfyBy(this)) throw new InvalidOperationException("Invalid operation");
            FlightDate = newFlightDate;
        }
    }
    public class FlightDate
    {
        public DateTime Value { get; private set; }
        public FlightDate(DateTime value)
        {
            if (DateTime.Now > Value) throw new Exception("Invalid input");
            Value = value;
        }

    }

    public interface ISpecification<T>
    {
        public bool IsSatisfyBy(T entity);
    }
    public class ResheduleValidationSatisfied : ISpecification<FlightBooking>
    {
        public bool IsSatisfyBy(FlightBooking entity)
        {
            return !entity.IsApproved;
        }
    }
}
