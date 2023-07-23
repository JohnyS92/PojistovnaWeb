using PojistovnaWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace PojistovnaWebApp.UnitTests.Controllers
{
    public class PojisteneOsobyControllerUnitTests
    {
        //Jmeno
        [Theory]
        [InlineData("Jan Novák", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void PojisteneOsoby_ValidateJmeno(string jmeno, bool isValid)
        {
            PojisteneOsoby model = CreateValidExample();
            model.Jmeno = jmeno;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                var validationResult = validationResults.SingleOrDefault(vr => vr.MemberNames.Contains(nameof(PojisteneOsoby.Jmeno)));
                Assert.NotNull(validationResult);
                Assert.Contains("Vyplňte jméno", validationResult.ErrorMessage);
            }
        }
        // Přijmení
        [Theory]
        [InlineData("Novák", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void PojisteneOsoby_ValidatePrijmeni(string prijmeni, bool isValid)
        {
            PojisteneOsoby model = CreateValidExample();
            model.Prijmeni = prijmeni;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                var validationResult = validationResults.SingleOrDefault(vr => vr.MemberNames.Contains(nameof(PojisteneOsoby.Prijmeni)));
                Assert.NotNull(validationResult);
                Assert.Contains("Vyplňte příjmení", validationResult.ErrorMessage);
            }
        }
        //Email
        [Theory]
        [InlineData("jsransky@mail.com", true)]
        [InlineData("j.sransky@mail.com", true)]
        [InlineData("j.sransky@mail", false)]
        [InlineData("j.sransky", false)]
        [InlineData("jsranskymail.com", false)]
        [InlineData("invalidemail@", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void PojisteneOsoby_ValidateEmail(string email, bool isValid)
        {
            PojisteneOsoby model = CreateValidExample();
            model.Email = email;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                var validationResult = validationResults.Single();
                Assert.Equal(nameof(PojisteneOsoby.Email), validationResult.MemberNames.First());
            }
        }
        //Telefon
        [Theory]
        [InlineData("602034567", true)]
        [InlineData("602 034 567", true)]
        [InlineData("602 034567", false)]
        [InlineData("+420 602034567", false)]
        [InlineData("invalid phone", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void PojisteneOsoby_ValidatePhone(string phone, bool isValid)
        {
            PojisteneOsoby model = CreateValidExample();
            model.Telefon = phone;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                var validationResult = validationResults.Single();
                Assert.Equal(nameof(PojisteneOsoby.Telefon), validationResult.MemberNames.First());
            }
        }
        //Ulice
        [Theory]
        [InlineData("V kopci 123", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void PojisteneOsoby_ValidateUlice(string ulice, bool isValid)
        {
            PojisteneOsoby model = CreateValidExample();
            model.Ulice = ulice;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                var validationResult = validationResults.SingleOrDefault(vr => vr.MemberNames.Contains(nameof(PojisteneOsoby.Ulice)));
                Assert.NotNull(validationResult);
                Assert.Contains("Vyplňte ulici a číslo popisné", validationResult.ErrorMessage);
            }
        }
        //Město
        [Theory]
        [InlineData("Litomysl", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void PojisteneOsoby_ValidateMesto(string mesto, bool isValid)
        {
            PojisteneOsoby model = CreateValidExample();
            model.Mesto = mesto;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                var validationResult = validationResults.SingleOrDefault(vr => vr.MemberNames.Contains(nameof(PojisteneOsoby.Mesto)));
                Assert.NotNull(validationResult);
                Assert.Contains("Vyplňte město", validationResult.ErrorMessage);
            }
        }
        //PSČ
        [Theory]
        [InlineData("12345", true)]
        [InlineData("54321", true)]
        [InlineData("123 45", true)]
        [InlineData("543 21", true)]
        [InlineData("12 345", false)]
        [InlineData("54 321", false)]
        [InlineData("123456", false)]
        [InlineData("543210", false)]
        [InlineData("invalid", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void PojisteneOsoby_ValidatePsc(string psc, bool isValid)
        {
            PojisteneOsoby model = CreateValidExample();
            model.Psc = psc;

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            if (isValid)
            {
                Assert.Empty(validationResults);
            }
            else
            {
                var validationResult = validationResults.Single();
                Assert.Equal(nameof(PojisteneOsoby.Psc), validationResult.MemberNames.First());
            }
        }

        private static IReadOnlyCollection<ValidationResult> ValidateModel(PojisteneOsoby model)
        {
            // Code taken forom https://bytelanguage.com/2020/07/31/writing-unit-test-for-model-validation/
            // where is used with controler. For our puroposes it can be used separatelly
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
        
        private static PojisteneOsoby CreateValidExample()
        {
            // Arange
            return new PojisteneOsoby()
            {
                Email = "jstransky@mail.com",
                IdOsoby = 0,
                Jmeno = "fdfd",
                Prijmeni = "Stransky",
                Mesto = "Litomysl",
                Psc = "12345",
                Telefon = "602034567",
                Ulice = "V kopci",
            };

        }

    }
}
