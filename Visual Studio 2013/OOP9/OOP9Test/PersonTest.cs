using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OOP9Test
{
    public class PersonTest
    {

      public void CanGetAndSetAge(int TestAge, double TestWeight, string TestName)
      {
        //Arrange
        OOP9.Person ps = new OOP9.Person();

        //Act

        //Assert

      }

      [TestCase(9, Result=9)]
      [TestCase(-125, ExpectedExceptionName="Negative")]
      [TestCase(-50, ExpectedExceptionName="Negative")]
      [TestCase(50, Result = 50)]
      [TestCase(23, Result = 23)]
      [TestCase("A", ExpectedMessage = "NotInt")]
      [TestCase("/", ExpectedMessage = "NotInt")]
      public int CannotSetNegativeAge(int TestAge)
      {
        OOP9.Person ps = new OOP9.Person();

        return ps.Age = TestAge;
      }

    }
}
