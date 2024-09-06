using System;
using System.Globalization;

namespace Util {
    public static class Color {



        public static uint HexToUINT (string hexCode) => uint.Parse (hexCode.Replace ("#", "").ToString (), NumberStyles.HexNumber);

        public static uint EXIT_RED = HexToUINT ("#eb695f");
        public static uint EXIT_BORDER_RED = HexToUINT ("#cf4e42");

        public static uint MINIMIZE_YELLOW = HexToUINT ("#f5c04e");
        public static uint MINIMIZE_BORDER_YELLOW = HexToUINT ("#d49f3d");

        public static uint MAXIMIZE_GREEN = HexToUINT ("#67c654");
        public static uint MAXIMIZE_BORDER_GREEN = HexToUINT ("#55a73c");
    }
}
