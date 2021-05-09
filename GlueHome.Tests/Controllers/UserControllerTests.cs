using NUnit.Framework;
using Moq;
using GlueHome.Controllers;
using Microsoft.Extensions.Logging;
using GlueHome.Domain.UserServices;
using System.Threading.Tasks;
using GlueHome.Model.Users;

namespace GlueHome.Tests.Controller
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IUserService> userService;
        private Mock<ILogger<UserController>> logger;
        private UserController userController;

        [SetUp]
        public void Init()
        {
            userService = new Mock<IUserService>();
            logger = new Mock<ILogger<UserController>>();

            userController = new UserController(userService.Object, logger.Object);
        }

        [Test]
        public async Task GetDeliveries_Should_Get_List_Of_Deliveries()
        {
            var signin = new SignIn
            {
                EmailAddress = "test@test.com",
                Password = "testpass"
            }; 

            userService.Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Login
            {
                Id = 1,
                Token = "Test"
            });

            var result = await userController.Login(signin);

            Assert.IsNotNull(result);
        }
    }
}
