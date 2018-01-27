﻿using SchoolNotify.Infrastructure.Data.Interfaces.Management;
using System.Data.Entity;
using System.Web;

namespace SchoolNotify.Infrastructure.Data.Context
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";
        public DbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new SchoolNotifyContext();
            }

            return (DbContext)HttpContext.Current.Items[ContextKey];
        }
    }
}
