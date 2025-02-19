﻿namespace _Sources.Scripts.Interfaces
{
    public interface IStats
    {
        float CurrentStat { get; }
        float MaxStat { get; }
        float GetCurrentStat();
        void SetMaxStat(float maxValue);
        void DecreaseStat(float anount);
        void IncreaseStat(float amount);
    }
}