using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoCalendario.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.Especie> Especies { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.Vacuna> Vacunas { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.Calendario> Calendarios { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.DetalleCalendario> DetalleCalendarios { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.Pauta> Pautas { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.Mascota> Mascotas { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.ListaAtencion> ListaAtencions { get; set; }

        public System.Data.Entity.DbSet<ProyectoCalendario.Models.ServicioClinico> ServicioClinicoes { get; set; }

        public static implicit operator ApplicationDbContext(SqlConnection v)
        {
            throw new NotImplementedException();
        }
    }
}