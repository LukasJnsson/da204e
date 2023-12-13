/* 
Lukas Jönsson
14/9-2023
*/

using System;
namespace Solution_Assignment_3;


/*
SavingCalculator class
*/
public class SavingCalculator
{
    /*
    The private attributes
    */
    private double monthlyDeposit = 0;
    private int period = 0;
    private const double interestRate = 0.10; // 10% interest rate


    /*
    Property with methods for Get and Set 'monthlyDeposit'
    */
    public double MonthlyDeposit
    {
        get { return monthlyDeposit; }
        set
        {
            if (value > 0)
            {
                monthlyDeposit = value;
            }
        }
    }

    /*
    Property with methods for Get and Set 'period'
    */
    public int Period
    {
        get { return period; }
        set
        {
            if (value > 0)
            {
                period = value;
            }
        }
    }

    /*
    Method that calculate and return the future value
    */
    public double CalculateFutureValue()
    {
        double numberOfMonths = period * 12;
        double futureValue = 0;

        for (int i = 0; i < numberOfMonths; i++)
        {
            double interestEarned = (interestRate * futureValue) / 12;
            futureValue += interestEarned + monthlyDeposit;
        }
        return futureValue;
    }

    /*
    Method that calculate and return the amount paid
    */
    public double CalculateAmountPaid()
    {
        double numberOfMonths = period * 12;
        double amountPaid = monthlyDeposit * numberOfMonths;
        return amountPaid;
    }
}