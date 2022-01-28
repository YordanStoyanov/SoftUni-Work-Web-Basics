namespace MyWebServer.Server.Common
{
    using System;
    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "value";
                throw new ArgumentException($"{name} can not be null.");
            }
        }
    }
}
