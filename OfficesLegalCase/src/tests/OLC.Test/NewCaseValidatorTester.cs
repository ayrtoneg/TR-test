using FluentValidation.TestHelper;
using NUnit.Framework;
using OLC.Cases.Api.Application.Commands;
using OLC.Cases.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OLC.Test
{
    [TestFixture]
    public class NewCaseValidatorTester
    {
        private NewCaseValidation validator;

        [SetUp]
        public void Setup()
        {
            validator = new NewCaseValidation();
        }

        #region Case_Number
        [Test]
        public void Should_have_error_when_Case_Number_is_invalid_with_zeros()
        {
            var model = new NewCaseCommand("123456000.1234.1.12.1234", "Random Name Court", "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CaseNumber);
        }

        [Test]
        public void Should_have_error_when_Case_Number_is_invalid_format()
        {
            var model = new NewCaseCommand("123400.1234.1.12.1234", null, "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CaseNumber);
        }

        [Test]
        public void Should_have_error_when_Case_Number_is_null()
        {
            var model = new NewCaseCommand(null, "Random Name", "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CaseNumber);
        }


        [Test]
        public void Should_have_error_when_Case_Number_is_empty()
        {
            var model = new NewCaseCommand(string.Empty, "Random Name", "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CaseNumber);
        }

        [Test]
        public void Should_not_have_error_when_Case_Number_is_valid()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", "Random Name Court", "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.CaseNumber);
        }
        #endregion

        #region Court_Name
        [Test]
        public void Should_have_error_when_Court_Name_is_null()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", null, "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CourtName);
        }

        [Test]
        public void Should_have_error_when_Court_Name_is_empty()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", string.Empty, "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CourtName);
        }

        [Test]
        public void Should_have_error_when_Court_Name_is_greater_than_allowed()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", "An occurance of sorts that brings a problem to somebody's attention and they realize it needs fixing.", "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CourtName);
        }

        [Test]
        public void Should_not_have_error_when_Court_Name_is_filled()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", "Random Name Court", "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.CourtName);
        }
        #endregion

        #region Name_Of_The_Responsible
        [Test]
        public void Should_have_error_when_Name_Of_The_Responsible_is_null()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", "Random Name", null);
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.NameOfTheResponsible);
        }

        [Test]
        public void Should_have_error_when_Name_Of_The_Responsible_is_empty()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", "Random Name", string.Empty);
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.NameOfTheResponsible);
        }

        [Test]
        public void Should_have_error_when_Name_Of_The_Responsible_is_greater_than_allowed()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", "Random Name", "An occurance of sorts that brings a problem to somebody's attention and they realize it needs fixing.");
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.NameOfTheResponsible);
        }

        [Test]
        public void Should_not_have_error_when_Name_Of_The_Responsible_is_filled()
        {
            var model = new NewCaseCommand("123456789.1234.1.12.1234", "Random Name Court", "Random Name");
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.NameOfTheResponsible);
        }
        #endregion
    }
}
