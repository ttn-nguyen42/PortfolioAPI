namespace Portfolio.Models
{
    public class CertificateWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Issuer { get; set; }

        public string Instructor { get; set; }

        public DateTime Time { get; set; }

        public ICollection<CertificateDescriptionWithoutParentDto> Descriptions { get; set; } = new List<CertificateDescriptionWithoutParentDto>();

        public CertificateTypeDto? Type { get; set; }

        public ICollection<CertificateLinkWithoutParentDto> Links { get; set; } = new List<CertificateLinkWithoutParentDto>();

        public CertificateWithoutParentDto(int id, string name, string issuer, string instructor, DateTime time)
        {
            Id = id;
            Name = name;
            Issuer = issuer;
            Instructor = instructor;
            Time = time;
        }
    }

    public class CertificateCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Issuer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Instructor { get; set; }

        public DateTime Time { get; set; }

        public ICollection<CertificateDescriptionCreationDto> Descriptions { get; set; } = new List<CertificateDescriptionCreationDto>();

        public int TypeId { get; set; }

        public ICollection<CertificateLinkCreationDto> Links { get; set; } = new List<CertificateLinkCreationDto>();

        public CertificateCreationDto(string name, string issuer, string instructor, DateTime time, int typeId)
        {
            Name = name;
            Issuer = issuer;
            Instructor = instructor;
            Time = time;
            TypeId = typeId;
        }
    }

    public class CertificateUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Issuer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Instructor { get; set; }

        public DateTime Time { get; set; }

        public ICollection<CertificateDescriptionCreationDto> Descriptions { get; set; } = new List<CertificateDescriptionCreationDto>();

        public int TypeId { get; set; }

        public ICollection<CertificateLinkCreationDto> Links { get; set; } = new List<CertificateLinkCreationDto>();

        public CertificateUpdateDto(string name, string issuer, string instructor, DateTime time, int typeId)
        {
            Name = name;
            Issuer = issuer;
            Instructor = instructor;
            Time = time;
            TypeId = typeId;
        }
    }


    public class CertificateDescriptionWithoutParentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public CertificateDescriptionWithoutParentDto(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }

    public class CertificateDescriptionCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public CertificateDescriptionCreationDto(string description)
        {
            Description = description;
        }
    }

    public class CertificateLinkWithoutParentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public CertificateLinkWithoutParentDto(int id, string name, string link)
        {
            Id = id;
            Name = name;
            Link = link;
        }
    }

    public class CertificateLinkCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Link { get; set; }

        public CertificateLinkCreationDto(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }

    public class CertificateTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CertificateTypeDto(string name)
        {
            Name = name;
        }
    }

    public class CertificateTypeCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public CertificateTypeCreationDto(string name)
        {
            Name = name;
        }
    }

    public class CertificateTypeUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public CertificateTypeUpdateDto(string name)
        {
            Name = name;
        }
    }
}
