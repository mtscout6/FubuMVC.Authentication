﻿using FubuMVC.ContentExtensions;
using FubuMVC.Core;

namespace FubuMVC.Authentication.Twitter
{
    public class ApplyTwitterAuthentication : IFubuRegistryExtension
    {
        private OAuthSettings _settings = new OAuthSettings();

        void IFubuRegistryExtension.Configure(FubuRegistry registry)
        {
            registry.Actions.FindWith<TwitterEndpoints>();
            registry.Services<TwitterServiceRegistry>();
            registry.Policies.Add<AttachDefaultTwitterView>();

            registry.Services(x => x.SetServiceIfNone(_settings));

            registry.Extensions().For(new TwitterContentExtension());
        }

        public void UseOAuthSettings(OAuthSettings settings)
        {
            _settings = settings;
        }
    }
}