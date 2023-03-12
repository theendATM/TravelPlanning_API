using Microsoft.EntityFrameworkCore;
using System.Linq;
using tpa_backend.Data;
using tpa_backend.DTOModels;

namespace tpa_backend.Services
{
    public interface ISelectInfoService
    {
        public List<CityViewDTO> GetCities();
        public List<MovingTypeViewDTO> GetMovingTypes();
        public List<DifficultyViewDTO> GetDifficulties();
        public List<InterestViewDTO> GetInterests();
        public List<LandmarkViewDTO> GetMereLandmarks(MereLandmarkViewModel dto);
    }

    public class SelectInfoService : ISelectInfoService
    {
        AppDbContext _context;
        public SelectInfoService(AppDbContext context)
        {
            _context=context;
        }

        public List<CityViewDTO> GetCities()
        {
            var cities =_context.Cities.Select(c => new CityViewDTO
            {
                Name = c.Name,
            }).ToList();

            return cities;
        }

        public List<DifficultyViewDTO> GetDifficulties()
        {
            var diffs = _context.Difficulties.Select(c => new DifficultyViewDTO
            {
                Name = c.Name,
            }).ToList();

            return diffs;
        }

            public List<MovingTypeViewDTO> GetMovingTypes()
            {   
            var mt = _context.MovingTypes.Select(c => new MovingTypeViewDTO
            {
                Name = c.Name,
            }).ToList();

            return mt;
            }

        public List<InterestViewDTO> GetInterests()
        {
            var interests = _context.Interests.Select(c => new InterestViewDTO
            {
                Name = c.Name,
            }).ToList();

            return interests;
        }

        public List<LandmarkViewDTO> GetMereLandmarks(MereLandmarkViewModel dto)
        {

            var landmarks = _context.Landmarks.Include(x => x.Interests)
                .Where(l => l.City == dto.City && dto.Interests.Intersect(l.Interests) != null)
                .Select(l => new LandmarkViewDTO
                {
                    Name = l.Name,
                    City = l.City,
                    Interests = l.Interests.ToList(),
                    VisitCost = l.VisitCosts.ToList(),
                    VisitTime = l.VisitTime,
                    MinAge = l.MinAge,
                    MaxAge = l.MaxAge,
                    Difficulty = l.Difficulty,
                }).ToList();

            return landmarks;
        }
    }
}
