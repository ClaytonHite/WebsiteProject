﻿namespace WebsiteProjectCarpetMart.ViewModels
{
	public class WeatherViewModel
	{
        public int index { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public string Name { get; set; }
        public int Temp { get; set; }
        public string WeatherWarning { get; set; }
        public float FeelsLike { get; set; }
        public string SkyCondition { get; set; }
        public string AirCondition { get; set; }
    }
}
