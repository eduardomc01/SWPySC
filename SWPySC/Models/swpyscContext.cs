using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SWPySC.Models
{
    public partial class swpyscContext : DbContext
    {
        private string conecctionString;

        public swpyscContext(string _conecctionString)
        {

            this.conecctionString = _conecctionString;

        }

        public swpyscContext(DbContextOptions<swpyscContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<Codigos> Codigos { get; set; }
        public virtual DbSet<Delitos> Delitos { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<Gradodelito> Gradodelito { get; set; }
        public virtual DbSet<Historialdelitomes> Historialdelitomes { get; set; }
        public virtual DbSet<Historialusuarios> Historialusuarios { get; set; }
        public virtual DbSet<Registros> Registros { get; set; }
        public virtual DbSet<Tipousuarios> Tipousuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

               optionsBuilder.UseMySql(conecctionString);

                /* #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=swpysc;User=root;Password=123abc;");
                */
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acciones>(entity =>
            {
                entity.ToTable("acciones");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Codigos>(entity =>
            {
                entity.ToTable("codigos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Delitos>(entity =>
            {
                entity.ToTable("delitos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cp)
                    .HasColumnName("cp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasColumnType("time");

                entity.Property(e => e.IdCodigo)
                    .HasColumnName("id_codigo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdGd)
                    .HasColumnName("id_gd")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitud).HasColumnName("latitud");

                entity.Property(e => e.Longitud).HasColumnName("longitud");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.ToTable("estatus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Gradodelito>(entity =>
            {
                entity.ToTable("gradodelito");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Historialdelitomes>(entity =>
            {
                entity.ToTable("historialdelitomes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abril)
                    .HasColumnName("abril")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Agosto)
                    .HasColumnName("agosto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Diciembre)
                    .HasColumnName("diciembre")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Enero)
                    .HasColumnName("enero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Febrero)
                    .HasColumnName("febrero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Julio)
                    .HasColumnName("julio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Junio)
                    .HasColumnName("junio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Marzo)
                    .HasColumnName("marzo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Mayo)
                    .HasColumnName("mayo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Noviembre)
                    .HasColumnName("noviembre")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Octubre)
                    .HasColumnName("octubre")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Septiembre)
                    .HasColumnName("septiembre")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Historialusuarios>(entity =>
            {
                entity.ToTable("historialusuarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dia)
                    .HasColumnName("dia")
                    .HasColumnType("date");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasColumnType("time");

                entity.Property(e => e.IdAccion)
                    .HasColumnName("id_accion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Registros>(entity =>
            {
                entity.ToTable("registros");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.IdEstatus)
                    .HasColumnName("id_estatus")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IdTipoUsuario)
                    .HasColumnName("id_tipoUsuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Tipousuarios>(entity =>
            {
                entity.ToTable("tipousuarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentarios)
                    .HasColumnName("comentarios")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("varchar(45)");
            });
        }
    }
}
