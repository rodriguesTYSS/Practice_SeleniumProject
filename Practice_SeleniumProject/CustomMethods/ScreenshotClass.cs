using NUnit.Framework;
using System;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;

namespace Practice_SeleniumProject.CustomMethods
{
    public class ScreenshotClass
    {
        // Failed Test Screen capture
        public static void FailedTestCaptureScreenShot(IWebDriver driver, string Scenario)
        {

            try
            {
                // get the path of the currently executing assembly
                string currentPath = Assembly.GetExecutingAssembly().Location;
                // get the directory name of the current assembly
                string directory = Path.GetDirectoryName(currentPath);
                DirectoryInfo info = new DirectoryInfo(directory);
                string path = info.Parent.Parent.Parent.FullName;

                Screenshot dd = ((ITakesScreenshot)driver).GetScreenshot();
                string imagename = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                string date = DateTime.Today.ToString("dd-MM-yyyy");

                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().Name);
                // path = path.Substring(6);
                string TestResultLocation = path + "/TestOutput/FailedTests " + date;

                if (Directory.Exists(TestResultLocation) == false)
                {
                    Directory.CreateDirectory(TestResultLocation);
                }
                string localPathName = TestResultLocation + "/" + Scenario;

                if (Directory.Exists(localPathName) == false)
                {
                    Directory.CreateDirectory(localPathName);
                }
                dd.SaveAsFile(localPathName + "/" + imagename + ".png", ScreenshotImageFormat.Png);

            }
            catch (Exception)
            {
                Console.WriteLine("Failed Screensots- failed ");
                Assert.Fail();
                BaseClass bc = new BaseClass();
                bc.CloseTest(driver);
            }
        }
    }
}
