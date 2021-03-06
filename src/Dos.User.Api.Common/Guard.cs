using System;

namespace Dos.User.Api.Common
{
    public static class Guard
    {
        public static T IsNotNull<T>(T instance, string message)
           where T : class
        {
            if (instance is null)
                throw new ArgumentNullException(message);

            return instance;
        }
    }
}
