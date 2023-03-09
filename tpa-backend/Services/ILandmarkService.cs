using tpa_backend.Data;
using tpa_backend.DTOModels;

namespace tpa_backend.Services
{
    public interface ILandmarkService
    {
        public List<LandmarkViewDTO> GetLandmarks();
    }

    public class LandmarkService : ILandmarkService
    {
        private AppDbContext _context;
        public LandmarkService(AppDbContext context)
        {
            _context=context;
        }

        public List<LandmarkViewDTO> GetLandmarks()
        {
            var landmarks=_context.Landmarks.Select(x => new LandmarkViewDTO
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                VisitTime = x.VisitTime,
                City=x.City,
                NorthernLatitude=x.NorthernLatitude,
                EasternLatitude=x.EasternLatitude,
                MaxAge=x.MaxAge,
                MinAge=x.MinAge,
                Difficulty=x.Difficulty,
            }).ToList();

            return landmarks;
        }
    }
}
