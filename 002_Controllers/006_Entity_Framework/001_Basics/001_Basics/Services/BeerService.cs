using _001_Basics.DTOs;
using _001_Basics.Models;
using _001_Basics.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _001_Basics.Services
{
    public class BeerService : ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>
    {

        private IRepository<BeerModels> _beerRepository;
        private IMapper _mapper;

        public List<string> Errors { get; }

        public BeerService(
            IRepository<BeerModels> beerRepository,
            IMapper mapper
            )
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<BeerDTO>> GetBeers() => await _context.BeerModels.Select(beer => new BeerDTO
        //{
        //    Id = beer.Id,
        //    Name = beer.Name,
        //    Alcohol = beer.Alcohol,
        //    BrandId = beer.BrandId
        //}).ToListAsync();

        public async Task<IEnumerable<BeerDTO>> GetBeers()
        {
            var beers = await _beerRepository.Get();

            //return beers.Select(beer => new BeerDTO
            //{
            //    Id = beer.Id,
            //    Name = beer.Name,
            //    Alcohol = beer.Alcohol,
            //    BrandId = beer.BrandId
            //});

            return beers.Select(beer => _mapper.Map<BeerDTO>(beer));   
        }

        public async Task<BeerDTO> GetBeer(int id)
        {

            var beer = await _beerRepository.GetById(id);

            if(beer != null)
            {
                var beerDto = _mapper.Map<BeerDTO>(beer);

                return beerDto;
            }

            return null;

        }

        public async Task<BeerDTO> AddBeer(BeerInsertDTO beerInsertDTO)
        {
            //var beer = new BeerModels()
            //{
            //    Name = beerInsertDTO.Name,
            //    BrandId = (int)beerInsertDTO.BrandId,
            //    Alcohol = beerInsertDTO.Alcohol
            //};

            var beer = _mapper.Map<BeerModels>(beerInsertDTO);

            await _beerRepository.Add(beer);
            await _beerRepository.Save();

            var beerDTO = _mapper.Map<BeerDTO>(beer);

            return beerDTO;
        }

        public async Task<BeerDTO> DeleteBeer(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer == null) return null;

            _beerRepository.Delete(beer);
            await _beerRepository.Save();

            //var beerDTO = new BeerDTO
            //{
            //    Id = beer.Id,
            //    Name = beer.Name,
            //    Alcohol = beer.Alcohol,
            //    BrandId = beer.BrandId
            //};

            var beerDTO = _mapper.Map<BeerDTO>(beer);

            return beerDTO;
        }

        public async Task<BeerDTO> UpdateBeer(int id, BeerUpdateDTO beerUpdateDTO)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer == null) return null;

            //beer.Name = beerUpdateDTO.Name;
            //beer.BrandId = (int)beerUpdateDTO.BrandId;
            //beer.Alcohol = beerUpdateDTO.Alcohol;


            beer = _mapper.Map<BeerUpdateDTO, BeerModels>(beerUpdateDTO, beer);

            _beerRepository.Update(beer);
            await _beerRepository.Save();

            //var beerDTO = new BeerDTO
            //{
            //    Id = beer.Id,
            //    Name = beer.Name,
            //    Alcohol = beer.Alcohol,
            //    BrandId = beer.BrandId
            //};

            var beerDTO = _mapper.Map<BeerDTO>(beer);

            return beerDTO;
        }


        public bool Validate(BeerInsertDTO beerInsertDTO)
        {

            if(_beerRepository.Search(beer => beer.Name == beerInsertDTO.Name).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza duplicada");
                return false;
            }

            return true;
        }

        public bool Validate(BeerUpdateDTO beerUpdateDTO)
        {

            if (_beerRepository.Search(beer => beer.Name == beerUpdateDTO.Name && beerUpdateDTO.Id != beer.Id).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza duplicada");
                return false;
            }

            return true;
        }

    }
}
