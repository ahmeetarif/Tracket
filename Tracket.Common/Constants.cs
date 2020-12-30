namespace Tracket.Common
{
    public static class Constants
    {
        public static class LocalizeKeys
        {
            public static class Password
            {
                public const string Empty = "EmptyPassword";
                public const string Length = "PasswordLength";
                public const string Uppercase = "PasswordUpercase";
                public const string Lowercase = "PasswordLowercase";
                public const string Number = "PasswordNumber";
            }

            public static class Email
            {
                public const string Empty = "EmptyEmail";
                public const string Valid = "NotValidEmail";
            }

            public static class Username
            {
                public const string Empty = "EmptyUsername";
            }

            public static class Fullname
            {
                public const string Empty = "EmptyFullname";
                public const string Length = "";
            }

            public const string RoleNotFound = "RoleNotFoundMessage";
            public const string UserNotFound = "UserNotFoundMessage";
            public const string ProvideRequiredInformation = "ProvideRequiredInformation";
        }
    }
}