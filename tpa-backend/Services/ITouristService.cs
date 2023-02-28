using Microsoft.EntityFrameworkCore;
using System.Linq;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;

namespace tpa_backend.Services
{
    public interface ITouristService
    {
        public void CreateTourist(TouristCreateEditDTO dto, Guid userId);
        public void EditTourist(TouristCreateEditDTO dto, Guid touristId);
        public TouristViewDTO GetTourist(Guid touristId);
        public void RemoveTourist(Guid touristId);
    }

    public class TouristService : ITouristService
    {
        private AppDbContext _context;
        public TouristService(AppDbContext context)
        {
            _context=context;
        }

        public void CreateTourist(TouristCreateEditDTO dto, Guid userId)
        {
            var user=_context.Users.FirstOrDefault(x=>x.Id==userId);
            if(user==null)
                throw new IndexOutOfRangeException($"Error");
            var tourist = new Tourist
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Age = dto.Age,
                Interests = dto.Interests.ToList(),
                User = user,
            };
            _context.Tourists.Add(tourist);
            _context.SaveChanges();
        }

        public void EditTourist(TouristCreateEditDTO dto, Guid touristId)
        {
            var tourist = _context.Tourists.FirstOrDefault(x => x.Id == touristId);
            if (tourist == null)
                throw new IndexOutOfRangeException($"Tourist with id {touristId} is not found");
            tourist.Age= dto.Age;
            tourist.Interests= dto.Interests.ToList();
            tourist.Name= dto.Name;

            _context.SaveChanges();
        }


        public TouristViewDTO GetTourist(Guid touristId)
        {
            var tourist=_context.Tourists.Include(x=>x.Interests)
                .FirstOrDefault(x=>x.Id == touristId);
            return new TouristViewDTO
            {
                Id = tourist.Id,
                Name = tourist.Name,
                Age = tourist.Age,
                Interests = tourist.Interests.ToList(),
            };
        }

        public void RemoveTourist(Guid touristId)
        {
            var tourist= _context.Tourists.Find(touristId);
            _context.Tourists.Remove(tourist);
            _context.SaveChanges();
        }
    }


}
