using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework7.Models
{
    public class ShopItemViewModel
    {
        //data members
        private string mName;
        private string mDescription;
        private double mAmount;
        private int mQuantityAvailable;

        //Constructor
        public ShopItemViewModel() //empty constructor
        {
            MName = "";
            MDescription = "";
            MAmount = 0.00;
            MQuantityAvailable = 0;
        }
        public ShopItemViewModel(string name, string description, double amount, int quantityAvailable) //parameterised constructor
        {
            MName = name;
            MDescription = description;
            MAmount = amount;
            MQuantityAvailable = quantityAvailable;
        }

        //properties
        public string MName
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public string MDescription
        {
            get
            {
                return mDescription;
            }

            set
            {
                mDescription = value;
            }
        }

        public double MAmount
        {
            get
            {
                return mAmount;
            }

            set
            {
                mAmount = value;
            }
        }

        public int MQuantityAvailable
        {
            get
            {
                return mQuantityAvailable;
            }

            set
            {
                mQuantityAvailable = value;
            }
        }


    }
}