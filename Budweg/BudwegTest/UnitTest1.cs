using Budweg;
using Budweg.MVVM.ViewModels.Persistence;
using Budweg.MVVM.Models;

namespace BudwegTest
{
    [TestClass]
    public class UnitTest1
    {
        Employee e1;
        EmployeeRepository er1;

        [TestInitialize]
        public void Init()
        {
            // ARRANGE
            e1 = new Employee("Henrik", "henrik@hotmail.com", false);
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
    }
}