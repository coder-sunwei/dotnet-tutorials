#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ContactManager.Authorization;

namespace ContactManager.Pages.Contacts
{
    public class IndexModel : DI_BasePageModel
    {
        private readonly ContactManager.Data.ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IList<Contact> Contact { get; set; }

        public async Task OnGetAsync()
        {
            var contacts = from c in Context.Contact
                           select c;

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) || User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserID = UserManager.GetUserId(User);

            if (!isAuthorized)
            {
                contacts = contacts.Where(c => c.Status == ContactStatus.Approved || c.OwnerID == currentUserID);
            }

            Contact = await contacts.ToListAsync();
        }
    }
}
