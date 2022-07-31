using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;

namespace Portfolio.Contexts
{
    public static class ContextBuilder
    {
        public static void BuildTechnicalSkill(ModelBuilder builder)
        {
            builder.Entity<TechnicalSkill>().HasOne(s => s.Type);

            builder.Entity<TechnicalSkill>().HasMany(s => s.Skills).WithOne(d => d.TechnicalSkill);
            builder.Entity<TechnicalSkillDescription>().HasOne(d => d.TechnicalSkill).WithMany(s => s.Skills);
        }

        public static void BuildExperience(ModelBuilder builder)
        {
            builder.Entity<Experience>().HasMany(e => e.Descriptions);
            builder.Entity<ExperienceDescription>().HasOne(d => d.Experience).WithMany(e => e.Descriptions);
        }

        public static void BuildEducation(ModelBuilder builder)
        {
            builder.Entity<Education>().HasMany(e => e.Descriptions).WithOne(d => d.Education);
            builder.Entity<EducationDescription>().HasOne(d => d.Education).WithMany(e => e.Descriptions);
        }

        public static void BuildVolunteering(ModelBuilder builder)
        {
            builder.Entity<Volunteering>().HasMany(v => v.Descriptions).WithOne(d => d.Volunteering);
            builder.Entity<VolunteeringDescription>().HasOne(d => d.Volunteering).WithMany(v => v.Descriptions);
        }

        public static void BuildQualification(ModelBuilder builder)
        {
            builder.Entity<Qualification>().HasMany(q => q.Descriptions).WithOne(d => d.Qualification);
            builder.Entity<QualificationDescription>().HasOne(d => d.Qualification).WithMany(q => q.Descriptions);
        }

        public static void BuildCertificate(ModelBuilder builder)
        {
            builder.Entity<Certificate>().HasMany(c => c.Descriptions).WithOne(d => d.Certificate);
            builder.Entity<CertificateDescription>().HasOne(d => d.Certificate).WithMany(c => c.Descriptions);

            builder.Entity<Certificate>().HasMany(c => c.Links).WithOne(d => d.Certificate);
            builder.Entity<CertificateLink>().HasOne(l => l.Certificate).WithMany(c => c.Links);
        }

        public static void BuildActivity(ModelBuilder builder)
        {
            builder.Entity<Activity>().HasMany(a => a.Descriptions).WithOne(d => d.Activity);
            builder.Entity<ActivityDescription>().HasOne(d => d.Activity).WithMany(a => a.Descriptions);

            builder.Entity<Activity>().HasMany(a => a.Links).WithOne(l => l.Activity);
            builder.Entity<ActivityLink>().HasOne(l => l.Activity).WithMany(a => a.Links);
        }

        public static void BuildProject(ModelBuilder builder)
        {
            builder.Entity<Project>().HasMany(p => p.Descriptions).WithOne(d => d.Project);
            builder.Entity<ProjectDescription>().HasOne(d => d.Project).WithMany(p => p.Descriptions);

            builder.Entity<Project>().HasMany(p => p.Links).WithOne(l => l.Project);
            builder.Entity<ProjectLink>().HasOne(l => l.Project).WithMany(p => p.Links);
        }

        public static void BuildResume(ModelBuilder builder)
        {
            builder.Entity<Resume>().HasMany(r => r.Skills).WithOne(s => s.Resume);
            builder.Entity<TechnicalSkill>().HasOne(s => s.Resume).WithMany(r => r.Skills);

            builder.Entity<Resume>().HasMany(r => r.Experience).WithOne(e => e.Resume);
            builder.Entity<Experience>().HasOne(e => e.Resume).WithMany(r => r.Experience);

            builder.Entity<Resume>().HasMany(r => r.Activities).WithOne(a => a.Resume);
            builder.Entity<Activity>().HasOne(a => a.Resume).WithMany(r => r.Activities);

            builder.Entity<Resume>().HasMany(r => r.Certificates).WithOne(c => c.Resume);
            builder.Entity<Certificate>().HasOne(c => c.Resume).WithMany(r => r.Certificates);

            builder.Entity<Resume>().HasMany(r => r.Projects).WithOne(p => p.Resume);
            builder.Entity<Project>().HasOne(p => p.Resume).WithMany(r => r.Projects);

            builder.Entity<Resume>().HasMany(r => r.Education).WithOne(e => e.Resume);
            builder.Entity<Education>().HasOne(e => e.Resume).WithMany(r => r.Education);

            builder.Entity<Resume>().HasMany(r => r.Qualification).WithOne(q => q.Resume);
            builder.Entity<Qualification>().HasOne(q => q.Resume).WithMany(r => r.Qualification);

            builder.Entity<Resume>().HasMany(r => r.Volunteering).WithOne(v => v.Resume);
            builder.Entity<Volunteering>().HasOne(v => v.Resume).WithMany(r => r.Volunteering);

            builder.Entity<Resume>().HasMany(r => r.PersonalLink).WithOne(l => l.Resume);
            builder.Entity<PersonalLink>().HasOne(l => l.Resume).WithMany(r => r.PersonalLink);
        }
    }
}
