/* 
Lukas Jönsson
14/9-2023
*/

using System;
namespace Solution_Assignment_3;


/*
BodyMassIndexCalculator class
*/
public class BodyMassIndexCalculator
{
    /*
    The private attributes
    */
    private string name = "Unknown";
    private double height = 0;
    private double weight = 0;
    private UnitTypes unit;


    /*
    Properties combine Get and Set methods for an attribute, this approach is more
    efficient compared to use multiple methods for Get and Set an attribute. Since
    there is additional logic this approach is not 'Automatic Properties' which
    according to the code quality standards should be avoided
    https://www.w3schools.com/cs/cs_properties.php
    */

    /*
    Property with methods for Get and Set 'name'
    */
    public string Name
    {
        get { return name; }
        set
        {
            /*
            If the 'value' is not null or empty then
            set the attribute 'name' equal the 'value'
            */
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }
    }

    /*
    Property with methods for Get and Set 'height'
    */
    public double Height
    {
        get { return height; }
        set
        {
            // The 'value' (height) need to be greater than '0'
            if (value > 0)
            {
                if (Unit == UnitTypes.Metric)
                {
                    height = (value / 100); // centimeter to meters
                } else
                {
                    height = (value * 12); // feet to inches
                }
            }
        }
    }

    /*
    Property with methods for Get and Set 'weight'
    */
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
            {
                weight = value;
            }
        }
    }

    /*
    Property with methods for Get and Set 'unit'
    */
    public UnitTypes Unit
    {
        get { return unit; }
        set { unit = value; }
    }

    /*
    Method that calculate the Body Mass Index (BMI)
    */
    public double CalculateBodyMassIndex()
    {
        double bmi;

        if (Unit == UnitTypes.Metric)
        {
            bmi = weight / (height * height);
        } else
        {
            bmi = 703 * weight / (height * height);
        }
        return bmi;
    }

    /*
    Method that return the weight category string based on the BMI
    */
    public string GetBMIWeightCategory()
    {
        double bmi = CalculateBodyMassIndex();
        string weightCategoryString = string.Empty;

        if (bmi < 18.5)
        {
            weightCategoryString = "Underweight";
        } else if (bmi <= 24.9)
        {
            weightCategoryString = "Normal weight";
        } else if (bmi <= 29.9)
        {
            weightCategoryString = "Overweight (Pre-obesity)";
        } else if (bmi <= 34.9)
        {
            weightCategoryString = "Overweight (Obesity class I)";
        } else if (bmi <= 39.9)
        {
            weightCategoryString = "Overweight (Obesity class II)";
        }
        else
        {
            weightCategoryString = "Overweight (Obesity class III)";
        }
        return weightCategoryString;
    }

    /*
    Method that return information about the desired BMI interval
    */
    public string GetBMIInformation()
    {
        return "Normal BMI is between 18.5 and 24.9";
    }

    /*
    Method that return information about the desired weight interval based
    on the BMI result
    */
    public string GetBMIResult()
    {
        double weightResult;
        string unitType;

        if (Unit == UnitTypes.Metric)
        {
            weightResult = (height * height) / 1;
            unitType = "kg";
        }
        else
        {
            weightResult = (height * height) / 703;
            unitType = "lbs";
        }

        double lowerLimit = weightResult * 18.50;
        double higherLimit = weightResult * 24.9;

        // 'ToString("f0") in order to remove all decimal places
        return $"Normal weight should be between {lowerLimit.ToString("f0")} and {higherLimit.ToString("f0")} {unitType}"; ;
    }
}