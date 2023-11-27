using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace STTask3
{
    public class Tests
    {
        private bool isfirst = true;
        private string URL;
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [SetUp]
        public void Setup()
        {
            if (isfirst)
            {
                isfirst = false;
                driver = new ChromeDriver();
                string adminUsername = "Admin";
                string adminPassword = "admin123";
                // Navigate to the login page
                driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
                Thread.Sleep(5000);
                driver.FindElement(By.Name("username")).SendKeys(adminUsername);
                driver.FindElement(By.Name("password")).SendKeys(adminPassword);
                driver.FindElement(By.CssSelector("#app > div.orangehrm-login-layout > div > div.orangehrm-login-container > div > div.orangehrm-login-slot > div.orangehrm-login-form > form > div.oxd-form-actions.orangehrm-login-action > button")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
                if (!driver.Url.Contains("dashboard"))
                    throw new Exception("Login failed");
            }
        }

        [Test]
        public void Test1()
        {
            try
            {
                // Replace with actual admin credentials

                // Navigate to Add Employee Page
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-navigation > aside > nav > div.oxd-sidepanel-body > ul > li:nth-child(2) > a > span")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-navigation > header > div.oxd-topbar-body > nav > ul > li:nth-child(3) > a")).Click();
                
                // Add employee details
                string firstName = "Vitold";
                string lastName = "Skuder";
                string middleName = "Kazimierz";
                string Id = "1234";
                //randomise id
                Random rnd1 = new Random();
                int num1 = rnd1.Next(1, 10000);
                Id = num1.ToString();
                string user;
                //randomise user
                Random rnd = new Random();
                int num = rnd.Next(1, 10000);
                user = "user" + num.ToString();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
                driver.FindElement(By.Name("firstName")).SendKeys(firstName);
                driver.FindElement(By.Name("middleName")).SendKeys(middleName); 
                driver.FindElement(By.Name("lastName")).SendKeys(lastName);
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.orangehrm-employee-container > div.orangehrm-employee-form > div:nth-child(1) > div.oxd-grid-2.orangehrm-full-width-grid > div > div > div:nth-child(2) > input")).SendKeys(Id);

                
                // Add an image
                // Assuming you have an image at a known path
                string imagePath = @"C:\Users\skude\Pictures\Images\OOP3P3.png";
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.orangehrm-employee-container > div.orangehrm-employee-image > div > div:nth-child(2) > input")).SendKeys(imagePath);

                // Check 'Create Login Details' and fill in details
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.orangehrm-employee-container > div.orangehrm-employee-form > div.oxd-form-row.user-form-header > div > label > span")).Click();
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.orangehrm-employee-container > div.orangehrm-employee-form > div:nth-child(4) > div > div:nth-child(1) > div > div:nth-child(2) > input")).SendKeys(user);
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.orangehrm-employee-container > div.orangehrm-employee-form > div.oxd-form-row.user-password-row > div > div.oxd-grid-item.oxd-grid-item--gutters.user-password-cell > div > div:nth-child(2) > input")).SendKeys("password123");
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.orangehrm-employee-container > div.orangehrm-employee-form > div.oxd-form-row.user-password-row > div > div:nth-child(2) > div > div:nth-child(2) > input")).SendKeys("password123");

                // Submit the form
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();

                // Navigate to Job section and fill in details
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-navigation > div.orangehrm-tabs > div:nth-child(6) > a")).Click();
                driver.FindElement(By.PartialLinkText("Job")).Click();
                //Save Current URL
                URL = driver.Url.ToString();
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div:nth-child(1) > div > div:nth-child(1) > div > div:nth-child(2) > div > div > input")).SendKeys("2001-10-02");
                //driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > div.oxd-select-text-input")).SendKeys("Software Engineer");

                
                IWebElement jobTitle = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div:nth-child(1) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > div.oxd-select-text-input")); // Replace with the actual CSS selector for the job title dropdown
                jobTitle.Click();
                int jobTitleloop = new Random().Next(1, 25);
                for (int i = 0; i < jobTitleloop; i++)
                {
                    jobTitle.SendKeys(Keys.Down);
                }
                jobTitle.SendKeys(Keys.Enter);


                IWebElement jobCategory = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div:nth-child(1) > div > div:nth-child(4) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                jobCategory.Click();
                int jobCategoryloop = new Random().Next(1, 5);
                for (int i = 0; i < jobCategoryloop; i++)
                {
                    jobCategory.SendKeys(Keys.Down);
                }
                jobCategory.SendKeys(Keys.Enter);

                IWebElement jobLocation = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div:nth-child(1) > div > div:nth-child(6) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                jobLocation.Click();
                int jobLocationloop = new Random().Next(1, 4);
                for (int i = 0; i < jobLocationloop; i++)
                {
                    jobLocation.SendKeys(Keys.Down);
                }
                jobLocation.SendKeys(Keys.Enter);

                
                var jobStatus = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div:nth-child(1) > div > div:nth-child(7) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                jobStatus.Click();
                var jobStatusText = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div:nth-child(1) > div > div:nth-child(7) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                while (jobStatusText.GetAttribute("outerText") != "Full-Time Permanent")
                {
                    jobStatus.SendKeys(Keys.Down);
                }
                jobStatus.SendKeys(Keys.Enter);

                // Save job details
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(1) > form > div.oxd-form-actions > button")).Click();

                // Add a supervisor in the Report-to section
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-navigation > div.orangehrm-tabs > div:nth-child(8) > a")).Click();
                driver.FindElement(By.PartialLinkText("Report-to")).Click();
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(2) > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > div > button")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                IWebElement supevisort = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(2) > div.orangehrm-horizontal-padding.orangehrm-top-padding > form > div.oxd-form-row > div > div:nth-child(1) > div > div:nth-child(2) > div > div > input"));
                supevisort.SendKeys("Odis Adalwin");
                Thread.Sleep(2000);
                supevisort.SendKeys(Keys.Down);
                supevisort.SendKeys(Keys.Enter);
                IWebElement method = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(2) > div.orangehrm-horizontal-padding.orangehrm-top-padding > form > div.oxd-form-row > div > div:nth-child(2) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                method.Click();
                method.SendKeys(Keys.Down);
                method.SendKeys(Keys.Enter);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // Save supervisor details
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div:nth-child(2) > div.orangehrm-horizontal-padding.orangehrm-top-padding > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // Verification steps
                driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewEmployeeList");
                var employmentExpand = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-row > div > div:nth-child(3) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                employmentExpand.Click();
                var employmentExpandText = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-row > div > div:nth-child(3) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                while (employmentExpandText.GetAttribute("outerText") != "Full-Time Permanent")
                {
                    employmentExpand.SendKeys(Keys.Down);
                }
                employmentExpand.SendKeys(Keys.Enter);
                IWebElement supevisor = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-row > div > div:nth-child(5) > div > div:nth-child(2) > div > div > input"));
                supevisor.SendKeys("Odis Adalwin");
                Thread.Sleep(2000);
                supevisor.SendKeys(Keys.Down);
                supevisor.SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div.oxd-table-filter > div.oxd-table-filter-area > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();

                // Assertions to confirm test success
                Thread.Sleep(2000);
                bool isEmployeeFound = driver.PageSource.Contains(firstName);

                // Assert that the employee was found
                Assert.IsTrue(isEmployeeFound, "Employee not found in the search results.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }

        [Test]
        public void Test2()
        {
            string nickname = "Nickname";
            string otherId = "OtherID";
            string licenseNumber = "123456789";
            string licenseExpiryDate = "2021-12-31";
            string ssnNumber = "123456789";
            string sinNumber = "123456789";
            string dateOfBirth = "2001-01-01";
            string militaryService = "MilitaryService";
            string attachmentName = @"C:\Users\skude\Pictures\Images\OOP3P3.png";
            string attachmentNameedit = @"C:\Users\skude\Pictures\Images\OOP3P2.png";

            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.PartialLinkText("Personal Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //set nickname
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(1) > div.oxd-grid-3.orangehrm-full-width-grid > div > div > div:nth-child(2) > input")).SendKeys(nickname);
            //set other ID
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(3) > div:nth-child(1) > div:nth-child(2) > div > div:nth-child(2) > input")).SendKeys(otherId);
            //set Driver's License Number
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > div > div:nth-child(2) > input")).SendKeys(licenseNumber);
            //set License Expiry Date
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(3) > div:nth-child(2) > div:nth-child(2) > div > div:nth-child(2) > div > div > input")).SendKeys(licenseExpiryDate);
            //set SSN Number
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(3) > div:nth-child(3) > div:nth-child(1) > div > div:nth-child(2) > input")).SendKeys(ssnNumber);
            //set SIN Number
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(3) > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(2) > input")).SendKeys(sinNumber);
            //set Nationality
            var nationality = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(5) > div:nth-child(1) > div:nth-child(1) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
            nationality.Click();
            int nationalityloop = new Random().Next(1, 100);
            for (int i = 0; i < nationalityloop; i++)
            {
                nationality.SendKeys(Keys.Down);
            }
            nationality.SendKeys(Keys.Enter);
            //set Marital Status
            var maritalStatus = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(5) > div:nth-child(1) > div:nth-child(2) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
            maritalStatus.Click();
            int maritalStatusloop = new Random().Next(1, 3);
            for (int i = 0; i < maritalStatusloop; i++)
            {
                maritalStatus.SendKeys(Keys.Down);
            }
            maritalStatus.SendKeys(Keys.Enter);
            //set Date of Birth
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(5) > div:nth-child(2) > div:nth-child(1) > div > div:nth-child(2) > div > div > input")).SendKeys(dateOfBirth);
            //set male
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(5) > div:nth-child(2) > div:nth-child(2) > div > div.--gender-grouped-field > div:nth-child(1) > div:nth-child(2) > div > label > span")).Click();
            //set Military Service
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(7) > div > div:nth-child(1) > div > div:nth-child(2) > input")).SendKeys(militaryService);
            //set Smoker
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div:nth-child(7) > div > div:nth-child(2) > div > div:nth-child(2) > div > label > span > i")).Click();
            //save
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > form > div.oxd-form-actions > button")).Click();

            //set Blood Type
            var bloodType = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-custom-fields > div > form > div.oxd-form-row > div > div > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
            bloodType.Click();
            int bloodTypeloop = new Random().Next(1, 8);
            for (int i = 0; i < bloodTypeloop; i++)
            {
                bloodType.SendKeys(Keys.Down);
            }
            bloodType.SendKeys(Keys.Enter);

            //save
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-custom-fields > div > form > div.oxd-form-actions > button")).Click();

            for (int i = 0; i < 2; i++)
            {
                //Click button
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div.orangehrm-horizontal-padding.orangehrm-vertical-padding > div > button")).Click();
                //set Attachment Name
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div > form > div:nth-child(1) > div > div > div > div:nth-child(2) > input")).SendKeys(attachmentName);
                //save attachment
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();
            }
            
            
            //click donwload button
            var donwload = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div.orangehrm-container > div > div.oxd-table-body > div:nth-child(1) > div > div:nth-child(8) > div > button:nth-child(3)"));
            donwload.Click();
            
            //Click edit button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div.orangehrm-container > div > div.oxd-table-body > div:nth-child(1) > div > div:nth-child(8) > div > button:nth-child(1)")).Click();
            
            //set Attachment Name
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div > form > div:nth-child(2) > div > div > div > div:nth-child(2) > input")).SendKeys(attachmentNameedit);
            
            //save attachment
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();
            
            //click delete button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div > div.orangehrm-edit-employee-content > div.orangehrm-attachment > div.orangehrm-container > div > div.oxd-table-body > div:nth-child(1) > div > div:nth-child(8) > div > button:nth-child(2)")).Click();
            
            //click delete confirm button
            driver.FindElement(By.CssSelector("#app > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > div.orangehrm-modal-footer > button.oxd-button.oxd-button--medium.oxd-button--label-danger.orangehrm-button-margin")).Click();

            //add assert check, check numbers of files
            Thread.Sleep(5000);
            bool contains = driver.PageSource.Contains("(1) Record Found");
            Assert.IsTrue(contains);
            Thread.Sleep(2000);



        }


        [Test]
        public void Test3()
        {
            string name = "Perovic";
            string middlename = "Sow";
            string lastname = "Tester";
            string email = "test@gmail.com";
            string contactNum = "123";
            string file = @"C:\Users\skude\Subjects\Software Testing\Test1.txt";
            string keywords = "testKey";
            string notes = "testNote";

            // Navigate to the URL
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/recruitment/addCandidate");

            // Enter name
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div > div > div.--name-grouped-field > div:nth-child(1) > div:nth-child(2) > input")).SendKeys(name);
            // Enter middle name
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div > div > div.--name-grouped-field > div:nth-child(2) > div:nth-child(2) > input")).SendKeys(middlename);
            // Enter last name
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(1) > div > div > div > div.--name-grouped-field > div:nth-child(3) > div:nth-child(2) > input")).SendKeys(lastname);
            // Enter vacancy
            var vacancy = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
            vacancy.Click();
            int vacancyloop = new Random().Next(1, 7);
            for (int i = 0; i < vacancyloop; i++)
            {
                vacancy.SendKeys(Keys.Down);
            }
            vacancy.SendKeys(Keys.Enter);

            // Enter email
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(3) > div > div:nth-child(1) > div > div:nth-child(2) > input")).SendKeys(email);
            // Enter contact number
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(3) > div > div:nth-child(2) > div > div:nth-child(2) > input")).SendKeys(contactNum);
            // Enter File
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(4) > div > div > div > div > div:nth-child(2) > input")).SendKeys(file);
            // Enter Keywords
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(5) > div > div.oxd-grid-item.oxd-grid-item--gutters.orangehrm-save-candidate-page-full-width > div > div:nth-child(2) > input")).SendKeys(keywords);
            // Enter Notes
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(6) > div > div > div > div:nth-child(2) > textarea")).SendKeys(notes);
            Thread.Sleep(2000);
            // Click Save
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();
            // Click on the shortList
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div.orangehrm-recruitment > div.orangehrm-recruitment-actions > button.oxd-button.oxd-button--medium.oxd-button--success")).Click();
            // Add Notes
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div > div > div:nth-child(2) > textarea")).SendKeys(notes);
            Thread.Sleep(2000);
            // Click Save
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space")).Click();
            Thread.Sleep(2000);
            // Schedule Interview button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div.orangehrm-recruitment > div.orangehrm-recruitment-actions > button.oxd-button.oxd-button--medium.oxd-button--success")).Click();
            Thread.Sleep(2000);
            //set interview title
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div:nth-child(1) > div > div:nth-child(2) > input")).SendKeys("Test Interview");
            //set interviewer
            var interviewer = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div:nth-child(2) > div > div > div:nth-child(2) > div > div > input"));
            interviewer.SendKeys("Odis  Adalwin");
            Thread.Sleep(2000);
            interviewer.SendKeys(Keys.Down);
            Thread.Sleep(2000);
            interviewer.SendKeys(Keys.Enter);
            //set interview date
            var interviewDate = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div:nth-child(3) > div > div:nth-child(2) > div > div > input"));
            interviewDate.Click();
            var day = driver.FindElements(By.ClassName("oxd-calendar-date"));
            day[3].Click();
            var time = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div:nth-child(4) > div > div:nth-child(2) > div > div > input"));
            time.Click();
            var hour = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div:nth-child(4) > div > div:nth-child(2) > div > div.oxd-time-picker > div.oxd-time-hour-input > input"));
            var minute = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(2) > div > div:nth-child(4) > div > div:nth-child(2) > div > div.oxd-time-picker > div.oxd-time-minute-input > input"));
            Random random = new Random();
            hour.SendKeys(Keys.LeftControl + 'A');
            hour.SendKeys(Keys.Backspace);
            hour.SendKeys(random.Next(1, 12).ToString());
            minute.SendKeys(Keys.LeftControl + 'A');
            minute.SendKeys(Keys.Backspace);
            minute.SendKeys(random.Next(0, 60).ToString());

            var saveInterview = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space"));
            saveInterview.Click();

            Thread.Sleep(2000);
            bool check = driver.PageSource.Contains("Interview");
            Assert.IsTrue(check);
        }

        [Test]
        public void Test4()
        {
            string URL = "https://opensource-demo.orangehrmlive.com/web/index.php/buzz/viewBuzz";
            string message = "Test Message";
            string newmessage = "New Test Message";
            string comment = "Test Comment";
            string newcomment = "New Test Comment";
            string attachmentName = @"C:\Users\skude\Pictures\Images\OOP3P3.png";
            //go to URL
            driver.Navigate().GoToUrl(URL);
            Thread.Sleep(2000);
            //Attach message
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-sheet.oxd-sheet--rounded.oxd-sheet--gutters.oxd-sheet--white.orangehrm-buzz-create-post > div.orangehrm-buzz-create-post-header > div.orangehrm-buzz-create-post-header-text > form > div > textarea")).SendKeys(message);
            Thread.Sleep(2000);
            //Click button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-sheet.oxd-sheet--rounded.oxd-sheet--gutters.oxd-sheet--white.orangehrm-buzz-create-post > div.orangehrm-buzz-create-post-actions > button:nth-child(1)")).Click();
            Thread.Sleep(2000);
            //Attach file
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > form > div.orangehrm-photo-input > div.oxd-input-group.oxd-input-field-bottom-space > div:nth-child(2) > input")).SendKeys(attachmentName);
            Thread.Sleep(2000);
            //Click button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > form > div.oxd-form-actions.orangehrm-buzz-post-modal-actions > button")).Click();
            Thread.Sleep(2000);
            //Click Like
            driver.FindElement(By.CssSelector("#heart")).Click();
            Thread.Sleep(2000);
            //Click 3 dots
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-post > div > div.orangehrm-buzz-post-header-config > li > button > i")).Click();
            Thread.Sleep(2000);
            //Click Edit
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-post > div > div.orangehrm-buzz-post-header-config > li > ul > li:nth-child(2) > p")).Click();
            Thread.Sleep(2000);
            //set new message
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > form > div.orangehrm-buzz-post-modal-header > div.orangehrm-buzz-post-modal-header-text > div > textarea")).SendKeys(newmessage);
            Thread.Sleep(2000);
            //Click button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > form > div.oxd-form-actions.orangehrm-buzz-post-modal-actions > button")).Click();
            Thread.Sleep(2000);
            //Click comment
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-post-footer > div.orangehrm-buzz-post-actions > button:nth-child(2) > i")).Click();
            Thread.Sleep(2000);
            //set comment
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-comment > div > form > div > div:nth-child(2) > input")).SendKeys(comment);
            Thread.Sleep(2000);
            //save comment clicked enter button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-comment > div > form > div > div:nth-child(2) > input")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //Click like comment
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-comment > div.orangehrm-comment-wrapper > div.orangehrm-post-comment > div.orangehrm-post-comment-action-area > p:nth-child(1)")).Click();
            Thread.Sleep(2000);
            //Click edit comment
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-comment > div.orangehrm-comment-wrapper > div.orangehrm-post-comment > div.orangehrm-post-comment-action-area > p:nth-child(2)")).Click();
            Thread.Sleep(2000);
            //set new comment
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-comment > div.orangehrm-comment-wrapper > div.orangehrm-post-comment > form > div > div:nth-child(2) > input")).SendKeys(newcomment);
            Thread.Sleep(2000);
            //save comment clicked enter button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-comment > div.orangehrm-comment-wrapper > div.orangehrm-post-comment > form > div > div:nth-child(2) > input")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //Click delete comment
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-comment > div.orangehrm-comment-wrapper > div.orangehrm-post-comment > div.orangehrm-post-comment-action-area > p:nth-child(3)")).Click();
            Thread.Sleep(2000);
            //Click delete comment confirmation
            driver.FindElement(By.CssSelector("#app > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > div.orangehrm-modal-footer > button.oxd-button.oxd-button--medium.oxd-button--label-danger.orangehrm-button-margin")).Click();
            Thread.Sleep(2000);
            //go page up
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
            Thread.Sleep(2000);
            //Click 3 dots
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-post > div > div.orangehrm-buzz-post-header-config > li > button > i")).Click();
            Thread.Sleep(2000);
            //Click delete post
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div:nth-child(1) > div > div.oxd-grid-1.orangehrm-buzz-newsfeed-posts > div:nth-child(1) > div > div.orangehrm-buzz-post > div > div.orangehrm-buzz-post-header-config > li > ul > li:nth-child(1) > p")).Click();
            Thread.Sleep(2000);
            //Click delete post confirmation
            driver.FindElement(By.CssSelector("#app > div.oxd-overlay.oxd-overlay--flex.oxd-overlay--flex-centered > div > div > div > div.orangehrm-modal-footer > button.oxd-button.oxd-button--medium.oxd-button--label-danger.orangehrm-button-margin")).Click();
            Thread.Sleep(2000);
            //Assert check
            bool check = (driver.PageSource.Contains(message+newmessage))? false: true;
            Assert.IsTrue(check);
        }

        [Test]
        public void Test5()
        {
            string URL = "https://opensource-demo.orangehrmlive.com/web/index.php/pim/definePredefinedReport";
            int set = 5;
            //Go to URL
            driver.Navigate().GoToUrl(URL);

            for (int i = 0 ; i < 2 ; i++)
            {
                Thread.Sleep(1000);
                //Select Criteria
                var criteria = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(3) > div > div.oxd-grid-item.oxd-grid-item--gutters.orangehrm-report-criteria.--span-column-2 > div.oxd-input-group.oxd-input-field-bottom-space > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                criteria.Click();
                int criterialoop = new Random().Next(1, 13);
                for (int j = 0; j < criterialoop; j++)
                {
                    criteria.SendKeys(Keys.Down);
                }
                criteria.SendKeys(Keys.Enter);
                //Add criteria
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(3) > div > div.oxd-grid-item.oxd-grid-item--gutters.orangehrm-report-criteria.--span-column-2 > div:nth-child(2) > div:nth-child(2) > button > i")).Click();
            }
            for (int i = 0; i < 2 ; i++)
            {
                Thread.Sleep(1000);
                //Click delete Criteria
                driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(3) > div > div:nth-child(3) > button > i")).Click();
            }

            var include = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(3) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
            include.Click();
            var includeText = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(3) > div > div:nth-child(2) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
            while (includeText.GetAttribute("textContent") != "Current and Past Employees")
            {
                include.SendKeys(Keys.Down);
                Thread.Sleep(1000);
            }
            include.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            for (int i = 0 ; i < 4 ; i++)
            {
                Thread.Sleep(1000);
                //Click select
                var group = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(5) > div > div:nth-child(1) > div > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                group.Click();
                for (int j = -1 ; j < i; j++)
                    group.SendKeys(Keys.Down);
                group.SendKeys(Keys.Enter);
                for (int j = 0; j < 4; j++)
                {
                    var field = driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(5) > div > div.oxd-grid-item.oxd-grid-item--gutters.orangehrm-report-criteria.--span-column-2 > div.oxd-input-group.oxd-input-field-bottom-space > div:nth-child(2) > div > div > div.oxd-select-text-input"));
                    field.Click();
                    field.SendKeys(Keys.Down);
                    field.SendKeys(Keys.Enter);
                    //Click Button
                    driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(5) > div > div.oxd-grid-item.oxd-grid-item--gutters.orangehrm-report-criteria.--span-column-2 > div:nth-child(2) > div:nth-child(2) > button")).Click();
                }
            }
            var checkBoxes = driver.FindElements(By.CssSelector("[class='oxd-switch-input oxd-switch-input--active --label-right']"));
            for (int i = 0; i < checkBoxes.Count; i++)
                checkBoxes[i].Click();

            Thread.Sleep(1000);

            //Click delete Button
            driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div:nth-child(5) > div > div:nth-child(3) > button > i")).Click();

            // Find all selected field elements by the class that indicates they are selected
            IList<IWebElement> selectedFields = driver.FindElements(By.CssSelector("[class='oxd-chip oxd-chip--default oxd-multiselect-chips-selected']"));

            // Count the elements
            int selectedCount = selectedFields.Count;
            bool check = selectedCount >= 8;
            Assert.IsTrue(check);
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser after each test
            //driver.Quit();
        }
    }
}
