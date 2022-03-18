using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlanitAutomationTesting.UIPages;
using System;
using TechTalk.SpecFlow;

namespace PlanitAutomationTesting
{
    [Binding]
    public class UpdateContactDetailsSteps
    {
        private readonly HomePage HomePage = new HomePage();
        //private readonly ContactPage ContactPage = new ContactPage();

        [Given(@"a user is in the contact page")]
        public void GivenAUserIsInTheContactPage()
        {
            HomePage.StartBrowser();
            HomePage.NavigateToHomePage();
            HomePage.NavigateToContactPage();
        }
        
        [Given(@"has not entered any data in the mandatory field")]
        public void GivenHasNotEnteredAnyDataInTheMandatoryField()
        {
            Assert.IsTrue(HomePage.IsForenamePopulated(), "Data has been entered in the Forename field");
            Assert.IsTrue(HomePage.IsEmailPolulated(), "Data has been entered in the Email field");
            Assert.IsTrue(HomePage.IsMessagePopulated(), "Data has been entered in the Message fiels");
        }
        
        [Given(@"has submitted the contact form")]
        public void GivenHasSubmittedTheConatctForm()
        {
            HomePage.ClickSubmitButton();
        }
        
        [Given(@"received validation errors")]
        public void GivenReceivedValidationErrors()
        {
            Assert.IsTrue(HomePage.IsForenameErrorDisplayed(), "No validation error for the forename field");
            Assert.IsTrue(HomePage.IsEmailErrorDisplayed(), "No validation error for the email field");
            Assert.IsTrue(HomePage.IsEmailErrorDisplayed(), "No validation error for the message field");
        }

        [Given(@"has populated mandatory fields")]
        public void GivenHasPopulatedMandatoryFields()
        {
            HomePage.PopulateMandatoryFieldCorrectly();
        }


        [When(@"User populates the manadatory fields")]
        public void WhenUserPopulatesTheManadatoryFields()
        {
            HomePage.PopulateMandatoryFieldCorrectly();
        }

        [Then(@"the validation errors are not displayed")]
        public void ThenTheValidationErrorsAreNotDisplayed()
        {
            Assert.IsFalse(HomePage.IsForenameErrorDisplayed());
            Assert.IsFalse(HomePage.IsEmailErrorDisplayed());
            Assert.IsFalse(HomePage.IsEmailErrorDisplayed());
        }

        [Given(@"a user is in the shop page")]
        public void GivenAUserIsInTheShopPage()
        {
            HomePage.StartBrowser();
            HomePage.NavigateToHomePage();
            HomePage.NavigateToShopPage();
        }
        
        [Given(@"has selected to buy two Funny Cows")]
        public void GivenHasSelectedToBuyAFunnyCowWice()
        {
            var numberFunnyCows = 2;
    
            HomePage.BuyFunnyCow(numberFunnyCows);
        }
        
        [Given(@"has selected to buy a Fluffy Bunny")]
        public void GivenHasSelectedToBuyAnItemOnce()
        {
           var numberFunnyBunnies = 1;
           HomePage.BuyFluffyBunny(numberFunnyBunnies);
        }

        
        [When(@"the user submits the contact form")]
        public void WhenTheUserSubmitsTheContactForm()
        {
            HomePage.ClickSubmitButton();
        }
        
        [When(@"the user populates mandatory fields with invalid data")]
        public void WhenTheUserPopulatesMandatoryFieldsWithInvalidData()
        {
            HomePage.PopulateMandatoryFieldIncorrectly();
        }
        
        [When(@"the user selects the cart menu")]
        public void WhenTheUserSelectsTheCartMenu()
        {
            HomePage.NavigateToCartPage();
        }
        

        [Then(@"a successful submission message is displayed")]
        public void ThenASuccessfulSubmissionMessageIsDisplayed()
        {
            var alertMessage = HomePage.GetSubmissionMessage();
            Assert.AreEqual("Thanks Worked, we appreciate your feedback.", alertMessage, "A successful submission message has not been received");
        }
        
        [Then(@"validation errors are populated")]
        public void ThenValidationErrorsArePopulated()
        {
            Assert.IsTrue(HomePage.IsForenameErrorDisplayed());
            Assert.IsTrue(HomePage.IsEmailErrorDisplayed());
            Assert.IsTrue(HomePage.IsEmailErrorDisplayed());
        }
        
        [Then(@"the selected items are in the cart")]
        public void ThenTheSelectedItemsAreInTheCart()
        {
            HomePage.NavigateToCartPage();
            Assert.AreEqual(2, HomePage.GetFunnyCowQuantity(), "Quantity of Funny Cows in Cart do not match client selection");
            Assert.AreEqual(1, HomePage.GetFluffyBunnyQuantity(), "Quantity of Fluffy Bunnies in Cart do not match client selection");
        }
    }
}
