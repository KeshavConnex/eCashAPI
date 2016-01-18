using eCashAPI.DTO.eCash;
using Refit;
using System;
using System.Threading.Tasks;

namespace eCashAPI
{
    public class ECashService
    {
        public Task<TokenResponse> GetToken(TokenRequest request)
        {
            try
            {
                var tokenRequest = ECashToApiConverter.ParseTokenRequest(request);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var tokenResponse = bimService.GenerateTokenAsync(tokenRequest).Result;
                var response = ApiToECashConverter.ParseToken(tokenResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<TokenResponse>(new TokenResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<Enrollment> GetEnrollmentStatus(EnrollmentStatusRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var enrollmentStatusResponse = bimService.GetEnrollmentStatusAsync(accessToken).Result;
                var response = ApiToECashConverter.ParseEnrollment(enrollmentStatusResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<Enrollment>(new Enrollment() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<PersonalDetailsResponse> SubmitPersonalDetails(PersonalDetailsRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var enrollmentRequest = ECashToApiConverter.ParseEnrollmentRequest(request);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var enrollmentResponse = bimService.StartEnrollmentAsync(accessToken, enrollmentRequest).Result;
                var response = ApiToECashConverter.ParsePersonalDetails(enrollmentResponse, bimService);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<PersonalDetailsResponse>(new PersonalDetailsResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<SelectBankResponse> SelectBank(SelectBankRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseSelectBankRequest(request);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var bankResponse = bimService.SelectBankByIdAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseSelectBank(bankResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<SelectBankResponse>(new SelectBankResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<BankLoginResponse> SubmitBankLogin(BankLoginRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseEnrollmentLoginRequest(request);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var loginResponse = bimService.ContinueEnrollmentLoginAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseBankLogin(loginResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<BankLoginResponse>(new BankLoginResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<SecurityVerificationResponse> SubmitSecurityVerification(SecurityVerificationRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var securityResponse = bimService.CheckEnrollmentAsync(accessToken, request.SecurityVerificationDetails).Result;
                var response = ApiToECashConverter.ParseSecurityVerification(securityResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<SecurityVerificationResponse>(new SecurityVerificationResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<Enrollment> SelectBankAccount(SelectBankAccountRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseSelectAccountRequest(request);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var accountResponse = bimService.SelectBankByGUIDAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseEnrollment(accountResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<Enrollment>(new Enrollment() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<BarcodeResponse> GetBarcode(BarcodeRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseGetBarcodeRequest(request.DeviceId, request.HashedPin);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var barcodeResponse = bimService.GenerateBarcodeAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseBarcode(barcodeResponse);
                var rewardsRequest = ECashToApiConverter.ParseConsumerRewardRequest(request.DeviceId);
                var consumerRewards = bimService.GetConsumerRewards(accessToken, rewardsRequest).Result;
                response.Reward = ApiToECashConverter.ParseRewards(barcodeResponse); 
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<BarcodeResponse>(new BarcodeResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<OfflineBarcodeResponse> GetOfflineBarcodes(DTO.eCash.OfflineBarcodeRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseOfflineBarcodesRequest(request.DeviceId, Convert.ToString(request.BarcodesRequested));
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var barcodeResponse = bimService.OfflineBarcodeAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseOfflinrBarcode(barcodeResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<OfflineBarcodeResponse>(new OfflineBarcodeResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<MerchantBarcodeSaleResponse> MerchantBarcodeSale(DTO.eCash.MerchantBarcodeSaleRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseSaleTransaction(request.Transaction);
                var bimService = Refit.RestService.For<IBIMService>(Constants.CLIENT_URI);
                var barcodeResponse = bimService.BarcodeSaleAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseMerchantBarcodeSale(barcodeResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<MerchantBarcodeSaleResponse>(new MerchantBarcodeSaleResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<MerchantBarcodeVoidResponse> MerchantBarcodeVoid(DTO.eCash.MerchantBarcodeVoidRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseVoidTransaction(request.Transaction);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var barcodeResponse = bimService.BarcodeVoidAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseMerchantBarcodeVoid(barcodeResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<MerchantBarcodeVoidResponse>(new MerchantBarcodeVoidResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<ChangePinResponse> ChangePin(ChangePinRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseExistingPin(request.Pin);
                var bimService = RestService.For<IBIMService>(Constants.CLIENT_URI);
                var verifyPinResponse = bimService.VerifyPinAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseChangePin(verifyPinResponse);
                if (response != null && response.Result !=null && response.Result.Status)
                {
                    var updatePinRequest = ECashToApiConverter.ParseNewPin(request.Pin);
                    var updatePinResponse = bimService.UpdatePinAsync(accessToken, updatePinRequest).Result;
                    response = ApiToECashConverter.ParseChangePin(updatePinResponse);
                }
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<ChangePinResponse>(new ChangePinResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<ManualEnrollmentResponse> SubmitManualEnrollment(ManualEnrollmentRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimService = Refit.RestService.For<IBIMService>(Constants.CLIENT_URI);
                var bimSelectbankRequest = ECashToApiConverter.ParseSelectBankByIdRequest(1);
                var selectBankByIdResponse = bimService.SelectBankByIdAsync(accessToken, bimSelectbankRequest).Result;
                var bimRequest = ECashToApiConverter.ParseManualEnrollment(request.Account);
                var manualEnrollmentResponse = bimService.MatchEnrollmentAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseManualEnrollment(manualEnrollmentResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<ManualEnrollmentResponse>(new ManualEnrollmentResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<CDWAllowedResponse> CheckCDWAllowed(CDWAllowedRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseCheckCDWAllow(request.UpdateWorkflow);
                var bimService = Refit.RestService.For<IBIMService>(Constants.CLIENT_URI);
                var checkCDWAllowResponse = bimService.CheckCDWAllowAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseCDWAllowedResponse(checkCDWAllowResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<CDWAllowedResponse>(new CDWAllowedResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<Enrollment> ConfirmCDWAmount(CDWAmountRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseConfirmCDWAmount(request.DepositAmount, request.WithdrawalAmount);
                var bimService = Refit.RestService.For<IBIMService>(Constants.CLIENT_URI);
                var confirmCDWResponse = bimService.ConfirmCDWAmountAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseEnrollment(confirmCDWResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<Enrollment>(new Enrollment() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<TransactionSummaryResponse> GetTransactionSummary(DTO.eCash.TransactionSummaryRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseTransactionReportSummary(request.TransactionReport);
                var bimService = Refit.RestService.For<IBIMService>(Constants.CLIENT_URI);
                var txnSummaryResponse = bimService.TransactionSummaryAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseTransactionSummary(txnSummaryResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<TransactionSummaryResponse>(new TransactionSummaryResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
        public Task<TransactionDetailResponse> GetTransactionDetail(TransactionDetailRequest request)
        {
            try
            {
                var accessToken = request != null && request.Credentials != null ? request.Credentials.AccessToken : null;
                var bimRequest = ECashToApiConverter.ParseTransactionReportDetail(request.TransactionReport);
                var bimService = Refit.RestService.For<IBIMService>(Constants.CLIENT_URI);
                var txnDetailResponse = bimService.TransactionDetailAsync(accessToken, bimRequest).Result;
                var response = ApiToECashConverter.ParseTransactionDetail(txnDetailResponse);
                return Task.FromResult(response);
            }
            catch (Exception e)
            {
                return Task.FromResult<TransactionDetailResponse>(new TransactionDetailResponse() { Result = CommonFunction.ParseException(e) });
            }
        }
    }
}
