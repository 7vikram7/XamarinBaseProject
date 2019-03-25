namespace XF7vikram7.AppClasses.WebServices
{
    using System;
    using System.Net.Http;

    public class BaseRestService
    {
        #region Fields
        public const int KStatusCode200 = 200;
        public const int KStatusCode400 = 400;
        public const int KStatusCode401 = 401;
        public const int KStatusCode403 = 403;
        public const int KStatusCode404 = 404;
        #endregion

        #region Constructor
        public BaseRestService()
        {
            if (Client == null)
            {
                Client = new HttpClient();
                Client.Timeout = TimeSpan.FromSeconds(30);
            }
        }

        #endregion

        #region Properties
        protected static HttpClient Client
        {
            get;
            set;
        }

        #endregion

        #region Events
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
