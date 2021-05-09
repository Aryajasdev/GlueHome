using GlueHome.Data.Context;
using GlueHome.Domain.UserServices;
using GlueHome.Model.Users;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TechnicalInterview.Tests.ServiceTest
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService userService;
        private DeliveryContext context;
        private Mock<IOptions<AppSettings>> appSettings;

        [SetUp]
        public void Init()
        {
            context = TestDataContext.GetContextWithData();
            appSettings = new Mock<IOptions<AppSettings>>();

            appSettings.SetupGet(x => x.Value)
                .Returns(new AppSettings
                {
                    Key = "This_Is_My_Secret_Key"
                });

            userService = new UserService(appSettings.Object, context);
        }

        [Test]
        public async Task Return_Null_if_No_User_Exist()
        {            
            var result = await userService.GetUser(It.IsAny<string>(), It.IsAny<string>());

            Assert.IsNull(result);
        }

        [Test]
        public async Task Return_Login_if_User_Exist()
        {           
            var result = await userService.GetUser("user@test.com", "userpass");

            Assert.IsNotNull(result);
        }
    }
}
