﻿using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("Teddy");

            Console.WriteLine(bear.Name);
        }
    }
}