using AutoMapper;
using DividendScanner.Domain.Communications;
using DividendScanner.Domain.Model;
using DividendScanner.Domain.Repositories;
using DividendScanner.Domain.Services;
using DividendScanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SectorService(ISectorRepository sectorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _sectorRepository = sectorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Sector>> ListAsync()
        {
            return await _sectorRepository.ListAsync();
        }

        public async Task<SectorResponse> SaveAsync(Sector sector)
        {
            SectorResponse response;
            try
            {
                await _sectorRepository.AddAsync(sector);
                await _unitOfWork.CompleteAsync();
                SectorResource sectorResource = _mapper.Map<Sector, SectorResource>(sector);
                response = new SectorResponse(sectorResource);
            }
            catch(Exception ex)
            {
                response = new SectorResponse(ex.Message);
            }
            
            return response;
        }

        public async Task<SectorResponse> UpdateAsync(int id, Sector sector)
        {
            var currentSector = await _sectorRepository.FindSectorByIdAsync(id);

            if (currentSector == null)
                return new SectorResponse("Sector about given id does not exist in database.");

            currentSector.Name = sector.Name;

            try
            {
                _sectorRepository.Update(currentSector);
                await _unitOfWork.CompleteAsync();
                SectorResource sectorResource = _mapper.Map<Sector, SectorResource>(currentSector);
                return new SectorResponse(sectorResource);
            }
            catch(Exception ex)
            {
                return new SectorResponse($"An error occured during updating: {ex.Message}");
            }
        }

        public async Task<SectorResponse> DeleteAsync(int id)
        {
            var existingSector = _sectorRepository.FindSectorByIdAsync(id);
            if (existingSector == null)
                return new SectorResponse("Sector of given id does not exist");

            try
            {
                await _sectorRepository.DeleteAsync(id);
                await _unitOfWork.CompleteAsync();
                Sector sector = await _sectorRepository.FindSectorByIdAsync(id);
                SectorResource sectorResource = _mapper.Map<Sector, SectorResource>(sector);
                return new SectorResponse(sectorResource);
            }
            catch(Exception ex)
            {
                return new SectorResponse($"An error occured during deleting sector. {ex.Message}");
            }
        }
    }
}
