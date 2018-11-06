using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public static class UserManagerExtensions
    {
        //public static IdentityResult AccessFailed<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult AddClaim<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, Claim claim)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult AddLogin<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, UserLoginInfo login)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult AddPassword<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string password)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;

        public static IdentityResult AddUserToRole<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string role)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            var rolesForUser = manager.GetRoles(userId);
            if (!rolesForUser.Contains(role))
                return manager.AddToRole(userId, role);
            return null;
        }
        public static void AddUserToRoles<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, params string[] roles)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            foreach (var item in roles)
                manager.AddUserToRole(userId, item);
        }

        //public static IdentityResult ChangePassword<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string currentPassword, string newPassword)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult ChangePhoneNumber<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string phoneNumber, string token)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool CheckPassword<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user, string password)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult ConfirmEmail<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string token)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;

        public static IdentityResult CreateUser<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            //var result = manager.FindByName(user.UserName);
            if (manager.FindByName(user.UserName) == null)
            {
                var result = manager.Create(user);
                manager.SetLockoutEnabled(user.Id, false);
                return result;
            }
            return null;
        }
        public static IdentityResult CreateUser<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user, string password)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            //var result = manager.FindByName(user.UserName);
            if (manager.FindByName(user.UserName) == null)
            {
                var result = manager.Create(user, password);
                manager.SetLockoutEnabled(user.Id, false);
                return result;
            }
            return null;
        }
        public static IdentityResult CreateUser<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user, string password, string role)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            var result = manager.CreateUser(user, password);
            manager.AddUserToRole(user.Id, role);
            return result;
        }
        public static IdentityResult CreateUser<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user, string password, params string[] roles)
            where TUser : class, IUser<TKey>
            where TKey : IEquatable<TKey>
        {
            var result = manager.CreateUser(user, password);
            manager.AddUserToRoles(user.Id, roles);
            return result;
        }

        //public static ClaimsIdentity CreateIdentity<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user, string authenticationType)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult Delete<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static TUser Find<TUser, TKey>(this UserManager<TUser, TKey> manager, string userName, string password)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static TUser Find<TUser, TKey>(this UserManager<TUser, TKey> manager, UserLoginInfo login)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static TUser FindByEmail<TUser, TKey>(this UserManager<TUser, TKey> manager, string email)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static TUser FindById<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static TUser FindByName<TUser, TKey>(this UserManager<TUser, TKey> manager, string userName)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GenerateChangePhoneNumberToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string phoneNumber)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GenerateEmailConfirmationToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GeneratePasswordResetToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GenerateTwoFactorToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string providerId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GenerateUserToken<TUser, TKey>(this UserManager<TUser, TKey> manager, string purpose, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static int GetAccessFailedCount<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IList<Claim> GetClaims<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GetEmail<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool GetLockoutEnabled<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static DateTimeOffset GetLockoutEndDate<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IList<UserLoginInfo> GetLogins<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GetPhoneNumber<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IList<string> GetRoles<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static string GetSecurityStamp<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool GetTwoFactorEnabled<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IList<string> GetValidTwoFactorProviders<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool HasPassword<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool IsEmailConfirmed<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool IsInRole<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string role)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool IsLockedOut<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool IsPhoneNumberConfirmed<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult NotifyTwoFactorToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string twoFactorProvider, string token)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult RemoveClaim<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, Claim claim)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult RemoveFromRole<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string role)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult RemoveFromRoles<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, params string[] roles)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult RemoveLogin<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, UserLoginInfo login)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult RemovePassword<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult ResetAccessFailedCount<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult ResetPassword<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string token, string newPassword)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static void SendEmail<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string subject, string body)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static void SendSms<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string message)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult SetEmail<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string email)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult SetLockoutEnabled<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, bool enabled)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult SetLockoutEndDate<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, DateTimeOffset lockoutEnd)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult SetPhoneNumber<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string phoneNumber)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult SetTwoFactorEnabled<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, bool enabled)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult Update<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static IdentityResult UpdateSecurityStamp<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool VerifyChangePhoneNumberToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string token, string phoneNumber)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool VerifyTwoFactorToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string providerId, string token)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
        //public static bool VerifyUserToken<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string purpose, string token)
        //    where TUser : class, IUser<TKey>
        //    where TKey : IEquatable<TKey>;
    }
}