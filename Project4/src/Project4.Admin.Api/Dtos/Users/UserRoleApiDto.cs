// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

namespace Project4.Admin.Api.Dtos.Users
{
    public class UserRoleApiDto<TKey>
    {
        public TKey UserId { get; set; }

        public TKey RoleId { get; set; }
    }
}







