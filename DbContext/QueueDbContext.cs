using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend;

public class QueueDbContext(DbContextOptions<QueueDbContext> options):DbContext(options)

{
    public DbSet<Account> Account => Set<Account>();
    public DbSet<Department> Department => Set<Department>();
    public DbSet<Role> Role => Set<Role>();
    public DbSet<Transaction> Transaction => Set<Transaction>();
    public DbSet<Counter> Counter => Set<Counter>();
    public DbSet<Document> Document => Set<Document>();
    public DbSet<Ticket> Ticket => Set<Ticket>();
    public DbSet<TicketFinance> TicketFinance => Set<TicketFinance>();
    public DbSet<TicketDocument> TicketDocument => Set<TicketDocument>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Account entity
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Department)
            .WithMany(d => d.Accounts)
            .HasForeignKey(a => a.DepartmentId);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.Role)
            .WithMany(r => r.Accounts)
            .HasForeignKey(a => a.RoleId);
        
        modelBuilder.Entity<Counter>()
            .HasOne(a => a.Department)
            .WithMany(a => a.Counters)
            .HasForeignKey(a => a.DepartmentId);
        
        modelBuilder.Entity<Counter>()
            .HasOne(a => a.CurrentTicket)
            .WithMany(a => a.Counter)
            .HasForeignKey(a => a.CurrentTicketId);
       
        modelBuilder.Entity<Ticket>()
            .HasOne(a => a.TicketDocument)
            .WithMany(a => a.Tickets)
            .HasForeignKey(a => a.TicketDocumentId);
        
        modelBuilder.Entity<Ticket>()
            .HasOne(a => a.TicketFinance)
            .WithMany(a => a.Tickets)
            .HasForeignKey(a => a.TicketFinanceId);
        
        modelBuilder.Entity<Ticket>()
            .HasOne(a => a.Department)
            .WithMany(a => a.Tickets)
            .HasForeignKey(a => a.DepartmentId);
        
        
        modelBuilder.Entity<Transaction>()
            .HasOne(a => a.Department)
            .WithMany(a => a.Transactions)
            .HasForeignKey(a => a.DepartmentId);
        
        modelBuilder.Entity<Transaction>()
            .HasOne(a => a.Ticket)
            .WithMany(a => a.Transaction)
            .HasForeignKey(a => a.TicketId);
        
        modelBuilder.Entity<Transaction>()
            .HasOne(a => a.Account)
            .WithMany(a => a.Transaction)
            .HasForeignKey(a => a.TransactedBy);

        modelBuilder.Entity<Document>()
            .HasOne(a => a.Department)
            .WithMany(a => a.Documents)
            .HasForeignKey(a => a.DepartmentId);



      
    }
}