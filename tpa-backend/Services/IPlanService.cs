using Microsoft.EntityFrameworkCore;
using tpa_backend.Data;
using tpa_backend.DTOModels;
using tpa_backend.Models;

namespace tpa_backend.Services
{
    public interface IPlanService
    {
        public PlanViewDTO GetPlan (Guid planId);
        public void EditPlan(PlanEditDTO dto, Guid planId);
        public void RemovePlan(Guid planId);
        public void CreatePlan (PlanCreateDTO dto);
    }
    public class PlanService : IPlanService
    {
        private AppDbContext _context;
        public PlanService(AppDbContext context)
        {
            _context = context;
        }

        public PlanViewDTO GetPlan(Guid planId)
        {
            var plan =_context.Plans
                .Include(x => x.MovingTypes)
                .Include(x=>x.Days)
                .FirstOrDefault(x=>x.Id == planId);
            return new PlanViewDTO
            {
                Name = plan.Name,
                City = plan.City,
                Budget = plan.Budget,
                Location = plan.Location,
                ArrivalTime = plan.ArrivalTime,
                DepartureTime = plan.DepartureTime,

                //calculations here
                PlanDifficulty = plan.PlanDifficulty,

                ExitTime = plan.ExitTime,
                ComingTime = plan.ComingTime,
                MovingTypes = plan.MovingTypes.ToList(),
                Days = plan.Days.ToList(),
            };
        } 
        
        public void CreatePlan(PlanCreateDTO dto)
        {




            var plan = new Plan
            {
                Id=Guid.NewGuid(),
                Name = dto.Name,
                City = dto.City,
                Budget = dto.Budget,
                Location = dto.Location,
                ArrivalTime = dto.ArrivalTime,
                DepartureTime = dto.DepartureTime,
                ExitTime = dto.ExitTime,
                ComingTime = dto.ComingTime,
                MovingTypes = dto.MovingTypes,
            };
            _context.Plans.Add(plan);
            _context.SaveChanges();
        }

        public void RemovePlan(Guid planId)
        {
            var plan = _context.Plans.Find(planId);
            _context.Plans.Remove(plan);
            _context.SaveChanges();
        }

        public void EditPlan(PlanEditDTO dto, Guid planId)
        {
            var plan = _context.Plans.FirstOrDefault(x => x.Id == planId);
            if (plan == null)
                throw new IndexOutOfRangeException($"Plan with id {planId} is not found");
            plan.Name = dto.Name;
            _context.SaveChanges();
        }
    }
}
