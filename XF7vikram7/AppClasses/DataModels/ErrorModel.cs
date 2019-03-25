namespace XF7vikram7.AppClasses.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Newtonsoft.Json;

    public class ErrorModel
    {
        private string genericError =
            "Oops! Something went wrong, Please try again later.";

        private string exception;
        private HttpStatusCode status;
        private string message;

        public ErrorModel(string exception)
        {
            this.exception = exception;
        }

        public ErrorModel(HttpStatusCode status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public HttpStatusCode Status
        {
            get
            {
                return this.status;
            }
        }

        public string Message
        {
            get
            {
                try
                {
                    if (this.message != null)
                    {
                        var errorModelContract =
                            JsonConvert.DeserializeObject<List<ErrorModelContract>>(this.message);
                        if (errorModelContract != null && errorModelContract.Count > 0
                                && !errorModelContract[0].Text.Trim().Equals(string.Empty))
                        {
                            return errorModelContract[0].Text;
                        }
                        else
                        {
                            return this.genericError;
                        }
                    }
                    else
                    {
                        return this.genericError;
                    }
                }
                catch
                {
                    return this.genericError;
                }
            }
        }
    }
}
