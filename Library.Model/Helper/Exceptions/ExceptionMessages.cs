using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Helper.Exceptions
{
    public static class ExceptionMessages
    {
        public const string SomethingWentWrong = "کاربر گرامی\nمشکلی پیش آمد لطفا با پشتیبانی تماس بگیرید.";
        public static string InsertSuccess(string target) => string.Format("{0}با موفقیت اضافه شد.", target);
        public static string UpdateSuccess(string target) => string.Format("{0}با موفقیت ویرایش شد.", target);
    }
}
