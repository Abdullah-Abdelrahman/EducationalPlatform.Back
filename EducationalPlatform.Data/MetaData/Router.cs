﻿namespace EducationalPlatform.Data.MetaData
{
    public static class Router
    {

        public const string Root = "/Api";
        public const string Rule = Root + "/";


        public static class CourseRouter
        {
            public const string prefix = Rule + "Course/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";

        }

        public static class UserRouter
        {
            public const string prefix = Rule + "UserApp/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";

            public const string ChangePassword = prefix + "ChangePassword";

        }

        public static class AuthenticationRouter
        {
            public const string prefix = Rule + "Authentication/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string SignIn = prefix + "SignIn";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";


        }

        public static class AuthorizationRouter
        {
            public const string prefix = Rule + "Authorization/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";


        }


        public static class AnswerRouter
        {
            public const string prefix = Rule + "Answer/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";


        }
    }
}
