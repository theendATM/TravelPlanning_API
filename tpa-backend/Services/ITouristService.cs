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
        public void EditTourist(TouristEditDTO dto);
        public void RemoveTourist(Guid touristId);
        public List<int> GetTouristInterests(Guid touristId);
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
            var interests = _context.Interests.ToList();
            var touristInterests=new List<Interest>();
            foreach (var interest in interests)
            {
               if(dto.InterestIds.Contains(interest.Id))
                    touristInterests.Add(interest);

            }
            if (user==null)
                throw new IndexOutOfRangeException($"Error");
            var tourist = new Tourist
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Age = dto.Age,
                Interests = touristInterests,
                User = user,
            };
            _context.Tourists.Add(tourist);
            _context.SaveChanges();
        }

        public void EditTourist(TouristEditDTO dto)
        {
            var tourist = _context.Tourists
                .Include(x=>x.Interests).FirstOrDefault(x => x.Id == dto.TouristId);
            if (tourist == null)
                throw new IndexOutOfRangeException($"Tourist is not found");
            var interests = _context.Interests.ToList();
            var touristInterests = new List<Interest>();
            foreach (var interest in interests)
            {
                if (dto.InterestIds.Contains(interest.Id))
                    touristInterests.Add(interest);

            }
            tourist.Age= dto.Age;
            tourist.Interests = touristInterests;
            tourist.Name= dto.Name;

            _context.SaveChanges();
        }

        public List<int> GetTouristInterests(Guid touristId)
        {
            var tourist=_context.Tourists.FirstOrDefault(x => x.Id == touristId);
            var interests = _context.Interests.Where(x => x.Tourists.Contains(tourist)).ToList();
            var res=interests.Select(x => x.Id).ToList();
            return res;
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
