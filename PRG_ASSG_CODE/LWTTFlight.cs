﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//==========================================================
// Student Number	: S10267952A
// Student Name	: Seah Qi Zhen Zoe 
// Partner Name	: Tan Wan Cheng S10266775
//==========================================================

namespace PRG_ASSG_CODE
{
    class LWTTFlight:Flight
    {
        public double RequestFee { get; private set; }

        public LWTTFlight(string flightNumber, string origin, string destination, DateTime expectedTime, string status = "On Time", double requestFee = 500)
            : base(flightNumber, origin, destination, expectedTime, status)
        {
            RequestFee = requestFee;
        }

        public override double CalculateFees()
        {
            return base.CalculateFees() + RequestFee; 
        }

        public override string ToString()
        {
            return base.ToString() + $", Type: LWTT Flight, Fee: {CalculateFees()}";
        }
    }
}

