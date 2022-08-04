using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface ICertificateRepository
    {
        public Task<IEnumerable<CertificateType>> GetCertificateTypesAsync();

        public Task<CertificateType?> GetCertificateTypeAsync(int id);

        public Task<Certificate?> GetCertificateAsync(int id);

        public void AddCertificateType(CertificateType certificateType);

        public void AddCertificate(Certificate certificate);

        public void RemoveCertificate(Certificate certificate);

        public Task<bool> SaveChangesAsync();

    }

    public class CertificateRepository: ICertificateRepository
    {
        private readonly PortfolioContext _context;

        public CertificateRepository(PortfolioContext context)
        {
            _context = context;
        }

        public void AddCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
        }

        public void AddCertificateType(CertificateType certificateType)
        {
            _context.CertificateTypes.Add(certificateType);
        }

        public async Task<Certificate?> GetCertificateAsync(int id)
        {
            return await _context.Certificates.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CertificateType?> GetCertificateTypeAsync(int id)
        {
            return await _context.CertificateTypes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CertificateType>> GetCertificateTypesAsync()
        {
            return await _context.CertificateTypes.ToListAsync();
        }

        public void RemoveCertificate(Certificate certificate)
        {
            _context.Certificates.Remove(certificate);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0; 
        }
    }
}
