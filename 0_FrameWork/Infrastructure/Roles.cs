namespace _0_FrameWork.Infrastructure
{
    public static class Roles
    {
        public const string Administration = "1";
        public const string SystemUser = "2";
        public const string ContentUploader = "10002";
        public const string ShopAdmin = "10003";

        public static string GetByRole(long roleId)
        {
            switch (roleId)
            {
                case 1: return "مدیر سیستم";
                case 10002: return "محتوا گذار";
                case 10003: return "مدیر فروشگاه";
                default: return "";
            }


        }        }
    }
