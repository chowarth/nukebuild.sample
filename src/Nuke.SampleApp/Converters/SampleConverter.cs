using System;
using System.Globalization;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Nuke.SampleApp.Converters
{
    internal class SampleConverter : IValueConverter
    {
        private readonly IDeviceInfo _deviceInfo;

        public SampleConverter(IDeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _deviceInfo.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
