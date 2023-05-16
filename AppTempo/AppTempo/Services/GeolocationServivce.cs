using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace AppTempo.Services
{
    public class GeolocationService
    {
        public async Task<Position> GetLocation()
        {
            try
            {
                //var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    double latitude = location.Latitude;
                    double longitude = location.Longitude;

                    return new Position(latitude, longitude);
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

            return new Position(0.0, 0.0);
        }

        public async Task<string> GetCity(Position position)
        {
            Geocoder geoCoder = new Geocoder();

            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
            return possibleAddresses.FirstOrDefault().Split(',').ElementAt(2);
        }
    }
}
