using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;

namespace Portfolio.Contexts
{
    public static class ContextBuilder
    {
        public static void BuildTechnicalSkill(ModelBuilder builder)
        {
            builder.Entity<TechnicalSkill>()
                   .HasOne(s => s.Type);

            builder.Entity<TechnicalSkill>()
                   .HasMany(s => s.Skills)
                   .WithOne(d => d.TechnicalSkill);
            builder.Entity<TechnicalSkillDescription>()
                   .HasOne(d => d.TechnicalSkill)
                   .WithMany(s => s.Skills)
                   .HasForeignKey(d => d.TechnicalSkillId);
        }

        public static void BuildExperience(ModelBuilder builder)
        {
            builder.Entity<Experience>()
                   .HasMany(e => e.Descriptions);
            builder.Entity<ExperienceDescription>()
                   .HasOne(d => d.Experience)
                   .WithMany(e => e.Descriptions)
                   .HasForeignKey(d => d.ExperienceId);
        }

        public static void BuildEducation(ModelBuilder builder)
        {
            builder.Entity<Education>()
                   .HasMany(e => e.Descriptions)
                   .WithOne(d => d.Education);
            builder.Entity<EducationDescription>()
                   .HasOne(d => d.Education)
                   .WithMany(e => e.Descriptions)
                   .HasForeignKey(d => d.EducationId);
        }

        public static void BuildVolunteering(ModelBuilder builder)
        {
            builder.Entity<Volunteering>()
                   .HasMany(v => v.Descriptions)
                   .WithOne(d => d.Volunteering);
            builder.Entity<VolunteeringDescription>()
                   .HasOne(d => d.Volunteering)
                   .WithMany(v => v.Descriptions)
                   .HasForeignKey(d => d.VolunteeringId);
        }

        public static void BuildQualification(ModelBuilder builder)
        {
            builder.Entity<Qualification>()
                   .HasMany(q => q.Descriptions)
                   .WithOne(d => d.Qualification);
            builder.Entity<QualificationDescription>()
                   .HasOne(d => d.Qualification)
                   .WithMany(q => q.Descriptions)
                   .HasForeignKey(d => d.QualificationId);
        }

        public static void BuildCertificate(ModelBuilder builder)
        {
            builder.Entity<Certificate>()
                   .HasMany(c => c.Descriptions)
                   .WithOne(d => d.Certificate);
            builder.Entity<CertificateDescription>()
                   .HasOne(d => d.Certificate)
                   .WithMany(c => c.Descriptions)
                   .HasForeignKey(d => d.CertificateId);

            builder.Entity<Certificate>()
                   .HasMany(c => c.Links)
                   .WithOne(d => d.Certificate);
            builder.Entity<CertificateLink>()
                   .HasOne(l => l.Certificate)
                   .WithMany(c => c.Links)
                   .HasForeignKey(l => l.CertificateId);
        }

        public static void BuildActivity(ModelBuilder builder)
        {
            builder.Entity<Activity>()
                   .HasMany(a => a.Descriptions)
                   .WithOne(d => d.Activity);
            builder.Entity<ActivityDescription>()
                   .HasOne(d => d.Activity)
                   .WithMany(a => a.Descriptions)
                   .HasForeignKey(d => d.ActivityId);

            builder.Entity<Activity>()
                   .HasMany(a => a.Links)
                   .WithOne(l => l.Activity);
            builder.Entity<ActivityLink>()
                   .HasOne(l => l.Activity)
                   .WithMany(a => a.Links)
                   .HasForeignKey(l => l.ActivityId);
        }

        public static void BuildProject(ModelBuilder builder)
        {
            builder.Entity<Project>()
                   .HasMany(p => p.Descriptions)
                   .WithOne(d => d.Project);
            builder.Entity<ProjectDescription>()
                   .HasOne(d => d.Project)
                   .WithMany(p => p.Descriptions)
                   .HasForeignKey(d => d.ProjectId);

            builder.Entity<Project>()
                   .HasMany(p => p.Links)
                   .WithOne(l => l.Project);
            builder.Entity<ProjectLink>()
                   .HasOne(l => l.Project)
                   .WithMany(p => p.Links)
                   .HasForeignKey(l => l.ProjectId);
        }

        public static void BuildResume(ModelBuilder builder)
        {
            builder.Entity<Resume>()
                   .HasMany(r => r.Skills)
                   .WithOne(s => s.Resume);
            builder.Entity<TechnicalSkill>()
                   .HasOne(s => s.Resume)
                   .WithMany(r => r.Skills)
                   .HasForeignKey(s => s.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.Experience)
                   .WithOne(e => e.Resume);
            builder.Entity<Experience>()
                   .HasOne(e => e.Resume)
                   .WithMany(r => r.Experience)
                   .HasForeignKey(e => e.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.Activities)
                   .WithOne(a => a.Resume);
            builder.Entity<Activity>()
                   .HasOne(a => a.Resume)
                   .WithMany(r => r.Activities)
                   .HasForeignKey(a => a.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.Certificates)
                   .WithOne(c => c.Resume);
            builder.Entity<Certificate>()
                   .HasOne(c => c.Resume)
                   .WithMany(r => r.Certificates)
                   .HasForeignKey(c => c.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.Projects)
                   .WithOne(p => p.Resume);
            builder.Entity<Project>()
                   .HasOne(p => p.Resume)
                   .WithMany(r => r.Projects)
                   .HasForeignKey(p => p.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.Education)
                   .WithOne(e => e.Resume);
            builder.Entity<Education>()
                   .HasOne(e => e.Resume)
                   .WithMany(r => r.Education)
                   .HasForeignKey(e => e.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.Qualification)
                   .WithOne(q => q.Resume);
            builder.Entity<Qualification>()
                   .HasOne(q => q.Resume)
                   .WithMany(r => r.Qualification)
                   .HasForeignKey(q => q.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.Volunteering)
                   .WithOne(v => v.Resume);
            builder.Entity<Volunteering>()
                   .HasOne(v => v.Resume)
                   .WithMany(r => r.Volunteering)
                   .HasForeignKey(v => v.ResumeId);

            builder.Entity<Resume>()
                   .HasMany(r => r.PersonalLink)
                   .WithOne(l => l.Resume);
            builder.Entity<PersonalLink>()
                   .HasOne(l => l.Resume)
                   .WithMany(r => r.PersonalLink)
                   .HasForeignKey(l => l.ResumeId);
        }
    }
}
