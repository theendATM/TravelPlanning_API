using Microsoft.EntityFrameworkCore;
using System.Linq;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;

namespace tpa_backend.Services
{
    public interface ILandmarkService
    {
        public List<LandmarkViewDTO> GetMereLandmarks(MereLandmarkViewModel dto);
        public List<LandmarkViewDTO> GetSuitableLandmarks(SuitableLandmarksViewModel dto);
    }


    public class LandmarkService : ILandmarkService
    {
        private AppDbContext _context;
        public LandmarkService(AppDbContext context)
        {
            _context = context;
        }

        public List<LandmarkViewDTO> GetMereLandmarks(MereLandmarkViewModel dto)
        {
            var res = new List<LandmarkViewDTO>();
            var landmarks = _context.Landmarks.Include(x => x.Interests).Include(x => x.City).Include(x => x.Difficulty)
                .Where(l => l.City.Id == dto.CityId);//нашли по городу
            foreach (var l in landmarks)
            {
                foreach (var interest in l.Interests)
                {
                    //Console.WriteLine(dto.InterestIds);
                    //Console.WriteLine(interest.Id);
                    if (dto.InterestIds.Contains(interest.Id))
                    {
                        res.Add(new LandmarkViewDTO
                        {
                            Id = l.Id,
                            Name = l.Name,
                            City = l.City,
                            Interests = l.Interests.ToList(),
                            Address = l.Address,
                            VisitTime = l.VisitTime,
                            MinAge = l.MinAge,
                            MaxAge = l.MaxAge,
                            Difficulty = l.Difficulty,
                        });
                        break;
                    }

                }
            }
            return res;
            /*var interests = _context.Interests.Where(x => dto.InterestIds.Contains(x.Id));
            var landmarks = _context.Landmarks.Include(x => x.Interests).Include(x => x.City)
                .Where(l => l.City.Id == dto.CityId && l.Interests.Intersect(interests)!=null)
                .Select(l=> new LandmarkViewDTO
                {
                    Name = l.Name,
                    City = l.City,
                    Interests = l.Interests.ToList(),
                    Address = l.Address,
                    VisitTime = l.VisitTime,
                    MinAge = l.MinAge,
                    MaxAge = l.MaxAge,
                    Difficulty = l.Difficulty,
                }).ToList();
            return landmarks;*/

        }

        public List<LandmarkViewDTO> GetSuitableLandmarks(SuitableLandmarksViewModel dto)
        {
            var res = new List<LandmarkViewDTO>();
            var landmarks = _context.Landmarks.Include(x => x.Interests).Include(x => x.City).Include(x => x.Difficulty)
                .Where(l => l.City.Id == dto.CityId && dto.DifficultyIds.Contains(l.Difficulty.Id));//нашли по городу и сложности

            var interests = new List<int>();
            var tourists = _context.Tourists.Include(x => x.Interests).Where(x => dto.TouristIds.Contains(x.Id)).ToList();
            foreach (var t in tourists)
            {
                foreach (var i in t.Interests)
                {
                    if (!interests.Contains(i.Id))
                        interests.Add(i.Id);
                }
            }//нашли все нужные интересы
            foreach (var l in landmarks)
            {
                foreach (var interest in l.Interests)
                {
                    if (interests.Contains(interest.Id))
                    {
                        res.Add(new LandmarkViewDTO
                        {
                            Id = l.Id,
                            Name = l.Name,
                            City = l.City,
                            Interests = l.Interests.ToList(),
                            Address = l.Address,
                            VisitTime = l.VisitTime,
                            MinAge = l.MinAge,
                            MaxAge = l.MaxAge,
                            Difficulty = l.Difficulty,
                        });
                        break;
                    }

                }


            }
            return res;
        }
    }
}
