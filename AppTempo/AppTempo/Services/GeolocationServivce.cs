using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppTempo.Services
{
    public class GeolocationService
    {
        public async Task<Tuple<double, double>> GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    double latitude = location.Latitude;
                    double longitude = location.Longitude;

                    return Tuple.Create(latitude, longitude);
                }
            }
            catch (FeatureNotSupportedException)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException)
            {
                // Handle permission exception
            }
            catch (Exception)
            {
                // Unable to get location
            }

            return Tuple.Create(0.0, 0.0);
        }
    }
}
