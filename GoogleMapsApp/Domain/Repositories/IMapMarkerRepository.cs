using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMapMarkerRepository
    {
        void Update(MapMarker newEntity);
        IEnumerable<MapMarker> Read();
        bool IsConnectionOpen();
        Task OpenAsync();
        void Open();
        
        void Close();

    }
}