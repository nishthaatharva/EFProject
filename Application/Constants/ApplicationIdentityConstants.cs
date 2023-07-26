﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class ApplicationIdentityConstants
    {
        public class Roles
        {
            public static readonly string Administrator = "Administrator";
            public static readonly string Member = "Member";

            public static readonly string[] RolesSupported = { Administrator, Member };
        }

        public static readonly string DefaultPassword = "Password@1";
    }
}
