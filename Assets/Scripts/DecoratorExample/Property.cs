using System;

namespace Assets.Scripts.DecoratorExample
{
    public class Property
    {
        private int _value;

        public Property(int value)
        {
            Value = value;
        }

        public int Value
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _value = value;
            }
        }
    }
}