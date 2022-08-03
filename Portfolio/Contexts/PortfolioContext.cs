using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;

namespace Portfolio.Contexts
{
    public class PortfolioContext : DbContext
    {

        /*
         * Entities
         */

        /*
        * Resume
        */
        public DbSet<Resume> Resumes { get; set; } = null!;
        public DbSet<PersonalLink> PersonalLinks { get; set; } = null!;

        /*
         * Technical Skill
         */
        public DbSet<TechnicalSkillType> TechnicalSkillTypes { get; set; } = null!;
        public DbSet<TechnicalSkillDescription> TechnicalSkillDescriptions { get; set; } = null!;
        public DbSet<TechnicalSkill> TechnicalSkills { get; set; } = null!;

        /*
         * Experience
         */
        public DbSet<Experience> Experiences { get; set; } = null!;
        public DbSet<ExperienceDescription> ExperienceDescriptions { get; set; } = null!;

        /*
         * Education
         */
        public DbSet<Education> Educations { get; set; } = null!;
        public DbSet<EducationDescription> EducationDescriptions = null!;

        /*
         * Volunteering
         */
        public DbSet<Volunteering> Volunteerings { get; set; } = null!;
        public DbSet<VolunteeringDescription> VolunteeringDescriptions = null!;

        /*
         * Certificate
         */
        public DbSet<Certificate> Certificates { get; set; } = null!;
        public DbSet<CertificateDescription> CertificateDescriptions { get; set; } = null!;
        public DbSet<CertificateType> CertificateTypes { get; set; } = null!;
        public DbSet<CertificateLink> CertificateLinks { get; set; } = null!;

        /*
         * Activity
         */
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<ActivityDescription> ActivityDescriptions { get; set; } = null!;
        public DbSet<ActivityType> ActivityTypes { get; set; } = null!;
        public DbSet<ActivityLink> ActivityLinks { get; set; } = null!;

        /*
         * Qualifications
         */
        public DbSet<Qualification> Qualifications { get; set; } = null!;
        public DbSet<QualificationDescription> QualificationsDescriptions { get; set; } = null!;

        /*
         * Server configurations
         */

        public PortfolioContext(DbContextOptions<PortfolioContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ContextBuilder.BuildResume(builder);
            ContextBuilder.BuildTechnicalSkill(builder);
            ContextBuilder.BuildExperience(builder);
            ContextBuilder.BuildEducation(builder);
            ContextBuilder.BuildVolunteering(builder);
            ContextBuilder.BuildQualification(builder);
            ContextBuilder.BuildCertificate(builder);
            ContextBuilder.BuildActivity(builder);
            ContextBuilder.BuildProject(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        
        }

    }
}
