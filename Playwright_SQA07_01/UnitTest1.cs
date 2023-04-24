using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Playwright_SQA07_01
{
    [TestFixture]
    public class Tests : PageTest
    {

        [SetUp]       
        public async Task Setup()
        {
            ContextOptions();

            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            // Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = @"trace/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString() + ".zip"
            });

            await Context.CloseAsync();
            await Browser.CloseAsync();
        }

        [Test]
        public async Task TestCase_001()
        {
            await Page.GotoAsync("https://adactinhotelapp.com/");

           await Page.FillAsync("#username", "AmirImam");
           await Page.FillAsync("#password", "AmirImam");
           await Page.ClickAsync("#login");
           
           await Page.CloseAsync();
        }


        [Test]
        public async Task TestCase_001_demoQA()
        {

            await Page.GotoAsync("https://demoqa.com/text-box");

            await Page.GetByPlaceholder("name@example.com").FillAsync("amir@imam.com");
          
            await Page.CloseAsync();
        }


        [Test]
        public async Task TestCase_001_Video()
        {
            await Page.GotoAsync("https://adactinhotelapp.com/");

            await Page.FillAsync("#username", "AmirImam");
            await Page.FillAsync("#password", "AmirImam");
            await Page.ClickAsync("#login");

            await Page.CloseAsync();
        }

        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                RecordVideoDir = @"videos/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString(),
                //  StorageStatePath = @"state\pagetest_state.json",
                ViewportSize = new ViewportSize
                {
                    Height = 1080,
                    Width = 1280
                },
                RecordVideoSize = new RecordVideoSize
                {
                    Height = 1080,
                    Width = 1280
                }
            };
        }
    }
}