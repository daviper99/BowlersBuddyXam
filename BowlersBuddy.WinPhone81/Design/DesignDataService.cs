﻿using System.Threading.Tasks;
using BowlersBuddy.WinPhone81.Model;

namespace BowlersBuddy.WinPhone81.Design
{
    public class DesignDataService : IDataService
    {
        public Task<DataItem> GetData()
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            return Task.FromResult(item);
        }
    }
}