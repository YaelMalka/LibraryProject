using Libary;
using Libary.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryControllerTest
{
    public class BorrowTest
    {
        private readonly FakeContext fakeContext = new FakeContext();
        [Fact]
        public void Get_ReturnList()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה

            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new BorrowController(fakeContext);
            var result = controller.Get();

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<List<Borrow>>(result);
        }
        [Fact]
        public void Get_ReturnCount()
        {


            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new BorrowController(fakeContext);
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
            var controller = new BorrowController(fakeContext);
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
            var controller = new BorrowController(fakeContext);
            var result = controller.Get(id);

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
