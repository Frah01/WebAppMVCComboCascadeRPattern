
using CLBusinessLayer;
using CLCommon.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
namespace NUnitTestWebAppComboCascadeRPattern
{
    public class Tests
    {
        [SetUp]
        public void Setup() { 
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
    }
    [Test]
    public async Task TestHomeIndex()
    {
            var _dbContext = new Mock<CorsoAcademyContext>();
            string sQLTestConnection = "Data Source =FRANCESCO; Initial Catalog = CorsoAcademy; Integrated Security = False; User = CorsoAcademy; Password = CorsoAcademy01!; TrustServerCertificate = Yes;";
            var options = new DbContextOptionsBuilder<CorsoAcademyContext>().UseSqlServer(sQLTestConnection);
            
            //Act
            var oBL = new ManageBL(_dbContext.Object);
            // List<TRegione>listRegioni
             var listRegioni = await oBL.getAllRegioniAsync();

            /* var httpCtxStub = new Mock<HttpContextBase>()
             var controllerCtx = new ControllerContext();
             controllerCtx.HttpContext = httpCtxStub.Object;
             controller.ControllerContext = controllerCtx;*/

            //var result = Controller.Index() as ViewResult;
            Assert.IsNotNull(listRegioni, "Should have ruturned a list of regioni");
            Assert.AreEqual(listRegioni.Count, 20, "list of regioni should have been {0}", 20);
            Assert.That(listRegioni.Count == 20, Is.True);
        }
    }
}