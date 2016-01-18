using eCashAPI.DTO.BIM;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCashAPI
{
    internal interface IBIMService
    {
        [Post("/oauth2/token")]
        Task<GenerateTokenResponse> GenerateTokenAsync([Body]GenerateTokenRequest generateTokenRequest);

        [Get("/banks")]
        Task<List<string>> GetBankNamesAsync();

        [Get("/banks/banklist")]
        Task<List<List<string>>> GetBankNamesIDAsync();

        [Get("/banks/bankid/{bankName}")]
        Task<int> GetBankIdAsync(string bankName);

        [Get("/banks/bankname/{bankID}")]
        Task<string> GetBankNameFromIDAsync(int bankID);

        [Get("/enrollment/status?access_token={AccessToken}")]
        Task<ServiceResponse> GetEnrollmentStatusAsync(string AccessToken);

        [Post("/enrollment/startEnrollment?access_token={AccessToken}")]
        Task<ServiceResponse> StartEnrollmentAsync(string AccessToken, [Body]StartEnrollmentRequest startEnrollmentRequest);

        [Post("/enrollment/selectBank?access_token={AccessToken}")]
        Task<ServiceResponse> SelectBankByIdAsync(string AccessToken, [Body]SelectBankByIdRequest selectBankByIdRequest);

        [Post("/enrollment/continueEnrollmentLogin?access_token={AccessToken}")]
        Task<ServiceResponse> ContinueEnrollmentLoginAsync(string AccessToken, [Body]ContinueEnrollmentLoginRequest continueEnrollmentLoginRequest);

        [Post("/enrollment/checkEnrollment?access_token={AccessToken}")]
        Task<ServiceResponse> CheckEnrollmentAsync(string AccessToken, [Body]Dictionary<string,string> enrollmentCheckRequest);

        [Post("/enrollment/matchEnrollment?access_token={AccessToken}")]
        Task<ServiceResponse> MatchEnrollmentAsync(string AccessToken, [Body]MatchEnrollmentRequest matchEnrollmentRequest);

        [Post("/enrollment/checkCdwAllowed?access_token={AccessToken}")]
        Task<ServiceResponse> CheckCDWAllowAsync(string AccessToken, [Body]CheckCDWAllowRequest checkCDWAllowRequest);

        [Post("/enrollment/confirmCdw?access_token={AccessToken}")]
        Task<ServiceResponse> ConfirmCDWAmountAsync(string AccessToken, [Body]ConfirmCDWAmountRequest confirmCDWAmountRequest);

        [Post("/enrollment/selectBankAccount?access_token={AccessToken}")]
        Task<ServiceResponse> SelectBankByGUIDAsync(string AccessToken, [Body]SelectBankByGUIDRequest selectBankByGUIDRequest);

        [Post("/payments/consumer/barcode?access_token={AccessToken}")]
        Task<ServiceResponse> GenerateBarcodeAsync(string AccessToken, [Body]GenerateBarcodeRequest generateBarcodeRequest);

        [Post("/payments/consumer/rewards?access_token={AccessToken}")]
        Task<ServiceResponse> GetConsumerRewards(string AccessToken, [Body]ConsumerRewardRequest req);

        [Post("/payments/merchant/barcode/sale?access_token={AccessToken}")]
        Task<ServiceResponse> BarcodeSaleAsync(string AccessToken, [Body]MerchantBarcodeSaleRequest saleRequest);

        [Post("/payments/merchant/barcode/void?access_token={AccessToken}")]
        Task<ServiceResponse> BarcodeVoidAsync(string AccessToken, [Body]MerchantBarcodeVoidRequest voidRequest);

        [Post("/barcodes/offline/load?access_token={AccessToken}")]
        Task<ServiceResponse> OfflineBarcodeAsync(string AccessToken, [Body]OfflineBarcodeRequest offlineBarcodeRequest);

        [Post("/pin/hasPIN?access_token={AccessToken}")]
        Task<ServicePinResponse> CheckPinAsync(string AccessToken, [Body]CheckPinRequest checkPinRequest);

        [Post("/pin/updatePIN?access_token={AccessToken}")]
        Task<ServicePinResponse> UpdatePinAsync(string AccessToken, [Body]UpdatePinRequest updatePinRequest);

        [Post("/pin/verifyPIN?access_token={AccessToken}")]
        Task<ServicePinResponse> VerifyPinAsync(string AccessToken, [Body]VerifyPinRequest verifyPinRequest);

        [Post("/reports/merchant/transaction/summary?access_token={AccessToken}")]
        Task<ServiceResponse> TransactionSummaryAsync(string AccessToken, [Body]TransactionSummaryRequest req);

        [Post("/reports/merchant/transaction/detail?access_token={AccessToken}")]
        Task<ServiceResponse> TransactionDetailAsync(string AccessToken, [Body]TransactionDetailsRequest req);

    }
}

