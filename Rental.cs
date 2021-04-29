using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRent_Camera
{
    class Rental
    {
        //Data Member 
        private int RegNo;
        private string Merk;
        private string Model;
        private double Price;

        //Accessor function

        public int theRegNo
        {
            get
            {
                return this.RegNo;
            }
            set
            {
                this.RegNo = value;
            }
        }
        public string theMerk
        {
            get
            {
                return this.Merk;
            }
            set
            {
                this.Merk = value;
            }
        }
        public string theModel
        {
            get
            {
                return this.Model;
            }
            set
            {
                this.Model = value;
            }
        }
        public double thePrice
        {
            get
            {
                return this.Price;
            }
            set
            {
                this.Price = value;
            }
        }
    }
}

class uCustomer
{
    //Member Identitiy 
    private int IdUser;
    private int CustId;
    private string CustName;
    private string CustAdd;
    private int CustPhone;

    //Accessor Function
    public int theIdUser
    {
        get
        {
            return this.IdUser;
        }
        set
        {
            this.IdUser = value;
        }
    }
    public int theCustId
    {
        get
        {
            return this.CustId;
        }
        set
        {
            this.CustId = value;
        }
    }
    public string theCustName
    {
        get
        {
            return this.CustName;
        }
        set
        {
            this.CustName = value;
        }
    }
    public string theCustAdd
    {
        get
        {
            return this.CustAdd;
        }
        set
        {
            this.CustAdd = value;
        }
    }
    public int theCustPhone
    {
        get
        {
            return this.CustPhone;
        }
        set
        {
            this.CustPhone = value;
        }
    }
}

class uRent
{
    //variable 
    private int RentDate;
    private int ReturnDate;
    private int RentFee;
    private int Days;

    public int theRentDate
    {
        get
        {
            return this.RentDate;
        }
        set
        {
            this.RentDate = value;
        }
    }
    public int theReturnDate
    {
        get
        {
            return this.ReturnDate;
        }
        set
        {
            this.ReturnDate = value;
        }
    }
    public int theRentFee
    {
        get
        {
            return this.RentFee;
        }
        set
        {
            this.RentFee = value;
        }
    }
    public int theDays
    {
        get
        {
            return this.Days;
        }
        set
        {
            this.Days = value;
        }
    }
}

