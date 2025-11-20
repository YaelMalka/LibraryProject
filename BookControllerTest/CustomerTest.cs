using Libary;
using Libary.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace LibaryControllerTest
{
    public class CustomerTest
    {
        private readonly FakeContext fakeContext= new FakeContext();    
        [Fact]
        public void Get_ReturnList()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה

            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new CustomerController(fakeContext);
            var result = controller.Get();

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<List<Customer>>(result);
        }
        [Fact]
        public void Get_ReturnCount()
        {
           

            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new CustomerController(fakeContext);
            var result = controller.Get();

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.Equal(4, result.Count());
        }
        [Fact]
        public void GetById_ReturnOk()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה
            var id = 2;
            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new CustomerController(fakeContext);
            var result = controller.Get(id);

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה
            var id = 8;
            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new CustomerController(fakeContext);
            var result = controller.Get(id);

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<NotFoundResult>(result);
        }








    }
}