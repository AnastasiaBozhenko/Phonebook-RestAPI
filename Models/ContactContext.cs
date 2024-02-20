using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PhoneBook.Models
{
	public class ContactContext: DbContext
	{
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
        }

        public DbSet<ContactItem> ContactItems { get; set; } = null!;
    }
}

