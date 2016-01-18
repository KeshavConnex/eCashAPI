using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashAPI
{
    public static class CommonFunction
    {
        public static Result ParseException(Exception e)
        {
            if (e != null)
            {
                if (e.InnerException is ApiException)
                {
                    var apiException = (ApiException)e.InnerException;
                    return apiException != null ? new Result()
                    {
                        Status = false,
                        Message = new[] { apiException.ReasonPhrase }
                    } : null;
                }
                return e != null ? new Result()
                {
                    Status = false,
                    Message = new[] { "Internal System Error" }
                    //Message = new[] { e.Message }
                } : null;
            }
            return null;
        }
        public static List<DTO.BIM.FieldTableEntity> GetCustomFieldCollection(DTO.BIM.Payload payload)
        {
            List<DTO.BIM.FieldTableEntity> fieldTableEntityColl = new List<DTO.BIM.FieldTableEntity>();

            if (payload !=null && payload.field_index != null)
            {
                int FieldCollection = payload.field_index.Length;
                if (FieldCollection > 0)
                {
                    string FieldTableValues = payload.field_table.ToString();
                    foreach (string strFieldVal in payload.field_index)
                    {
                        int StartIndex = FieldTableValues.IndexOf("\"" + strFieldVal + "\"");
                        int EndIndex = FieldTableValues.IndexOf("}", StartIndex);

                        string strClassValues = FieldTableValues.Substring(StartIndex, (EndIndex - StartIndex) + 1);

                        int StartIndexClass = strClassValues.IndexOf("{");
                        int EndIndexClass = strClassValues.IndexOf("}", StartIndexClass);

                        strClassValues = strClassValues.Substring(StartIndexClass, (EndIndexClass - StartIndexClass) + 1);
                        DTO.BIM.FieldTableEntity fieldTableEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.BIM.FieldTableEntity>(strClassValues);
                        fieldTableEntityColl.Add(fieldTableEntity);
                        fieldTableEntity = null;
                    }
                }
            }

            return fieldTableEntityColl;
        }

    }
}
