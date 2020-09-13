using ParavarejoApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParavarejoApp1.Services
{
    public class ParavarejoServices
    {
        private static ParavarejoServices _instance;

        public LucroRealModel LucroReal { get; set; }

        private ParavarejoServices()
        {
            LucroReal = new LucroRealModel();
        }

        public static ParavarejoServices GetInstance()
        {
            return _instance == null ? _instance = new ParavarejoServices() : _instance;
        }

    }
}
