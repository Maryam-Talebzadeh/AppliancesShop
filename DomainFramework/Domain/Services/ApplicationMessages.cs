﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Framework.Domain.Services
{
    public class ApplicationMessages
    {
        public const string DuplicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد. لطفا مجدد تلاش بفرمایید.";
        public const string RecordNotFound = "رکورد با اطلاعات درخواست شده یافت نشد. لطفا مجدد تلاش بفرمایید.";
        public static string PasswordsNotMatch = "پسورد و تکرار آن با هم مطابقت ندارند";
        public static string WrongUserPass = "نام کاربری یا کلمه رمز اشتباه است";
        public const string CreationFailed = "عملیات ساخت به شکست انجامید.";

    }
}
