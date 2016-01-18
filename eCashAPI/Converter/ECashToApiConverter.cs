using eCashAPI.DTO.eCash;
using System;
using System.Collections.Generic;

namespace eCashAPI
{
    internal class ECashToApiConverter
    {
        public static DTO.BIM.GenerateTokenRequest ParseTokenRequest(TokenRequest request)
        {
            if (request != null && request.Credentials !=null)
            {
                return new DTO.BIM.GenerateTokenRequest()
                {
                    client_id = Constants.CLIENT_ID,
                    client_secret = Constants.CLIENT_SECRET,
                    grant_type = Constants.GRANT_TYPE,
                    redirect_uri = Constants.REDIRECT_URI,
                    code = request.Credentials.AuthCode
                };
            }

            return null;
        }

        

        public static DTO.BIM.StartEnrollmentRequest ParseEnrollmentRequest(PersonalDetailsRequest request)
        {
            if(request !=null && request.Consumer !=null)
            {
                return new DTO.BIM.StartEnrollmentRequest()
                {
                    id_type = request.Consumer.IdType,
                    id_state = request.Consumer.IdState,
                    id_number = request.Consumer.IdNumber,
                    fname = request.Consumer.FirstName,
                    lname = request.Consumer.LastName,
                    dob = request.Consumer.DateOfBirth,
                    mailing_address = request.Consumer.StreetAddress,
                    apartment_number = request.Consumer.ApartmentNumber,
                    city = request.Consumer.City,
                    state = request.Consumer.State,
                    zip = request.Consumer.Zip,
                    home_phone_number = request.Consumer.HomePhone,
                    mobile_phone_number = request.Consumer.MobilePhone
                };
            }
            return null;
        }

        public static DTO.BIM.SelectBankByIdRequest ParseSelectBankRequest(SelectBankRequest request)
        {
            if(request !=null && request.Bank !=null)
            {
                return new DTO.BIM.SelectBankByIdRequest() { bank_id = request.Bank.Id };
            }
            return null;
            
        }

        public static DTO.BIM.ContinueEnrollmentLoginRequest ParseEnrollmentLoginRequest(BankLoginRequest request)
        {
            if (request != null && request.BankLoginDetails != null)
            {
                string login = string.Empty;
                string password = string.Empty;
                foreach (KeyValuePair<string, string> KeyValue in request.BankLoginDetails)
                {
                    login = ((KeyValue.Key == "LOGIN") ? KeyValue.Value : login);
                    password = ((KeyValue.Key == "PASSWORD") ? KeyValue.Value : password);
                }
                return new DTO.BIM.ContinueEnrollmentLoginRequest()
                {
                    LOGIN = login,
                    PASSWORD = password
                };
            }
            return null;
        }

        private static DTO.BIM.QuestionAnswerEntity[] ParseQuestionAnswerRequest(Dictionary<string, string> securityDetails)
        {
            List<DTO.BIM.QuestionAnswerEntity> quesAnsColl = new List<DTO.BIM.QuestionAnswerEntity>();
            foreach(KeyValuePair<string,string> KeyValue in securityDetails)
            {
                DTO.BIM.QuestionAnswerEntity quesAnsEntity = new DTO.BIM.QuestionAnswerEntity();
                quesAnsEntity.Question = KeyValue.Key;
                quesAnsEntity.Answer = KeyValue.Value;
                quesAnsColl.Add(quesAnsEntity);
            }
            return quesAnsColl.ToArray();
        }

        public static DTO.BIM.SelectBankByGUIDRequest ParseSelectAccountRequest(SelectBankAccountRequest request)
        {
            return new DTO.BIM.SelectBankByGUIDRequest()
            {
                bankaccount_guid = request !=null && request.Account !=null ? request.Account.Guid : null
            };
        }

        public static DTO.BIM.GenerateBarcodeRequest ParseGetBarcodeRequest(string deviceId, string hashedPin)
        {
            return new DTO.BIM.GenerateBarcodeRequest()
            {
                device = deviceId,
                hashed_pin = hashedPin
            };
        }
        public static DTO.BIM.ConsumerRewardRequest ParseConsumerRewardRequest(string deviceId)
        {
            return new DTO.BIM.ConsumerRewardRequest()
            {
                device = deviceId
            };
        }
        public static DTO.BIM.OfflineBarcodeRequest ParseOfflineBarcodesRequest(string deviceId, string barcodesRequested)
        {
            return new DTO.BIM.OfflineBarcodeRequest()
            {
                device = deviceId,
                barcodes_requested = barcodesRequested
            };
        }

        public static DTO.BIM.VerifyPinRequest ParseExistingPin(Pin pinDetails)
        {
            return new DTO.BIM.VerifyPinRequest()
            {
				consumer_id = pinDetails.ConsumerID,
                hashed_pin = pinDetails.ExistingPIN
            };
        }

        public static DTO.BIM.UpdatePinRequest ParseNewPin(Pin pinDetails)
        {
            return new DTO.BIM.UpdatePinRequest()
            {
                consumer_id = pinDetails.ConsumerID,
                hashed_pin = pinDetails.NewPIN
            };
        }
        public static DTO.BIM.SelectBankByIdRequest ParseSelectBankByIdRequest(int bankId)
        {
            return new DTO.BIM.SelectBankByIdRequest()
            {
                bank_id = Convert.ToString(bankId)
            };
        }
        public static DTO.BIM.MatchEnrollmentRequest ParseManualEnrollment(Account account)
        {
            return new DTO.BIM.MatchEnrollmentRequest()
            {
                aba = account.ABA,
                dda = account.DDA
            };
        }


        public static DTO.BIM.CheckCDWAllowRequest ParseCheckCDWAllow(bool updateWorkflow)
        {
            return new DTO.BIM.CheckCDWAllowRequest()
            {
                updateWorkflow = updateWorkflow ? "1" : "0"
            };
        }

        public static DTO.BIM.ConfirmCDWAmountRequest ParseConfirmCDWAmount(decimal depositAmount, decimal withdrawalAmount)
        {
            return new DTO.BIM.ConfirmCDWAmountRequest()
            {
                depositAmount = Convert.ToString(depositAmount),
                withdrawalAmount = Convert.ToString(withdrawalAmount),
            };
        }
        public static DTO.BIM.MerchantBarcodeSaleRequest ParseSaleTransaction(Transaction saleDetail)
        {
            return new DTO.BIM.MerchantBarcodeSaleRequest()
            {
                terminal_id = Constants.TERMINAL_ID,
                clerk_id = saleDetail.ClerkID,
                shift_id = saleDetail.ClerkID,
                batch_id = saleDetail.BatchID,
                barcode = saleDetail.Barcode,
                amount = saleDetail.Amount,
                rewardcode = saleDetail.RewardCode
            };
        }

        public static DTO.BIM.MerchantBarcodeVoidRequest ParseVoidTransaction(Transaction voidDetail)
        {
            return new DTO.BIM.MerchantBarcodeVoidRequest()
            {
                terminal_id = Constants.TERMINAL_ID,
                clerk_id = voidDetail.ClerkID,
                shift_id = voidDetail.ClerkID,
                batch_id = voidDetail.BatchID,
                barcode = voidDetail.Barcode,
                amount = voidDetail.Amount,
                auth_code = voidDetail.AuthCode,
                reference_number = voidDetail.ReferenceNo
            };
        }

        public static DTO.BIM.TransactionSummaryRequest ParseTransactionReportSummary(TransactionReport reportDetail)
        {
            return new DTO.BIM.TransactionSummaryRequest()
            {
                terminal_id = Constants.TERMINAL_ID,
                clerk_id = reportDetail.ClerkID,
                shift_id = reportDetail.ClerkID,
                batch_id = reportDetail.BatchID,
                current_page = reportDetail.CurrentPage,
                row_count = reportDetail.RowCount
            };
        }

        public static DTO.BIM.TransactionDetailsRequest ParseTransactionReportDetail(TransactionReport reportDetail)
        {
            return new DTO.BIM.TransactionDetailsRequest()
            {
                terminal_id = Constants.TERMINAL_ID,
                clerk_id = reportDetail.ClerkID,
                shift_id = reportDetail.ClerkID,
                batch_id = reportDetail.BatchID,
                current_page = reportDetail.CurrentPage,
                row_count = reportDetail.RowCount
            };
        }

    }
}
