﻿using System;
using Harvest.Net.Models;
using RestSharp;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        private IRestRequest ListRequest(string resource, DateTime? updatedSince)
        {
            var request = Request(resource);

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return request;
        }

        private IRestRequest Request(string resource, long resourceId, Method method, string action = null)
        {
            string resourceUrl = string.Format("{0}/{1}", resource, resourceId);

            if (!string.IsNullOrEmpty(action))
                resourceUrl = string.Format("{0}/{1}", resource, action);

            return Request(resourceUrl, method);
        }
        
        private IRestRequest CreateRequest<TOptions>(string resource, TOptions options)
        {
            return Request(resource, Method.POST).AddBody(options);
        }

        private IRestRequest UpdateRequest<TOptions>(string resource, long resourceId, TOptions options)
        {
            return Request(resource, resourceId, Method.PUT).AddBody(options);
        }
    }
}
