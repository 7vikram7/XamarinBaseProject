namespace XF7vikram7.AppClasses.DataModels
{
    using System;
    using System.Collections.Generic;
    using XF7vikram7;
    using Xamarin.Forms;
    using XF7vikram7.AppClasses.PagesAndViewModels.LeftMenuMaster;

    public sealed class SessionData
    {
        #region SingletonAndInitialisation

        public const string KName = "Name";
        public const string KEmail = "Email";
        public const string KPhone = "Phone";
        public const string KSessionId = "SessionId";
        public const string KUserId = "UserId";

        private static readonly object Padlock = new object();
        private static SessionData instance = null;

        public SessionData()
        {
        }

        public static SessionData Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SessionData()
                            {
                                UserId = string.Empty,
                                SessionId = string.Empty,
                                Name = string.Empty,
                                Phone = string.Empty,
                                Email = string.Empty
                            };
                        }
                    }
                }

                return instance;
            }
        }
        #endregion

        #region Properties
        public string UserId
        {
            get;
            set;
        }

        public string SessionId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public List<LeftMenuItemModel> LeftMenuItems
        {
            get
            {
                List<LeftMenuItemModel> list = new List<LeftMenuItemModel>();
                list.Add(new LeftMenuItemModel
                {
                    Title = "First Item"
                });
                list.Add(new LeftMenuItemModel
                {
                    Title = "Second Item"
                });
                list.Add(new LeftMenuItemModel
                {
                    Title = "Third Item"
                });
                return list;
            }
        }
        #endregion

        #region Public Methods

        public static void SetDataFromSessionDataModel(SessionDataModel
                sessionDataModel)
        {
            SessionData.Instance.Name = sessionDataModel.Name;
            SessionData.Instance.Email = sessionDataModel.Email;
            SessionData.Instance.Phone = sessionDataModel.Phone;
            SessionData.Instance.SessionId = sessionDataModel.SessionId;
            SessionData.Instance.UserId = sessionDataModel.UserId;
            SessionData.SaveSessionToPropertiesPersistently();
        }

        public static void PopulateSessionDataFromProperties()
        {
            if (Application.Current.Properties.ContainsKey(SessionData.KName))
            {
                SessionData.Instance.Name = Application.Current.Properties[KName] as string;
            }

            if (Application.Current.Properties.ContainsKey(SessionData.KEmail))
            {
                SessionData.Instance.Email = Application.Current.Properties[KEmail] as string;
            }

            if (Application.Current.Properties.ContainsKey(SessionData.KPhone))
            {
                SessionData.Instance.Phone = Application.Current.Properties[KPhone] as string;
            }

            if (Application.Current.Properties.ContainsKey(SessionData.KUserId))
            {
                SessionData.Instance.UserId = Application.Current.Properties[KUserId] as
                                              string;
            }

            if (Application.Current.Properties.ContainsKey(SessionData.KSessionId))
            {
                SessionData.Instance.SessionId = Application.Current.Properties[KSessionId] as
                                                 string;
            }
        }

        public static void DeleteSessionDataFromProperties()
        {
            Application.Current.Properties.Remove(KName);
            Application.Current.Properties.Remove(KEmail);
            Application.Current.Properties.Remove(KPhone);
            Application.Current.Properties.Remove(KUserId);
            Application.Current.Properties.Remove(KSessionId);
            Application.Current.SavePropertiesAsync();
        }

        public static void ClearCacheSessionData()
        {
            SessionData.instance = null;
        }

        #endregion

        #region Private Methods

        private static async void SaveSessionToPropertiesPersistently()
        {
            SessionData.SaveKeyValueToProperties(KName, SessionData.Instance.Name);
            SessionData.SaveKeyValueToProperties(KEmail, SessionData.Instance.Email);
            SessionData.SaveKeyValueToProperties(KPhone, SessionData.Instance.Phone);
            SessionData.SaveKeyValueToProperties(KUserId, SessionData.Instance.UserId);
            SessionData.SaveKeyValueToProperties(
                KSessionId,
                SessionData.Instance.SessionId);

            await Application.Current.SavePropertiesAsync();
        }

        private static void SaveKeyValueToProperties(string key, object value)
        {
            if (key != null && value != null)
            {
                if (Application.Current.Properties.ContainsKey(key))
                {
                    Application.Current.Properties[key] = value;
                }
                else
                {
                    Application.Current.Properties.Add(key, value);
                }
            }
        }

        #endregion
    }
}
