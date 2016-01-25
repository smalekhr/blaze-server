﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UserSettingsLoadAllCommand
    {
        public static void HandleRequest(Client client, Request request)
        {
            Log.Info(string.Format("Client {0} loading all user settings for user {1}", client.ID, client.User.ID));

            if (File.Exists(string.Format(".\\data\\{0}\\user_settings", client.User.ID)))
            {
                var userSettings = File.ReadAllBytes(string.Format(".\\data\\{0}\\user_settings", client.User.ID));

                var data = new List<Tdf>
                {
                    new TdfMap("SMAP", TdfBaseType.String, TdfBaseType.String, new Dictionary<object, object>
                    {
                        { "cust", userSettings.ToString() }
                    })
                };

                client.Reply(request, 0, data);
            }
            else
            {
                client.Reply(request, 0, null);
            }
        }
    }
}
