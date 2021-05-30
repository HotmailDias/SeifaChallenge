using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEIFAChallenge.DBModels;

namespace SEIFAChallenge.DB
{
    public class SeifaContext:DbContext
    {
        public SeifaContext(DbContextOptions<SeifaContext> options) 
            : base(options)
        {
            
        }

        public SeifaContext() 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_SEIFA2016>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LGA_Code).HasColumnName("LGA_Code");
                entity.Property(e => e.State).HasColumnName("State");
                entity.Property(e => e.LGA_Name).HasColumnName("LGA_Name");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Disadvantage_decile).HasColumnType("Index_of_Relative_Socio_economic_Disadvantage_decile");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Disadvantage_Score).HasColumnType("Index_of_Relative_Socio_economic_Disadvantage_Score");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score).HasColumnType("Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Decile).HasColumnType("Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Decile");
                entity.Property(e => e.Index_of_Education_and_Occupation_Score).HasColumnType("Index_of_Education_and_Occupation_Score");
                entity.Property(e => e.Index_of_Economic_Resources_Decile).HasColumnType("Index_of_Economic_Resources_Decile");
                entity.Property(e => e.Index_of_Economic_Resources_Score).HasColumnType("Index_of_Economic_Resources_Score");
                entity.Property(e => e.Index_of_Education_and_Occupation_Decile).HasColumnType("Index_of_Education_and_Occupation_Decile");



            });

            modelBuilder.Entity<vw_SocioEconomicDisadvantages>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LGA_Code).HasColumnName("LGA_Code");
                entity.Property(e => e.Place2011).HasColumnName("Place2011");
                entity.Property(e => e.Place2016).HasColumnName("Place2016");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Disadvantage_2011).HasColumnType("Index_of_Relative_Socio_economic_Disadvantage_2011");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Disadvantage_Score_2016).HasColumnType("Index_of_Relative_Socio_economic_Disadvantage_Score_2016");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_2011).HasColumnType("Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_2011");
                entity.Property(e => e.Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score_2016).HasColumnType("Index_of_Relative_Socio_economic_Advantage_and_Disadvantage_Score_2016");

            });

            modelBuilder.Entity<vw_PivotByClientId>(entity =>
            {
                entity.HasNoKey();
                
                entity.Property(e => e.ClientId).HasColumnName("ClientId");
                entity.Property(e => e.WebId).HasColumnName("WebId");
                entity.Property(e => e.GeoName).HasColumnName("GeoName");
                entity.Property(e => e.Year).HasColumnType("Year");
                entity.Property(e => e.Number).HasColumnType("Number");
                entity.Property(e => e.ChangeYear1Year2).HasColumnType("ChangeYear1Year2");
                
            });
        }



        public virtual DbSet<SEIFA_2011> Seifa_2011 { get; set; }
        public virtual DbSet<vw_SocioEconomicDisadvantages> vw_SocioEconomicDisadvantages { get; set; }

        public virtual DbSet<vw_SEIFA2016> vw_SEIFA2016 { get; set; }

        public virtual DbSet<vw_PivotByClientId> vw_PivotByClientId { get; set; }

    }
}
