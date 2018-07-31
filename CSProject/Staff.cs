using System;
namespace CSProject
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;
        private string name;
        private float rate;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }

            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }


        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;

        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nhourlyRate = " + hourlyRate + "\nhWorked = " + hWorked
                + "\nBasicPay = " + BasicPay + "\n\nTotalPay = " + TotalPay;
        }
    }


    class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance {get; private set;}


        public Manager(string name) : base(name, managerHourlyRate){}
       
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 0;
            if (HoursWorked >= 160)
            {
                Allowance = 1000;
                TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nmanagerHourlyRate = "
                + managerHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = "
                + BasicPay + "\nAllowance = " + Allowance + "\n\nTotalPay = " + TotalPay;
        }
    }


    class Admin : Staff
    {
        private const float overTimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        public float Overtime {get; private set;}


        public Admin(string name) : base(name, adminHourlyRate) {}

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Overtime = overTimeRate * (HoursWorked - 160);
                TotalPay = BasicPay + Overtime;
            }
                
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\adminHourlyRate = "
                + adminHourlyRate + "\nHoursWorkd = " + HoursWorked + "\nBasicPay = "
                + BasicPay + "\nOvertime = " + Overtime + "\n\nTotalPay = " + TotalPay;
        }

    }


}
