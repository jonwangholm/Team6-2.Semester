using Budweg;
using Budweg.MVVM.ViewModels.Persistence;
using Budweg.MVVM.Models;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;

namespace BudwegTest
{
    [TestClass]
    public class UnitTest1
    {
        Employee e1,e2;
        EmployeeRepository er1;

        [TestInitialize]
        public void Init()
        {
            // ARRANGE
            e1 = new Employee("Henrik", "henrik@hotmail.com", false);
            e2 = new Employee("YesMan", "yes@hotmail.com", false);
            er1 = new EmployeeRepository();
        }

        [TestMethod]
        public void TestRetrieve()
        {
            //ACT
            Employee employeeMail = er1.GetEmployeeId("jimmy@gmail.com");

            //ASSERT
            Assert.AreEqual("jimmy@gmail.com", employeeMail.Email);
        }

        [TestMethod]
        public void TestCreate()
        {

            //ACT
            er1.Create(e1);

            Employee employeeCreate = er1.GetEmployeeId(e1.Email);

            //Delete to avoid duplication in database
            er1.Delete(e1);

            //ASSERT
            Assert.AreEqual("Henrik", employeeCreate.Name);
        }

        [TestMethod]
        public void TestDelete()
        {
            //ACT
            er1.Create(e2);

            //ACT
            er1.Delete(e2);

            //ACT
            Employee employee = er1.GetEmployeeId(e2.Email);

            //ASSERT
            Assert.IsNull(employee);
        }
    }
}