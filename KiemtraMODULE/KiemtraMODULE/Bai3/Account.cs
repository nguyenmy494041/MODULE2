using System;
using System.Collections.Generic;
using System.Text;

namespace KiemtraMODULE.Bai3
{
    public interface IAccount
    {
        public string ShowInfor();
        public void PayInto(float Amount);
    }
    class Account : IAccount
    {
        public int AccountId { get; set; }
        public string Fristname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public float Banlance { get; private set; }

        public void PayInto(float Amount)
        {
            Banlance += Amount;
           
        }   
       
        public string ShowInfor()
        {
            return $"Account ID: {AccountId}\tFrist Name: {Fristname}\tLasrt Name: {Lastname}\tGender: {Gender}\tBanlance: {Banlance}";
        }
    }

}
