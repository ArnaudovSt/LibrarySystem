using System;

namespace LibrarySystem.Services.Common.Contracts
{
    public interface IIdentityService
    {
        Guid GetUserId();

        string GetUsername();
    }
}