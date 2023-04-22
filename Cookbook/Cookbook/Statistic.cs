﻿namespace Cookbook
{
    public class Statistic
    {
        public Statistic()
        {
            this.CountRates = 0;
            this.SumRates = 0;
        }
        public int CountRates {  get; private set; }
        public int SumRates { get; private set; }
        public float AverangeRate 
        {
            get
            {
                if (this.CountRates != 0)
                {
                    return this.SumRates / this.CountRates;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddRate(int rate)
        {
            this.CountRates++;
            this.SumRates += rate;
        }
    }
}
