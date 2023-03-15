using Microsoft.EntityFrameworkCore;
using System.Linq;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;

namespace tpa_backend.Services
{
    public interface ITouristService
    {
        public void CreateTourist(TouristCreateEditDTO dto);
        public void EditTourist(TouristCreateEditDTO dto, Guid touristId);
        public void RemoveTourist(Guid touristId);
    }

    public class TouristService : ITouristService
    {
        private AppDbContext _context;
        public TouristService(AppDbContext context)
        {
            _context=context;
        }

        public void CreateTourist(TouristCreateEditDTO dto)
        {
            var user=_context.Users.FirstOrDefault(x=>x.Email==dto.UserEmail);
            if(user==null)
                throw new IndexOutOfRangeException($"Error");
            var tourist = new Tourist
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Age = dto.Age,
                Interests = dto.Interests,
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


        public void RemoveTourist(Guid touristId)
        {
            var tourist= _context.Tourists.Find(touristId);
            if(tourist==null)
                throw new IndexOutOfRangeException($"Tourist is not found");
            _context.Tourists.Remove(tourist);
            _context.SaveChanges();
        }
    }


}
