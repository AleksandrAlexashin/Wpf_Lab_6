using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApplication1
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string winddirection;
        private int windspeed;
        private int precipitation;
        enum Precipitationvalue
        {
            Солнечно = 0,
            Облачно,
            Дождь,
            Снег,
        }
        public string Winddirection
        {
            get { return winddirection; }
            set { winddirection = value; }
        }
        public int Windspeed
        {
            get { return windspeed; }
            set { if (value >= 0) { windspeed = value; } }
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public int Precipitation
        {
            get { return precipitation; }
            set { if (value >= 0 && value <= 3) { precipitation = value; } }

        }
        
                      

        public WeatherControl(string winddirection, int windspeed, int temperature, int precipitation)
        {
            this.Winddirection=winddirection;
            this.Windspeed=windspeed;
            this.Temperature=temperature;
            this.Precipitation=precipitation;
                      
        }
        
        static WeatherControl()
        {
            TemperatureProperty=DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.AffectsArrange|
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceWeatherControl)),
                    new ValidateValueCallback(ValidateWeatherControl));
        }
            
        private static bool ValidateWeatherControl(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50) { return true; } else { return false; }
        }

        private static object CoerceWeatherControl(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50) { return t; } else { return 0; }
        }
        public string Print()

        {
            return $"{Temperature} {(Precipitationvalue)Precipitation} {Winddirection} {Windspeed}";
        }

        
    }

}
