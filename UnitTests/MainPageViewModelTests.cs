using System.Threading.Tasks;
using NBUStat.Data;
using NBUStat.Service;
using Moq;
using NUnit.Framework;
using NBUStat.Data.Response;
using NBUStat.ViewModel;

namespace UnitTests {
    [TestFixture]
    public class MainPageViewModelTests {
        [Test]
        public async Task SuccessfulTest() {
            // ARRANGE
            var currencyRateServiceMock = new Mock<ICurrencyRateService>();
            currencyRateServiceMock
                .Setup(service => service.GetCurrencyRatesAsync())
                .Returns(Task.FromResult(
                    (IResponse<CurrencyRate[]>) new SuccessResponse<CurrencyRate[]>(new[] {
                        new CurrencyRate(),
                        new CurrencyRate()
                    })));

            var mainViewModel = new MainPageViewModel(currencyRateServiceMock.Object);

            const string isoCode = "EUR";
            currencyRateServiceMock
                .Setup(service => service.GetCurrencyRatesHistoryAsync(isoCode))
                .Returns(Task.FromResult(
                    (IResponse<CurrencyRate[]>) new SuccessResponse<CurrencyRate[]>(new[] {
                        new CurrencyRate(),
                        new CurrencyRate()
                    })));

            var historyViewModel = new CurrencyHistoryViewModel(currencyRateServiceMock.Object, isoCode);

            await mainViewModel.InitAsync();
            await historyViewModel.InitAsync();
            Assert.AreEqual(2, mainViewModel.CurrencyRates.Length);
            Assert.AreEqual(2, historyViewModel.CurrencyRates.Length);
        }

        [Test]
        public async Task FailTest() {
            // ARRANGE
            const string testErrorMessage = "Error";

            var currencyRateServiceMock = new Mock<ICurrencyRateService>();
            currencyRateServiceMock
                .Setup(service => service.GetCurrencyRatesAsync())
                .Returns(Task.FromResult(
                    (IResponse<CurrencyRate[]>) new ErrorResponse<CurrencyRate[]>(testErrorMessage)));

            var mainViewModel = new MainPageViewModel(currencyRateServiceMock.Object);
            
            const string isoCode = "EUR";
            currencyRateServiceMock
                .Setup(service => service.GetCurrencyRatesHistoryAsync(isoCode))
                .Returns(Task.FromResult(
                    (IResponse<CurrencyRate[]>) new ErrorResponse<CurrencyRate[]>(testErrorMessage)));
            
            var historyViewModel = new CurrencyHistoryViewModel(currencyRateServiceMock.Object, isoCode);
            
            await mainViewModel.InitAsync();
            await historyViewModel.InitAsync();
            Assert.AreEqual(testErrorMessage, mainViewModel.ErrorMessage);
            Assert.AreEqual(testErrorMessage, historyViewModel.ErrorMessage);
        }
    }
}