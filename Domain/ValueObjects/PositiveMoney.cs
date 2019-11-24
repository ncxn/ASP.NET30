using System;
using System.Collections.Generic;
using System.Text;
using Domain.Events;
using Domain.Notification;

namespace Domain.ValueObjects
{
    public readonly struct PositiveMoney
    {
        private readonly Money _value;

        public PositiveMoney(decimal value)
        {
            if (value < 0)
            {
                //new RaiseEvent(new DomainNotification(value.GetType(), error.ErrorMessage));
            }

            _value = new Money(value);
        }

        public Money ToMoney() => _value;

        internal PositiveMoney Add(PositiveMoney positiveAmount)
        {
            return _value.Add(positiveAmount._value);
        }

        internal Money Subtract(PositiveMoney positiveAmount)
        {
            return _value.Subtract(positiveAmount._value);
        }
    }
}