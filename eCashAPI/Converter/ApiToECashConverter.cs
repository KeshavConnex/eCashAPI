using eCashAPI.DTO.BIM;
using eCashAPI.DTO.eCash;
using System;
using System.Collections.Generic;

namespace eCashAPI
{
    internal class ApiToECashConverter
    {
        #region Token
        public static TokenResponse ParseToken(GenerateTokenResponse response)
        {
            return new TokenResponse()
            {
                 Token = new Token()
                 {
                     AccessToken = response.access_token
                 }
            };
        }
        #endregion

        #region ParseEnrollment
        public static Enrollment ParseEnrollment(ServiceResponse response)
        {
            if (response != null)
            {
                return new Enrollment()
                {
                    Result = ParseResult(response),
                    Consumer = response.status.ToLower() == "true" ? new Consumer()
                    {
                        Id = response.payload != null ? Convert.ToInt32(response.payload.consumer_id) : 0,
                        FirstName = response.payload != null ? response.payload.fname : null,
                        LastName = response.payload != null ? response.payload.lname : null,
                        EmailAddress = response.payload != null ? response.payload.email_address : null
                    }: null
                };
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region ParsePersonalDetails
        public static PersonalDetailsResponse ParsePersonalDetails(ServiceResponse response, IBIMService bimService)
        {
            if (response != null)
            {
                return new PersonalDetailsResponse()
                {
                    Result = ParseResult(response),
                    BankList = GetBanks(response, bimService)
                };
            }
            return null;
        }
        private static List<Bank> GetBanks(ServiceResponse response, IBIMService bimService)
        {
            if(response !=null && response.status.ToLower() == "true")
            {
                var banks = new List<Bank>();
                var bankList = bimService.GetBankNamesIDAsync().Result;
                if (bankList != null)
                {
                    foreach (List<string> bankValue in bankList)
                    {
                        var bank = new Bank();
                        bank.Name = bankValue[0];
                        bank.Id = bankValue[1];
                        banks.Add(bank);
                    }
                    return banks;
                }
            }
            return null;
        }
        #endregion

        #region ParseSelectbank
        public static SelectBankResponse ParseSelectBank(ServiceResponse response)
        {
            if(response !=null)
            {
                return new SelectBankResponse()
                {
                    Result = ParseResult(response),
                    Bank = response.status.ToLower() == "true" ? new Bank()
                    {
                        Id = response.payload !=null ? response.payload.bank_id : null,
                        Name = response.payload != null ? response.payload.bank_display_name : null
                    } : null,
                    CustomField = ParseCustomFields(response)
                };
            }
            return null;
        }
        #endregion

        #region ParseBankLogin
        public static BankLoginResponse ParseBankLogin(ServiceResponse response)
        {
            if(response !=null)
            {
                return new BankLoginResponse()
                {
                    Result = ParseResult(response),
                    CustomField = ParseCustomFields(response),
                    Bank = new Bank()
                    {
                        Accounts = ParseAccount(response)
                    }
                };
            }
            return null;
        }
        #endregion

        #region ParseSecurityVerification
        public static SecurityVerificationResponse ParseSecurityVerification(ServiceResponse response)
        {
            if(response !=null)
            {
                return new SecurityVerificationResponse()
                {
                    Result = ParseResult(response),
                    Bank = response.payload != null && response.payload.bank_accounts != null ? new Bank()
                    {
                        Id = response.payload.bank_accounts[0].bank_id,
                         Accounts = response.status.ToLower() == "true" ? ParseAccount(response) : null
                    } : null
                };
            }
            return null;
        }
        #endregion

        #region ParseBarcode
        public static OfflineBarcodeResponse ParseOfflinrBarcode(ServiceResponse response)
        {
            if(response !=null)
            {
                return new OfflineBarcodeResponse()
                {
                    Result = ParseResult(response),
                    Barcode = response.status.ToLower() == "true" ? ParseBarcodes(response) : null
                };
            }
            return null;
        }
        public static BarcodeResponse ParseBarcode(ServiceResponse response)
        {
            if (response != null)
            {
                return new BarcodeResponse()
                {
                    Result = ParseResult(response),
                    Barcode = response.status.ToLower() == "true" ? new Barcode
                    {
                        Code = response.payload.barcode,
                        ExpirationDate = response.payload.expr_date
                    }:null
                };
            }
            return null;
        }
        #endregion

        #region ParseReward
        public static List<Reward> ParseRewards(ServiceResponse response)
        {
            if (response != null && response.payload !=null && response.payload.rewards !=null)
            {
                var rewards = new List<Reward>();
                foreach(DTO.BIM.Reward reward in response.payload.rewards)
                {
                    rewards.Add(new Reward() {
                       Id = reward.reward_id,
                       Code = reward.rewardcode,
                       Terms = reward.reward_terms,
                       Title = reward.reward_title
                    });
                }
                return rewards;
            }
            return null;
        }
        #endregion

        #region ParseTransactionSummary
        public static TransactionSummaryResponse ParseTransactionSummary(ServiceResponse response)
        {
            if (response != null)
            {
                return new TransactionSummaryResponse()
                {
                    Result = ParseResult(response),
                    Summary = response.status.ToLower() == "true" ? ParseSummaryReport(response) : null
                };
            }
            else
            {
                return null;
            }
        }
        private static List<DTO.eCash.TransactionSummary> ParseSummaryReport(ServiceResponse response)
        {
            if (response != null && response.payload != null && response.payload.transactionSummary != null)
            {
                var summary = new List<DTO.eCash.TransactionSummary>();
                foreach (DTO.BIM.TransactionSummary txnSummary in response.payload.transactionSummary)
                {
                    var newSummary = new DTO.eCash.TransactionSummary()
                    {
                        TransactionType = txnSummary.trans_type,
                        TransactionTypeDesc = txnSummary.trans_type_desc,
                        ClerkID = txnSummary.clerk_id,
                        BatchID = txnSummary.batch_id,
                        ShiftID = txnSummary.shift_id,
                        TransactionCount = txnSummary.count,
                        TotalAmount = txnSummary.total
                    };
                    summary.Add(newSummary);
                }
                return summary;
            }
            return null;
        }
        #endregion

        #region ParseTransactionDetail
        public static TransactionDetailResponse ParseTransactionDetail(ServiceResponse response)
        {
            if (response != null)
            {
                return new TransactionDetailResponse()
                {
                    Result = ParseResult(response),
                    Details = response.status.ToLower() == "true" ? ParseDetailReport(response) : null
                };
            }
            else
            {
                return null;
            }
        }
        private static List<DTO.eCash.TransactionDetail> ParseDetailReport(ServiceResponse response)
        {
            if (response != null && response.payload != null && response.payload.transactionDetail != null)
            {
                var details = new List<DTO.eCash.TransactionDetail>();
                foreach (DTO.BIM.TransactionDetail txnDetail in response.payload.transactionDetail)
                {
                    var newDetail = new DTO.eCash.TransactionDetail()
                    {
                        TransactionID = txnDetail.transaction_id,
                        TransactionType = txnDetail.trans_type,
                        TransactionTypeDesc = txnDetail.trans_type_desc,
                        Stamp = txnDetail.stamp,
                        TotalAmount = txnDetail.total_amount,
                        AuthCode = txnDetail.auth_code,
                        Barcode = txnDetail.barcode
                    };
                    details.Add(newDetail);
                }
                return details;
            }
            return null;
        }
        #endregion

        #region ParseMerchantBarcodeSale
        public static MerchantBarcodeSaleResponse ParseMerchantBarcodeSale(ServiceResponse response)
        {
            return new MerchantBarcodeSaleResponse()
            {
                Result = ParseResult(response)
            };
        }
        #endregion

        #region ParseMerchantBarcodeVoid
        public static MerchantBarcodeVoidResponse ParseMerchantBarcodeVoid(ServiceResponse response)
        {
            return new MerchantBarcodeVoidResponse()
            {
                Result = ParseResult(response)
            };
        }
        #endregion

        #region ParseChangePin
        public static ChangePinResponse ParseChangePin(ServicePinResponse response)
        {
            return new ChangePinResponse()
            {
                Result = ParsePinResult(response)
            };
        }
        #endregion

        #region ParseManualEnrollment
        public static ManualEnrollmentResponse ParseManualEnrollment(ServiceResponse response)
        {
            return new ManualEnrollmentResponse()
            {
                Result = ParseResult(response)
            };
        }
        #endregion

        #region ParseCDWAllowedResponse
        public static CDWAllowedResponse ParseCDWAllowedResponse(ServiceResponse response)
        {
            return new CDWAllowedResponse()
            {
                Result = ParseResult(response)
            };
        }
        #endregion

        #region Common
        private static List<Barcode> ParseBarcodes(ServiceResponse response)
        {
            var barcodes = new List<Barcode>();
            if (response !=null && response.payload !=null && response.payload.barcodes !=null)
            {
                for (int i = 0; i < response.payload.barcodes.Length; i++)
                {
                    var barcode = new Barcode
                    {
                        Code = response.payload.barcodes[i],
                        ExpirationDate = response.payload.expr_dates[i]
                    };
                    barcodes.Add(barcode);
                }
            }
            return barcodes;
        }
        private static Result ParseResult(ServiceResponse response)
        {
            if (response != null)
            {
                return new Result()
                {
                    Status = Convert.ToBoolean(response.status.ToLower()),
                    Message = response.messages,
                    Redirect = response.payload != null ? response.payload.redirect : null,
                    Fallback = response.payload != null ? response.payload.fallback : null
                };
            }
            return null;
        }

        private static Result ParsePinResult(ServicePinResponse response)
        {
            if (response != null)
            {
                return new Result()
                {
                    Status = Convert.ToBoolean(response.status.ToLower()),
                    Message = response.messages
                };
            }
            return null;
        }

        private static List<CustomField> ParseCustomFields(ServiceResponse response)
        {
            if (response != null && response.payload != null && response.payload.field_table != null)
            {
                List<FieldTableEntity> fieldTableColl = CommonFunction.GetCustomFieldCollection(response.payload);
                var customFields = new List<CustomField>();
                foreach (FieldTableEntity fields in fieldTableColl)
                {
                    var customField = new CustomField()
                    {
                        Choices = fields.choices,
                        DisplayName = fields.displayName,
                        FieldType = fields.fieldType,
                        Identifier = fields.valueIdentifier,
                        MaxLength = fields.maxLength,
                        FieldOrder = Array.IndexOf(response.payload.field_index, fields.valueIdentifier)
                    };
                    customFields.Add(customField);
                }
                return customFields;
            }
            return null;
        }
        private static List<Account> ParseAccount(ServiceResponse response)
        {
            if (response != null && response.payload != null && response.payload.bank_accounts != null)
            {
                var accounts = new List<Account>();
                foreach (BankAccount bankAccount in response.payload.bank_accounts)
                {
                    var account = new Account()
                    {
                        ABA = bankAccount.aba,
                        DDA = bankAccount.dda,
                        Alias = bankAccount.account_alias,
                        Guid = bankAccount.bank_account_guid
                    };
                    accounts.Add(account);
                }
                return accounts;
            }
            return null;
        }
        #endregion
    }
}
