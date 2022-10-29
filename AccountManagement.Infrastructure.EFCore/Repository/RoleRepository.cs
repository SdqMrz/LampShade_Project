using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _context;
        public RoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditRole GetDetails(long id)
        {
            return _context.Roles.Select(x=>new EditRole
            {
                Id = id,
                Name = x.Name
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<RoleViewModel> List()
        {
            return _context.Roles.Select(x=> new RoleViewModel
            {
                Name = x.Name,
                Id = x.Id,
                CreationDate=x.CreationDate.ToFarsi()
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
