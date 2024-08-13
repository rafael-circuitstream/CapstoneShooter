using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAmmoType
{
    string AmmoTypeName { get; }


    public class ShrapnelAmmo : IAmmoType
    {
        public string AmmoTypeName => "Shrapnel";
    }

    public class EnergyAmmo : IAmmoType
    {
        public string AmmoTypeName => "Energy";
    }

    public class HeavyAmmo : IAmmoType
    {
        public string AmmoTypeName => "Heavy";
    }
}    

