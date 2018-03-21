﻿using System.Web.Http;

using TestTask.SDK.Providers;
using TestTask.SDK.Models;
using System.Text.RegularExpressions;
using System.Web;

namespace TestTask.WebAPI.Controllers
{
    public class FeedController : ApiController
    {
        private const string _valideUrlRegex = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
        
        public IFeedCollection<IFeed> Get(ProviderType providerType, string encodedUrl)
        {
            if (string.IsNullOrEmpty(encodedUrl) || !Regex.IsMatch(encodedUrl, _valideUrlRegex))
                return null;

            return ProvidersFactory.GetProvider(providerType).GetFeedCollection(HttpUtility.HtmlDecode(encodedUrl));
        }

        public string Post(string idCollection, IFeed feed)
        {
            if (feed == null || string.IsNullOrEmpty(idCollection))
                return null;

            return CacheFactory.GetCacher().AddFeedIntoCollection(idCollection, feed);
        }

    }
}