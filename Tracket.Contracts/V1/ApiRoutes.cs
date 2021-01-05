namespace Tracket.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";

        public const string Base = Root + "/" + Version;

        public static class Authentication
        {
            private const string AuthenticationBase = Base + "/auth";

            public const string Register = AuthenticationBase + "/register";
            public const string Login = AuthenticationBase + "/login";
        }

        public static class Roles
        {
            private const string RolesBase = Base + "/roles";

            public const string CreateRole = RolesBase + "/create";
            public const string GetRoles = RolesBase + "/get";
            public const string GetRole = RolesBase + "/{roleName}";
            public const string Delete = RolesBase + "/delete/{roleName}";
        }
    }
}