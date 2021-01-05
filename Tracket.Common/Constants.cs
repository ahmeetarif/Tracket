namespace Tracket.Common
{
    public static class Constants
    {
        public static class LocalizedValueKeys
        {
            public static class Messages
            {
                public const string PleaseProvideRequiredInformationMessage = "PleaseProvideRequiredInformationMessage";
                public const string UserNotFoundMessage = "UserNotFoundMessage";
                public const string UserNotFoundWithProvidedEmailAddress = "UserNotFoundWithProvidedEmailAddress";
                public const string InternalServerExceptionMessage = "InternalServerExceptionMessage";
                public const string RoleNotFoundMessage = "RoleNotFoundMessage";
                public const string RoleAlreadyExistMessage = "RoleAlreadyExistMessage";
                public const string BadRequestExceptionMessage = "BadRequestExceptionMessage";
                public const string RoleAddedSuccessfullyMessage = "RoleAddedSuccessfullyMessage";
                public const string NotFoundExceptionMessage = "NotFoundExceptionMessage";
                public const string RoleDeletedMessage = "RoleDeletedMessage";
            }

            public static class Password
            {
                public const string InvalidPasswordMessage = "InvalidPasswordMessage";
                public const string EmptyPasswordValidationMessage = "EmptyPasswordValidationMessage";
                public const string PasswordMinimumLengthValidationMessage = "PasswordMinimumLengthValidationMessage";
                public const string PasswordShouldContainUppercasedWordValidationMessage = "PasswordShouldContainUppercasedWordValidationMessage";
                public const string PasswordShouldContainLowercasedWordValidationMessage = "PasswordShouldContainLowercasedWordValidationMessage";
                public const string PasswordShouldContainNumberValidationMessage = "PasswordShouldContainNumberValidationMessage";
            }

            public static class Email
            {
                public const string EmptyEmailValidationMessage = "EmptyEmailValidationMessage";
                public const string NotValidEmailValidationMessage = "NotValidEmailValidationMessage";
            }


            public static class Username
            {
                public const string EmptyUsernameValidationMessage = "EmptyUsernameValidationMessage";
                public const string NotValidUsernameValidationMessage = "NotValidUsernameValidationMessage";
            }

            public static class Fullname
            {
                public const string EmptyFullnameValidationMessage = "EmptyFullnameValidationMessage";
                public const string NotValidFullnameValidationMessage = "NotValidFullnameValidationMessage";
            }
        }
    }
}