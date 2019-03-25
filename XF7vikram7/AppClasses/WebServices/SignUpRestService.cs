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

    public class SignUpRestService : BaseRestService
    {
        #region Fields

        private static SignUpRestService instance;

        #endregion

        #region Constructor
        public SignUpRestService()
        {
        }

        #endregion

        #region Properties
        public static SignUpRestService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SignUpRestService();
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
        public async Task<SessionDataModel> CreateAccount(
            string name,
            string email,
            string phone,
            string password,
            CancellationToken ct,
            Action<ErrorModel> errorAction)
        {
            var url = AppConstants.ApiBaseURL +
                      string.Format(
                          "CreateAccount?Name={0}&Phone={1}&Email={2}&Password={3}",
                          name,
                          phone,
                          email,
                          password);
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
                    return default(SessionDataModel);
                }

                var output = await response.Content.ReadAsStringAsync();

                List<SessionDataModel> resultList =
                    JsonConvert.DeserializeObject<List<SessionDataModel>>(output);

                if (resultList.Count > 0)
                {
                    return resultList[0];
                }

                return default(SessionDataModel);
            }
            catch (Exception ex)
            {
                errorAction?.Invoke(new ErrorModel(ex.Message));
                return default(SessionDataModel);
            }
        }

        public async Task<SessionDataModel> Login(
            string email,
            string password,
            CancellationToken ct,
            Action<ErrorModel> errorAction)
        {
            var url = AppConstants.ApiBaseURL +
                      string.Format(
                          "Login?Email={0}&Password={1}",
                          email,
                          password);
            try
            {
                var response = await Client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    var status = response.StatusCode;
                    errorAction?.Invoke(new ErrorModel(status, message));
                    return default(SessionDataModel);
                }

                var output = await response.Content.ReadAsStringAsync();

                List<SessionDataModel> resultList =
                    JsonConvert.DeserializeObject<List<SessionDataModel>>(output);

                if (resultList.Count > 0)
                {
                    return resultList[0];
                }

                return default(SessionDataModel);
            }
            catch (Exception ex)
            {
                errorAction?.Invoke(new ErrorModel(ex.Message));
                return default(SessionDataModel);
            }
        }

        public async Task<bool> Logout(
            string customerId,
            CancellationToken ct,
            Action<ErrorModel> errorAction)
        {
            string sessionId = string.IsNullOrEmpty(SessionData.Instance.SessionId) ?
                               string.Empty : SessionData.Instance.SessionId;

            var url = AppConstants.ApiBaseURL +
                      string.Format(
                          "Logout?CustomerID={0}&SessionID={1}",
                          customerId,
                          sessionId);
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

        #endregion

        #region Private Methods
        #endregion
    }
}
