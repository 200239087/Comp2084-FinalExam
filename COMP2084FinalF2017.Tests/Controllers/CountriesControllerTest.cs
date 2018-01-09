using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Web.Mvc;
using COMP2084FinalF2017.Controllers;
using Moq;
using COMP2084FinalF2017.Models;
using System.Linq;

namespace COMP2084FinalF2017.Tests.Controllers
{
    [TestClass]
    public class CountriesControllerTest
    {
        CountriesController controller;
        Mock<ICountriesRepository> mock;
        List<Country> countries;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<ICountriesRepository>();

            countries = new List<Country>
            {
                new Country { CountryID = 1, Country1 = "Country 1", Bronze = 1, Silver = 1, Gold = 1, TotalMedals = 3, Flag = "Country 1 Flag" },
                new Country { CountryID = 2, Country1 = "Country 2", Bronze = 2, Silver = 2, Gold = 2, TotalMedals = 6, Flag = "Country 2 Flag" },
                new Country { CountryID = 3, Country1 = "Country 3", Bronze = 3, Silver = 3, Gold = 3, TotalMedals = 9, Flag = "Country 3 Flag" }
            };

            mock.Setup(m => m.Countries).Returns(countries.AsQueryable());

            controller = new CountriesController(mock.Object);
        }

        [TestMethod]
        public void IndexValidLoadsCountries()
        {
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsValidId()
        {
            ViewResult actual = controller.Details(1);

            Assert.AreEqual("Details", actual.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            ViewResult actual = controller.Details(4);

            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsNoId()
        {
            ViewResult actual = controller.Details(null);

            Assert.AreEqual("Error", actual.ViewName);
        }
    }
}
