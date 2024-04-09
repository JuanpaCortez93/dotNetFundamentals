﻿namespace _001_Basics.Services
{
    public class RandomService : IRandomService
    {

        private readonly int _value;

        public int Value { get { return _value; } }

        public RandomService()
        {
            _value = new Random().Next(1000);
        }

    }
}
