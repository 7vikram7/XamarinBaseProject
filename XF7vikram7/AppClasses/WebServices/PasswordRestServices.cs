namespace XF7vikram7.AppClasses.WebServices
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using XF7vikram7.AppClasses.Common.Statics;
    using XF7vikram7.AppClasses.DataModels;
    using XF7vikram7.AppClasses.WebServices;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class PasswordRestServices : BaseRestService
    {
        #region Fields
        private static PasswordRestServices instance;

        #endregion

        #region Constructor
        public PasswordRestServices()
        {
        }

        #endregion

        #region Properties
        public static PasswordRestServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PasswordRestServices();
                }

                // TODO: Update Headers when needed
                // if (client != null)
                // {
                //    if (!client.DefaultRequestHeaders.Contains("ZUMO-API-VERSION"))
                //    {
                //        client.DefaultRequestHeaders.Remove("ZUMO-API-VERSION");
                //        client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", ApiConstants.API_VERSION);
                //    }
                //    string sessionKey = DependencyService.Get<ISessionKey>().SessionKey;
                //    if (sessionKey != null && !sessionKey.Equals(""))
                //    {
                //        client.DefaultRequestHeaders.Remove("Authorization");
                //        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", DependencyService.Get<ISessionKey>().SessionKey);
                //    }
                // }
                return instance;
            }
        }

        #endregion

        #region Events
        #endregion

        #region Public Methods
        public async Task<bool> ChangePassword(
            string oldPassword,
            string newPassword,
            string userId,
            CancellationToken ct,
            Action<ErrorModel> errorAction)
        {
            string sessionId = string.IsNullOrEmpty(SessionData.Instance.SessionId) ?
                               string.Empty : SessionData.Instance.SessionId;

            var url = AppConstants.ApiBaseURL +
                      string.Format(
                          "ChangePassword?CustomerID={0}&SessionID={1}&OldPassword={2}&NewPassword={3}",
                          userId,
                          sessionId,
                          oldPassword,
                          newPassword);
            try
            {
                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(new object());
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await Client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    var status = response.StatusCode;
                    errorAction?.Invoke(new ErrorModel(status, message));
                    return default(bool);
                }

                var output = await response.Content.ReadAsStringAsync();

                return true;
            }
            catch (Exception ex)
            {
                errorAction?.Invoke(new ErrorModel(ex.Message));
                return default(bool);
            }
        }

        public async Task<bool> ForgotPassword(
            string email,
            CancellationToken ct,
            Action<ErrorModel> errorAction)
        {
            var url = AppConstants.ApiBaseURL +
                      string.Format(
                          "ForgotPassword?Email={0}",
                          email);
            try
            {
                var response = await Client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    var status = response.StatusCode;
                    errorAction?.Invoke(new ErrorModel(status, message));
                    return default(bool);
                }

                var output = await response.Content.ReadAsStringAsync();

                return true;
            }
            catch (Exception ex)
            {
                errorAction?.Invoke(new ErrorModel(ex.Message));
                return default(bool);
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
