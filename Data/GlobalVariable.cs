﻿namespace FlashcardLibrary.Data
{
    public class GlobalVariable
    {
        public static int GlobalYesFlag = 1;
        public static int GlobalNoFlag = 0;

        public static readonly HttpClient client = new();
    }
}
