using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class VariableTest
{

    string name;
    int power;

    string newName;
    int newPower;

    [OneTimeSetUp]
    public void SetUp()
    {
        name = "Yusuf";
        power = 100;

        newName = "Can";
        newPower = 200;
    }

    [UnityTest, Order(1)]
    public IEnumerator VariableAddTests()
    {

        VariableTestable.Data.name = name;
        VariableTestable.Data.power = power;
        VariableTestable.Save();

        Assert.AreEqual(VariableTestable.Data.name, name);
        yield return null;
    }

    [UnityTest, Order(2)]
    public IEnumerator VariableChangeTests()
    {

        VariableTestable.Data.name = newName;
        VariableTestable.Data.power = newPower;
        VariableTestable.Save();


        Assert.AreEqual(VariableTestable.Data.power, newPower);
        yield return null;
    }


    [UnityTest, Order(3)]
    public IEnumerator VariableDeleteTests()
    {
        VariableTestable.DeleteSave();

        Assert.IsNull(VariableTestable.Data.name);
        yield return null;
    }


    public class VariableTestable : Saveable<VariableTestable>
    {
        public string name;
        public int power;
    }

}
